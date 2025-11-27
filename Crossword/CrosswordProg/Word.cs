namespace Crossword
{
    /// <summary>
    /// The word class is used to store char, word, clue & direction. 
    /// The 2D array is populated with these objects.
    /// </summary>
    public class Word
    {
        //private attributes
        private  char _character;
        private int _id;
        private string _clue;
        private string _word;
        public enum Direction
        {
            across,
            down,
        }
        //getters setters
        public char Character
        {
            get => _character;
            set
            {
                _character = value;
            }
        }    
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        
        public string Clue
        {
            get => _clue;
            set
            {
                if (value != "")
                {
                    _clue = value;
                }
            }
        }
        public bool CorrectGuess;
        public Direction wordDirection { get; set; }
        public string CurrentWord {
            get => _word; 
            set
            {
                if(value != "")
                {
                    _word = value;
                }
            }
        }
        public Word(char c, int idNum, Direction dir)
        {
            //we assign the ID but do not use it currently. 
            //added for future use.
            Id = idNum;
            Character = c;
            CorrectGuess = false;

        }
    }
}