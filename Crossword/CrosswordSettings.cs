namespace Crossword
{
    class CrosswordSettings
    {
        private int _columns;
        private int _rows;
        private string _title;


        //getters & setters
        public int Columns {
            get => _columns;
            set
            {
                if(value > 0)
                {
                    _columns = value;
                }
            } }
        public int Rows {
            get => _rows; 
            set{
             if(value > 0)
                {
                    _rows = value;
                }   
            } }
        public string Title {
            get => _title;
            set
            {
                _title = value;
            } }

        public CrosswordSettings(string title, int rows, int columns)
        {
            Title = title;
            Rows = rows;
            Columns = columns;
        }

        public static void NewCrossword()
        {
            //todo: add draw for this function
            //this class should hold all the info for a crossword settings class
        }
    }
}