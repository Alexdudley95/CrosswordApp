using System.IO;
namespace Crossword
{
    class Crossword
    {
        public static void Main(string[] args)
        {
            //new user every time program runs - ensure users have to login
            User user = new User();

            //0 = Dashboard, 1 = Login Submenu,
            //use of a magic number - could do with being changed here
            int currentWindow = 0;

            //check if the directories being used exist. if not create it
            if (!FileManager.CheckUsersDirExists())
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\users");
            }
            if (!FileManager.CheckCrosswordsDirExists())
            {
                
                Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\crosswords");
            }

            //check if there are previous users saved on system and loads them into a list
            FileManager.PopulateExisitngUsers();
            // check list if there are any enteries 
            LoginManager.CheckLoginStatus();

            //there's probably a way of having this as a do while until escape is pressed
            //however, I'm not smart enough for this atm.  
            while (true)
            {   
                //this needs to be a switch case
                if (currentWindow == 0)
                {
                    Console.Clear();
                    DrawPlayerDashboard();
                    //pass user to Login helper class
                    currentWindow = Dashboard(user);
                }
                else if (currentWindow == 1)
                {
                    currentWindow = LoginManager.LoginSubMenu(user);
                }

            }
        }

        /// Main dashboard below
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
                        break;
                    }
                    Console.Clear();
                    CrosswordScreen.PopulatePuzzle();
                    break;
                case ConsoleKey.S:
                    if (user.Profile == User.UserLevels.admin || user.Profile == User.UserLevels.player)
                    {
                        Console.WriteLine("Solve crossword");
                        break;
                    }
                    Console.WriteLine("Please login first");
                    break;
                case ConsoleKey.L:
                    LoginManager.DrawLoginSubMenu();
                    return 1;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
            return 0;
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
    }
}