using Newtonsoft.Json;
namespace Crossword
{
    class FileManager
    {
        private static User admin = new User();

        private static List<User> loginDetails = new List<User>()
        {

        };


        
        // This needs to be changed to create a dir for users instead of storing to a list of users
        // users then can then be retrieved and added to the list at a later time
        // this would mean that each user would have a file dedicated to that object
        // this is much easier to handle than seralizing and de-serlizing a list of objects.
        public static void SaveUsersToJson()
        {
            // admin.Password = "Test";
            // admin.Username = "admin";
            // admin.Profile = User.UserLevels.admin;

            using (StreamWriter file = File.CreateText( Directory.GetCurrentDirectory() + "\\users\\" + admin.Username + ".json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, admin);
                }
        }

        public static User ReturnUserFromJson()
        {
            //User user = JsonConvert.DeserializeObject<User>(File.ReadAllText("LoginDetails.json"));
            //Takes the file and deserializes the JSON 
            using (StreamReader file = File.OpenText("LoginDetails.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                List<User> user = new List<User>{
                    (User)serializer.Deserialize(file, typeof(User))
                };
                Console.Write(user[0].Username);
                Console.Write(user[0].Password);
                Console.Write(user[0].Profile);
                return user[0];
            }
        }


    }
}