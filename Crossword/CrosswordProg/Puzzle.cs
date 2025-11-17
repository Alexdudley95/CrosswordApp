namespace Crossword
{
    public static class Puzzle
    {
        //This class will be used to create the crosswords on the screen
        //Should handle the drawing and displaying of the data
        //Implement another class which handles the data side of the crosswords
        //MVC implementation maybe?? 

        private static int cursorX = 0;
        private static int cursorY = 0;

        public static int CursorX { get => cursorX; }
        public static int CursorY { get => cursorY; }

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
                    cursorX--;
                    break;
                case ConsoleKey.DownArrow:
                    cursorX++;
                    break;
                case ConsoleKey.LeftArrow:
                    cursorY--;
                    break;
                case ConsoleKey.RightArrow:
                    cursorY++;
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
            cursorX = 0;
            cursorY = 0;
        }

        //Use x & y as starting location for the puzzle to draw
        public static void DrawPuzzle(int x, int y, Word[,] puzzleData, bool hidecar)
        {
            Console.CursorVisible = false;


            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                Console.SetCursorPosition(x , y + i);
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    if (cursorX == i && cursorY == j)
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
                    if (hidecar)
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
            if (cursorX >= puzzleData.GetLength(0) - 1)
            {
                cursorX = puzzleData.GetLength(0) -1 ;
            }
            else if (cursorX < 0)
            {
                cursorX = 0;
            }

            if (cursorY >= puzzleData.GetLength(1) -1)
            {
                cursorY = puzzleData.GetLength(1) - 1;
            }
            else if (cursorY < 0)
            {
                cursorY = 0;
            }
        }
    }
}