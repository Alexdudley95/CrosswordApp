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

        public static int NewCrosswordScreen()
        {
            DrawNewCrosswordScreen();
            Console.CursorVisible = true;
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, 6);
            string titleInput = Console.ReadLine()!.ToString();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, 7);
            int rowsInput = Convert.ToInt32(Console.ReadLine());
            Console.SetCursorPosition((Console.WindowWidth / 2) - 8, 8);
            int columnsInput = Convert.ToInt32(Console.ReadLine());

            CrosswordSettings newCrossword = new CrosswordSettings(titleInput, rowsInput, columnsInput);
            //this class should hold all the info for a crossword settings class
            Puzzle.CreateData(newCrossword.Rows, newCrossword.Columns);
            return 3;
        }

        public static void DrawNewCrosswordScreen()
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 9, 5);
            Console.WriteLine("Create");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 15, 6);
            Console.WriteLine("Title:");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 14, 7);
            Console.WriteLine("Rows: ");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 17, 8);
            Console.WriteLine("Columns: ");
        }
    }
}