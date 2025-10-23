using System.Security.Cryptography.X509Certificates;

namespace Crossword
{
    class Crossword
    {
        public static void Main(string[] args)
        {
            int currentWindow = 0;
            int profile = 0;
            PlayerDashboard();

            while (true)
            {
                if(currentWindow == 0)
                {
                    //using console key as it is not case dependant   
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.C:
                            if(profile != 1)
                            {
                                Console.WriteLine("Please login first");
                            }
                            //Console.Write("C");
                            break;
                        case ConsoleKey.S:
                            if(profile != 1)
                            {
                                Console.WriteLine("Please login first");
                            }
                            //Console.Write("S");
                            break;
                        case ConsoleKey.L:
                            LoginSubMenu();
                            currentWindow = 1;
                            break;
                    } 
                }
                else if (currentWindow == 1)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.L:
                            if (LoginScreen())
                            {
                                currentWindow = 0;
                                Console.Clear();
                                PlayerDashboard();
                            }
                            break;
                        case ConsoleKey.R:
                            Console.Write("R");
                            break;
                    }
                }

            }
        }

        public static void PlayerDashboard()
        {
            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to crosswords");
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");

            Console.WriteLine("(C)reate   (S)olve   (L)ogin  (Q)uit");
        }

        public static void LoginSubMenu()
        {
            Console.SetCursorPosition(22, 5);
            Console.WriteLine("Log in");
            Console.SetCursorPosition(22, 6);
            Console.WriteLine("Register");
            Console.SetCursorPosition(22, 7);
            Console.WriteLine("Change Role");
        }

        public static bool LoginScreen()
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            Console.ReadLine();
            Console.WriteLine("Enter Password");
            Console.ReadLine();
            Console.WriteLine("Success");
            return true;
        }
    }
}