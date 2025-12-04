namespace Crossword
{
    public static class Puzzle
    {
        /// <summary>
        /// This class is used to create & display the grid for the crossword.
        /// Also used for haneling input regarding movement on the grid or escape menu & when user chooses to input word
        /// </summary>
        
        // Below are static ints, this is for the cursor position as. 
        // As this should only really be changed within this class, the attributes are private.
        // There is a public getter for the attributes which is needed for the solver. 
        private static int _cursorX = 0;
        private static int _cursorY = 0;

        public static int CursorX { get => _cursorX; }
        public static int CursorY { get => _cursorY; }

        /// <summary>
        /// Used to create the puzzle data, rows & columns usually come from crossword settings
        /// </summary>
        /// <returns> 2D array of words </returns>
        public static Word[,] CreateData(int rows, int columns)
        {
            Word[,] puzzleData = new Word[rows, columns];

            //fill array
            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    puzzleData[i, j] = new Word('■', i + j, Word.Direction.across);
                }
            }
            return puzzleData;
        }

        /// <summary>
        /// Used to update the position of Cursor & check input 
        /// </summary>
        /// <param name="puzzleData"> 2D array of words </param>
        /// <returns></returns>
        public static int UpdatePos(Word[,] puzzleData)
        {

            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    _cursorX--;
                    break;
                case ConsoleKey.DownArrow:
                    _cursorX++;
                    break;
                case ConsoleKey.LeftArrow:
                    _cursorY--;
                    break;
                case ConsoleKey.RightArrow:
                    _cursorY++;
                    break;
                case ConsoleKey.Enter:
                    return 1;
                case ConsoleKey.Escape:
                    return 2;
                default:
                    return 0;
            }
            BoundryCheck(puzzleData);

            return 0;
        }
        
        public static void ResetCursorPos()
        {
            _cursorX = 0;
            _cursorY = 0;
        }

        //K17
        /// <summary>
        /// Draws the main crossword array
        /// </summary>
        /// <param name="x"> X Location to draw from </param>
        /// <param name="y"> Y Location to draw from </param>
        /// <param name="puzzleData"> 2D array of words </param>
        /// <param name="hideChar"> Set true if characters are to be hidden </param>
        public static void DrawPuzzle(int x, int y, Word[,] puzzleData, bool hideChar)
        {
            Console.CursorVisible = false;


            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                Console.SetCursorPosition(x , y + i);
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    if (_cursorX == i && _cursorY == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (puzzleData[i,j].Character != '■')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    if (hideChar)
                    {
                        Console.Write("■ ");
                    }
                    else
                    {
                    Console.Write(puzzleData[i, j].Character + " ");
                    }
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Checks to ensure the cursor is within the boundaries of the grid.
        /// </summary>
        /// <param name="puzzleData">2D array of words</param>
        public static void BoundryCheck(Word[,] puzzleData)
        {
            //boundry check for the puzzle to stop cursor going out of range
            if (_cursorX >= puzzleData.GetLength(0) - 1)
            {
                _cursorX = puzzleData.GetLength(0) -1 ;
            }
            else if (_cursorX < 0)
            {
                _cursorX = 0;
            }

            if (_cursorY >= puzzleData.GetLength(1) -1)
            {
                _cursorY = puzzleData.GetLength(1) - 1;
            }
            else if (_cursorY < 0)
            {
                _cursorY = 0;
            }
        }
    }
}