namespace Crossword
{
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
            Id = idNum;
            Character = c;

        }
    }
}