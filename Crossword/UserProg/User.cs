namespace Crossword
{
    /// <summary>
    /// User class holds account information like user level, username & password. 
    /// </summary>
    public class User
    {
        //enum's to prevent changes 
        public enum UserLevels
        {
            none,
            player,
            admin
        }
        //start the login status as "none" 
        private UserLevels _profile = UserLevels.none;

        private string _username;
        private string _password;


        //getters and settings
        public UserLevels Profile
        {
            get => _profile;
            set
            {
                //ensure the value can only be that of a enum
                if (value == UserLevels.player || value == UserLevels.admin)
                {
                    _profile = value;
                }
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                if (value != null)
                {
                _username = value;
                } 
            }
        }    
        public string Password {
            get => _password;
            set
            {
                if(value != null)
                {
                    _password = value;
                }
            } }
        //constructor
        public User()
        {
            _profile = UserLevels.none;
        }

    }
}