using System;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool alive = true;
            while (alive)
            {
                Console.Clear();
                ConsoleColor color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Open Account \t 2. Withdraw sum \t 3. Add sum");
                Console.WriteLine("4. Close Account \t 5. Skip day \t 6. Exit program");
                Console.WriteLine("Enter the item number:");
                Console.ForegroundColor = color;
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                             // OpenAccount
                            break;
                        case 2:
                             // Withdraw
                            break;
                        case 3:
                            // Put
                            break;
                        case 4:
                            // CloseAccount
                            break;
                        case 5:
                            break;
                        case 6:
                            alive = false;
                            continue;
                    }
                    // CalculatePercentage
                }
                catch (Exception ex)
                {
                    color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ForegroundColor = color;
                }
            }
        }
    }
}
