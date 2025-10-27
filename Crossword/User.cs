namespace Crossword
{
    public class User
    {
        //private properties
        //start the login status as "none" 
        private string _profile = "none";


        // using consts to ensure these aren't changed
        const String _loginStatusPlayer = "player";
        const String _loginStatusAdmin = "admin";

        //getters and settings
        public  string Profile
        {
            get => _profile;
            set
            {
                //ensure the value can only be that of a cost
                if (value == _loginStatusPlayer || value == _loginStatusAdmin)
                {
                    _profile = value;
                }
            }
        }

        public User()
        {
            _profile = "none";
        }

    }
}