namespace Crossword
{
    class Login
    {

        //TODO: 
        //seperate dashboard into player & admin dashboards 
        //This should remove the if statements for each case 
        public static int Dashboard(User user)
        {
            //using console key as it is not case dependant   
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.C:
                    if (user.Profile != "admin")
                    {
                        Console.WriteLine("Admin login required");
                    }
                    else
                    {
                        Console.WriteLine("Create crossword");
                    }
                    break;
                case ConsoleKey.S:
                    if (user.Profile == "admin" || user.Profile == "player")
                    {
                        Console.WriteLine("Solve crossword");
                    }
                    else
                    {
                        Console.WriteLine("Please login first");
                    }
                    break;
                case ConsoleKey.L:
                    DrawLoginSubMenu();
                    return 1;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }

            return 0;

        }
        
        public static int AdminDashboard(User user)
        {

            return 0;
        }
        
        public static void DrawLoginSubMenu()
        {
            Console.SetCursorPosition(22, 5);
            Console.WriteLine("Log in");
            Console.SetCursorPosition(22, 6);
            Console.WriteLine("Register");
            Console.SetCursorPosition(22, 7);
            Console.WriteLine("Change Role");
        }

    }
}