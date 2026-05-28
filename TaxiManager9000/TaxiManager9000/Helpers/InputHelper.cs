namespace TaxiManager9000.Helpers;

public static class InputHelper
{
    public static int ReadInt(string message)
    {
        while (true)
        {
            Console.Write(message);

            bool success = int.TryParse(Console.ReadLine(), out int result);

            if(success)
            {
                return result;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid number! Try again.");
            Console.ResetColor();
        }
    }

    public static string ReadRequiredString(string message)
    {
        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Input cannot be empty! Try again.");
            Console.ResetColor();
        }
    }

    public static int ReadMenuChoice(string message, int min, int max)
    {
        while (true)
        {
            int choice = ReadInt(message);

            if (choice >= min && choice <= max)
            {
                return choice; 
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Please enter a number between {min} and {max}");
            Console.ResetColor();
        }
    }
}
