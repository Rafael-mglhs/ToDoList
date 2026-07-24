namespace ToDoList.Helpers;

public class InputValidator
{
    //Input Validation Functions

    //string verify

    public static string stringVerify(string message)
    {
        while (true)
        {

            Console.WriteLine(message);
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                return (input);
            }

            Console.WriteLine("Don't leave it blank");
            Console.ReadKey();
            Console.Clear();
        }

    }

    //int verify
    public static int intVerify(string message)
    {
        int number;

        while (true)
        {
            Console.WriteLine(message);

            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }

            Console.WriteLine("Invalid value!");
            Console.ReadKey();
            Console.Clear();
        }
    }
            
    //option verify
    public static int optionVerify(string message)
    {
        int number;

        while (true)
        {
            Console.WriteLine(message);

            if (!int.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid value!");
            }
            else
            {
                if ((number > -1) && (number <= 6))
                {
                    return number;
                }
                else
                {
                    Console.WriteLine("Invalid Option");
                }
            }

                    
                    
        }

    }
}