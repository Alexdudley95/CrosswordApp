namespace Crossword
{
    class Admin
    {
        //<summary>
        // Helper class
        //This class will be used for Admin only commands to help seperate the code from Program.cs
        //The class functions will only be called when the system has confirmed the user is an admin       
        //</summary>

        public static void RegisterNewUser()
        {
            Console.Clear();
            Console.Write("Enter username");
            string newUserUName = Console.Read()!.ToString();
            Console.Write("Enter password");
            string newUserPWord = Console.Read()!.ToString();
            Console.Write("Enter user level: admin / player");
            string newUserlevel = Console.Read()!.ToString();

        }

        public static void ChangeExisitngUser()
        {
            Console.Clear();
            Console.Write(" :D Hi!");
        }
    
    }
}