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

        public static CrosswordSettings NewCrosswordScreen()
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
            return newCrossword; 
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

        public static void DrawPlayUI(Word[,] puzzleData, CrosswordSettings crossword)
        {
            //print welcome message
            int screenHalf = Console.WindowWidth / 2;
            Console.SetCursorPosition(screenHalf, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Welcome to the crossword creator");


            //right column information
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(screenHalf + 10, 5);
            Console.Write("Title: {0}", crossword.Title + "                ");
            Console.SetCursorPosition(screenHalf + 10, 7);
            Console.Write("Number of rows: {0}", crossword.Rows);
            Console.SetCursorPosition(screenHalf + 10, 8);
            Console.Write("Number of columns {0}", crossword.Columns);
            Console.SetCursorPosition(screenHalf + 10, 9);
            Console.Write("Current selected row: {0}", Puzzle.CursorX.ToString() + " ");
            Console.SetCursorPosition(screenHalf + 10, 10);
            Console.Write("Current selected column: {0}", Puzzle.CursorY.ToString() + " ");

            Console.SetCursorPosition(screenHalf + 10, 12);

            //word specific information 
            string clue = puzzleData[Puzzle.CursorX, Puzzle.CursorY].Clue;
            //easy way to remove any left over info
            if(clue == "")
            {
                clue = " ";
            }
            Console.Write("Clue: {0}                              ", clue);
            Console.SetCursorPosition(screenHalf + 10, 13);
            Console.Write("Word: {0}                    ", puzzleData[Puzzle.CursorX, Puzzle.CursorY].CurrentWord);
            Console.SetCursorPosition(screenHalf + 10, 14);
            Console.Write("Direction: {0}   ", puzzleData[Puzzle.CursorX, Puzzle.CursorY].wordDirection.ToString());


            //print instructions 
            Console.SetCursorPosition(10, 25);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Use arrow keys to navigate, enter to input new word, escape to go back to dashboard");
        }


        public static void DrawInputWordUI()
        {
            Console.Clear();
            int screenHalf = Console.WindowWidth / 2;
            Console.SetCursorPosition(screenHalf, 2);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Welcome to the crossword creator");

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(screenHalf + 10, 5);
            Console.Write("Please Input word: ");
            Console.SetCursorPosition(screenHalf + 10, 7);
            Console.Write("Please Input Direction: (A)cross : (D)own");
            Console.SetCursorPosition(screenHalf + 10, 9);
            Console.Write("Please input clue for word:");
            
        }
    }
}