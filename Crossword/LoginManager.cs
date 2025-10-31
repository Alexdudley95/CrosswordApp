namespace Crossword
{
    class LoginManager
    {
        //<summary>
        //This class is used for all user management within the system.
        //</summary>
        /// 
        /// 
        private static List<string> loginDetails = new List<string>()
        {
            //split this by " | " to return username, password & login level
            //this needs to be read from a JSON file and added to the list 
            // THIS IS BEING CHANGED TO STORE USER OBJECTS 
            "admin | password | admin",
            "player | password | player"
        };

        // create a constructor for class where it creates a new list of users when instanced
        // this is for registering new users 
        public List<User> ListOfUsers{ get; set; }
        public LoginManager()
        {
            this.ListOfUsers = new List<User>();
        }

        //change this later = should return enum 
        // is this redundant due to getter and setting in User.Profile? 
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

        public static int LoginSubMenu(User user)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.L:
                    if (LoginScreen(user))
                    {
                        return 0;
                    }
                    break;
                case ConsoleKey.R:
                    if (user.Profile == User.UserLevels.admin)
                    {
                        Admin.RegisterNewUser();
                        break;
                    }
                    Console.Write("Error: not an admin");
                    break;
                case ConsoleKey.C:
                    if (user.Profile == User.UserLevels.admin)
                    {
                        Admin.ChangeExisitngUser();
                        break;
                    }
                    Console.Write("Error: not an admin");
                    break;
            }
            return 1;
        }


        //This function splits the item of the logindetails list into a string array, 
        //index 0 will always be username & [1] will always be password
        public static bool CheckLogin(string uName, string pWord, User user)
        {
            for (int i = 0; i < loginDetails.Count(); i++)
            {
                string[] userNameCheck = loginDetails[i].Split(" | ");
                if (uName == userNameCheck[0] && pWord == userNameCheck[1])
                {
                    string level = userNameCheck[2];
                    //probably not the best way to do this but will do for now.
                    if (level == "admin")
                    {
                        user.Profile = User.UserLevels.admin;
                    } else if (level == "player")
                    {
                        user.Profile = User.UserLevels.player;
                    }
                    return true;
                }
            }
            return false;
        }
        public static bool LoginScreen(User user)
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            //using the null ignore here 
            string uName = Console.ReadLine()!.ToString();
            Console.WriteLine("Enter Password");
            string pWord = Console.ReadLine()!.ToString();
            if (CheckLogin(uName, pWord, user))
            {
                Console.WriteLine("Success");
                Console.ReadKey();
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
            Console.SetCursorPosition(21, 5);
            Console.WriteLine("(L)og in");
            Console.SetCursorPosition(21, 6);
            Console.WriteLine("(R)egister");
            Console.SetCursorPosition(21, 7);
            Console.WriteLine("(C)hange Role");
        }



    }
}