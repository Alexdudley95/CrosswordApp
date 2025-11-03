namespace Crossword
{
    class Admin
    {
        //<summary>
        // Helper class
        //This class will be used for Admin only commands to help seperate the code from Program.cs
        //The class functions will only be called when the system has confirmed the user is an admin       
        //</summary>

        public static bool RegisterNewUser()
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            string newUserUName = Console.ReadLine()!.ToString();
            Console.WriteLine("Enter password");
            string newUserPWord = Console.ReadLine()!.ToString();
            Console.WriteLine("Enter user level: admin / player");
            string newUserlevel = Console.ReadLine()!.ToString();


            User user = new User();
            user.Username = newUserUName;
            user.Password = newUserPWord;
            if (newUserlevel == "admin")
            {
                user.Profile = User.UserLevels.admin;
            }
            else if (newUserlevel == "player")
            {
                user.Profile = User.UserLevels.player;
            }
            else
            {
                Console.WriteLine("User level not inputted correctly");
                Console.WriteLine("Please amend user level via the admin console");
                user.Profile = User.UserLevels.none;
            }

            FileManager.SaveUsersToJson(user);
            FileManager.PopulateExisitngUsers();
            return true;
        }

        public static void ChangeExisitngUser()
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            string uName = Console.ReadLine()!.ToString();
        }
    
    }
}