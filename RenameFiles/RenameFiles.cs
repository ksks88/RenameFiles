using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RenameFiles
{
    public sealed class RenameFiles
    {
        #region Singleton

        private static readonly RenameFiles _instance = new RenameFiles();
        public static RenameFiles Instance
        {
            get
            {
                return _instance;
            }
        }

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static RenameFiles()
        {

        }
        private RenameFiles()
        {
        }

        #endregion

        #region Methods
        public bool RenameToNumberedList(string folderPath, string extension)
        {
            try
            {
                var directories = CustomSearcher.GetDirectories(folderPath, "*", SearchOption.AllDirectories);

                if (directories == null)
                    directories = new List<string>() { folderPath };
                else
                    directories.Add(folderPath);

                int counter = 1;
                foreach (var item in directories)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Running items in folder: " + item + "\n");

                    try
                    {
                        foreach (string filePath in Directory.GetFiles(item, extension))
                        {
                            try
                            {
                                string filename = filePath.Split(new char[] { '\\' }, StringSplitOptions.RemoveEmptyEntries).Last();
                                string newFilePath = String.Format("{0}\\{1}. {2}", item, counter.ToString(), filename);
                                Console.WriteLine("Renaming {0} to {1}...\n", filePath, newFilePath);
                                if (File.Exists(newFilePath))
                                {
                                    System.IO.File.Delete(newFilePath);
                                }

                                System.IO.File.Move(filePath, newFilePath);

                                counter++;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine(ex.ToString());
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(ex.ToString());
                return false;
            }

            return true;
        }
        #endregion

    }
}
