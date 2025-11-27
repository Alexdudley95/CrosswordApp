namespace Crossword
{
    public static class Puzzle
    {
        //This class will be used to create the crosswords on the screen
        //Should handle the drawing and displaying of the data
        //Implement another class which handles the data side of the crosswords
        //MVC implementation maybe?? 

        private static int _cursorX = 0;
        private static int _cursorY = 0;

        public static int CursorX { get => _cursorX; }
        public static int CursorY { get => _cursorY; }

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

        //Use x & y as starting location for the puzzle to draw
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