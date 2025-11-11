namespace Crossword
{
    public class Word
    {
        //private attributes
        private  char _character;
        private  int _id;
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
        public int Id { 
            get => _id;
            set
            {
                _id = value;
            } }
        
        public Word(char c, int idNum, Direction dir)
        {
            Id = idNum;
            Character = c;

        }
    }
}