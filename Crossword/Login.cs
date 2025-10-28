namespace Crossword
{
    class Login
    {

        //<summary>
        //This class is used for all user management within the system.
        //</summary>

        //TODO: 

        private static List<string> loginDetails = new List<string>()
        {
            //split this by " | " to return username, password & login level
            //this needs to be read from a JSON file and added to the list 
            "admin | password | admin",
            "player | password | player"
        };


        //change this later = should return enum 
        public static string CheckLoginStatus(User user)
        {
            switch (user.Profile)
            {
                case User.UserLevels.admin:
                    return "admin";
                case User.UserLevels.player:
                    return "player";
                default:
                    Console.WriteLine("File NOT loaded, please use 'admin' and 'password' to login. Press enter to continue");
                    Console.ReadKey();
                    return "";
            }
        }
        public static int Dashboard(User user)
        {
            //using console key as it is not case dependant   
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.C:
                    if (user.Profile != User.UserLevels.admin)
                    {
                        Console.WriteLine("Admin login required");
                    }
                    else
                    {
                        Console.Clear();
                        Create.DrawCrossword();
                    }
                    break;
                case ConsoleKey.S:
                    if (user.Profile == User.UserLevels.admin || user.Profile == User.UserLevels.player)
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

        //This function splits the item of the logindetails list into a string array, 
        // index 0 will always be username & [1] will always be password
        public static bool checkLogin(string uName, string pWord)
        {   
            for(int i = 0; i < loginDetails.Count(); i++)
            {
                string[] userNameCheck = loginDetails[i].Split(" | ");
                if (uName == userNameCheck[0] && pWord == userNameCheck[1])
                {
                    return true;
                }
            }
            return false;
        }
        
        public static bool LoginScreen(User user)
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            string uName = Console.ReadLine().ToString();
            Console.WriteLine("Enter Password");
            string pWord = Console.ReadLine().ToString();
            if(checkLogin(uName, pWord))
            {
                Console.WriteLine("Success");
                Console.ReadKey();
                user.Profile = User.UserLevels.admin;
            }
            else
            {
                Console.WriteLine("Username or password not recognised");
                Console.ReadKey();
                LoginScreen(user);
            }

            //using a bool to return when the processes has completed.
            return true;
        }
        
        public static void DrawLoginSubMenu()
        {
            Console.SetCursorPosition(22, 5);
            Console.WriteLine("(L)og in");
            Console.SetCursorPosition(22, 6);
            Console.WriteLine("(R)egister");
            Console.SetCursorPosition(22, 7);
            Console.WriteLine("(C)hange Role");
        }

    }
}