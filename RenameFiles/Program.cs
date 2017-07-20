using System;

namespace RenameFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            bool success = false;
            string equalsSign = new string('=', 40);
            string prelude = "Please select the rename type: ";
            string renameTypes = "\n1. Numbering - create a numbered list \n2. Custom word";
            string introText = String.Format("{0}\n{1}\n{2}\n{0}", equalsSign, prelude, renameTypes);

            Console.WriteLine(introText);

            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input) || input == 0 || input > 2)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Please enter valid input!");
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine("{0}\nPlease enter root folder path:\n", equalsSign);
            string folderPath = Console.ReadLine();

            Console.WriteLine("\n{0}\nPlease enter file(s) extension(*.png;*.jpeg; etc.)  :\n", equalsSign);
            string extension = Console.ReadLine();
            switch (input)
            {
                case 1:
                    success = RenameFiles.Instance.RenameToNumberedList(folderPath, extension);
                    break;
                case 2:
                    break;
                default:
                    break;
            }
            if (success)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Success!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Failed.");
            }
            Console.WriteLine("END");
            Console.Read();
        }
    }
}