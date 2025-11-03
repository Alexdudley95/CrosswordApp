using Newtonsoft.Json;
namespace Crossword
{
    class FileManager
    {
        private static string dir = Directory.GetCurrentDirectory() + "\\users";

        public static void PopulateExisitngUsers()
        {
            //looks at saved users in the dir and adds them to login manager list.
            string[] fileCount = Directory.GetFiles(dir);
            for (int i = 0; i < fileCount.Length; i++)
            {
                string[] splitFileName = fileCount[i].Split(".");
                LoginManager.listOfUsers.Add(ReturnUserFromJson(splitFileName[0]));
            }
        }
        
        // need to do a dir check here to ensure a dir is available and if not, create it.
        public static void SaveUsersToJson(User user)
        {
            using (StreamWriter file = File.CreateText( dir +"\\" + user.Username + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, user);
                }
        }

        public static User ReturnUserFromJson(string userName)
        {
            //Takes the file and deserializes the JSON
            using (StreamReader file = File.OpenText(userName + ".json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                User user = (User)serializer.Deserialize(file, typeof(User))!;
                //                                              Null ignore ^
                
                return user;
            }
        }


    }
}