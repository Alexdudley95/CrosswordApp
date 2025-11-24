namespace Crossword
{
    class Admin
    {
        //<summary>
        //Helper class
        //This class will be used for Admin only commands to help seperate the code from Program.cs
        //The class functions will only be called when the system has confirmed the user is an admin       
        //</summary>
        
        /// <summary>
        /// Displays and prompts the user for new user details, checks against aready existing users
        /// returns true when process is finished
        /// </summary>
        /// <returns>True when process is finished</returns>
        public static bool RegisterNewUser()
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            string newUserUName = Console.ReadLine()!.ToString();
            if (FileManager.CheckUserExists(newUserUName))
            {
                Console.WriteLine("Username already exists, please ensure username is unique & try again. Press enter to continue.");
                Console.ReadLine();
                return true;
            }else if (newUserUName == "")
            {
                Console.WriteLine("Error : Please enter a valid username");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                return true;
            }
            string newUserPWord = LoginManager.GetPasswordHiddenByChar();
            if(newUserPWord == "")
            {
                Console.WriteLine("Error : Please enter a valid password");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                return true;
            }
            Console.WriteLine("");
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
                Console.WriteLine("User level not inputted correctly. User has been granted no access");
                Console.WriteLine("Please amend user level via the login menu as an admin. Press enter to continue");
                user.Profile = User.UserLevels.none;
                Console.ReadLine();
            }

            FileManager.SaveUsersToJson(user);
            FileManager.PopulateExisitngUsers();
            return true;
        }
        /// <summary>
        /// Displays and prompts the user for existing user details, checks against aready existing users
        /// returns true when process is finished
        /// </summary>
        /// <returns>True when process is finished</returns>
        public static bool ChangeExisitngUser()
        {
            Console.Clear();
            Console.WriteLine("Enter username");
            //null ignore as we have an if statement to handle null below
            string uName = Console.ReadLine()!;

            if(uName == "admin")
            {
                Console.WriteLine("Cannot modify user : Admin");
                Console.ReadKey();
                return true;
            }else if(uName == "")
            {
                Console.WriteLine("Error: Username cannot be null");
                Console.ReadKey();
                return true;
            }

            if (FileManager.CheckUserExists(uName))
            {
                User userToEdit = FileManager.ReturnUserFromJson(Directory.GetCurrentDirectory() + "\\Users\\" + uName);
                Console.WriteLine("Enter new access level for username: admin/player");
                //null ignore as if statement handles this. to lower to ensure easy comparison
                string uLevel = Console.ReadLine()!.ToLower();
                if(uLevel == "admin")
                {
                    userToEdit.Profile = User.UserLevels.admin;
                    FileManager.SaveUsersToJson(userToEdit);
                    FileManager.PopulateExisitngUsers();
                }else if (uLevel == "player")
                {
                    userToEdit.Profile = User.UserLevels.player;
                    FileManager.SaveUsersToJson(userToEdit);
                    FileManager.PopulateExisitngUsers();
                }
                else
                {
                    Console.WriteLine("Error, no changes made. Press enter to continue");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("User does not exists, please double check and try again. Press enter to continue");
                Console.ReadLine();
            }

            return true;      
        }
    }
}