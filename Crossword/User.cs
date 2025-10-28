namespace Crossword
{
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


        //getters and settings
        public  UserLevels Profile
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

        public User()
        {
            _profile = UserLevels.none;
        }

    }
}