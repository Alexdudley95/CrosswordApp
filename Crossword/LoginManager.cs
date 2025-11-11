namespace Crossword
{
    public class LoginManager
    {
        //<summary>
        //This class is used for all user management within the system.
        //</summary>

        public static List<User> listOfUsers = new List<User>();

        public static void CheckLoginStatus()
        {
            if(listOfUsers.Count == 0)
            {
                Console.WriteLine("File NOT loaded, please use 'admin' and 'password' to login. Press enter to continue");
                CreateAdminLogin();
                FileManager.PopulateExisitngUsers();
                Console.ReadKey();
            }
            else
            {
                //if there are no users available, the system generates the admin login
                Console.WriteLine("File(s) loaded successfully. Press enter to continue");
                Console.ReadKey();
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
                        if (Admin.RegisterNewUser())
                        {
                            return 0;
                        }
                        break;
                    }
                    Console.Write("Error: not an admin");
                    break;
                case ConsoleKey.C:
                    if (user.Profile == User.UserLevels.admin)
                    {
                        if (Admin.ChangeExisitngUser())
                        {
                            return 0;
                        }
                        break;
                    }
                    Console.Write("Error: not an admin");
                    break;
                case ConsoleKey.Escape:
                    return 0;
            }
            return 1;
        }
        
        public static bool CheckLogin(string uName, string pWord, User user)
        {
            for (int i = 0; i < listOfUsers.Count; i++)
            {
                if (uName == listOfUsers[i].Username && pWord == listOfUsers[i].Password)
                {
                    user.Profile = listOfUsers[i].Profile;
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
            string pWord = GetPasswordHiddenByChar();
            Console.WriteLine("");
            if (CheckLogin(uName, pWord, user))
            {
                Console.WriteLine("Success, Press enter to continue.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Username or password not recognised, Press enter to continue.");
                Console.ReadKey();
                LoginScreen(user);
            }
            //using a bool to return when the processes has completed.
            return true;
        }
        public static void DrawLoginSubMenu()
        {
            DrawDimmedPlayerDashboard();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(21, 5);
            Console.WriteLine("(L)og in");
            Console.SetCursorPosition(21, 6);
            Console.WriteLine("(R)egister");
            Console.SetCursorPosition(21, 7);
            Console.WriteLine("(C)hange Role");
        }

        public static bool CreateAdminLogin()
        {
            User admin = new User();
            admin.Username = "admin";
            admin.Password = "password";
            admin.Profile = User.UserLevels.admin;

            FileManager.SaveUsersToJson(admin);
            return true;
        }

        //provided by content on Blackboard. 
        public static string GetPasswordHiddenByChar()
        {
            string password = string.Empty;
            ConsoleKeyInfo keyInfo;

            Console.WriteLine("Enter your password");
            do
            {
                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password[0..^1];
                    Console.Write("\b \b");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            return password;
        }

        public static void DrawDimmedPlayerDashboard()
        {
            Console.SetCursorPosition(5, 2);
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Welcome to crosswords");
            Console.CursorVisible = false;

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("");

            Console.WriteLine("Create     Solve     Login    Quit  ");   
        }
    }
}