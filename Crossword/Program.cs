namespace Crossword
{
    class Crossword
    {
        public static void Main(string[] args)
        {
            //new user every time program runs - ensure users have to login
            User user = new User();

            //0 = Dashboard, 1 = Login Submenu,
            int currentWindow = 0;
            

            DrawPlayerDashboard();

            while (true)
            {
                if(currentWindow == 0)
                {
                    //pass to Login helper class
                    currentWindow = Login.Dashboard(user);
                }
                else if (currentWindow == 1)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.L:
                            if (LoginScreen(user))
                            {
                                currentWindow = 0;
                                Console.Clear();
                                DrawPlayerDashboard();
                            }
                            break;
                        case ConsoleKey.R:
                            Console.Write("R");
                            break;
                    }
                }

            }
        }

        public static void DrawPlayerDashboard()
        {
            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to crosswords");
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("");

            Console.WriteLine("(C)reate   (S)olve   (L)ogin  (Q)uit");
        }

        //needs moving to Login.cs 
        public static bool LoginScreen(User user)
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            Console.ReadLine();
            Console.WriteLine("Enter Password");
            Console.ReadLine();
            Console.WriteLine("Success");
            user.Profile = "admin";
            //using a bool to return when the processes has completed.
            return true;
        }
    
    }
}