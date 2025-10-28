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

            //Check current level of the user.
            Login.CheckLoginStatus(user);
            Console.Clear();

            DrawPlayerDashboard();

            while (true)
            {
                if(currentWindow == 0)
                {
                    //pass user to Login helper class
                    currentWindow = Login.Dashboard(user);
                }
                else if (currentWindow == 1)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.L:
                            if (Login.LoginScreen(user))
                            {
                                //do this once user has logged in
                                currentWindow = 0;
                                Console.Clear();
                                DrawPlayerDashboard();
                            }
                            break;
                        case ConsoleKey.R:
                            //change this
                            if (Login.CheckLoginStatus(user) == "admin")
                            {
                                Admin.RegisterNewUser();
                            }
                            else
                            {
                                Console.Write("Error: not an admin");
                            }
                            break;
                        case ConsoleKey.C:
                            Console.Write("Change user");
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


        //Nuget package installed, use below for saving
        //string json = JsonConvert.SerializeObject();
    }
}