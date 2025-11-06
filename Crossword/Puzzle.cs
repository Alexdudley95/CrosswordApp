namespace Crossword
{
    public static class Puzzle
    {
        //This class will be used to create the crosswords on the screen
        //Should handle the drawing and displaying of the data
        //Implement another class which handles the data side of the crosswords
        //MVC implementation maybe?? 

        private static int[,] puzzleData;
        private static int cursorX = 0;
        private static int cursorY = 0;

        public static void CreateData(int rows, int columns)
        {
            puzzleData = new int[rows, columns];

            //fill array
            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    puzzleData[i, j] = 1;
                }
            }
        
        }

        public static int UpdatePos(int x, int y)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    cursorY--;
                    break;
                case ConsoleKey.DownArrow:
                    cursorY++;
                    break;
                case ConsoleKey.LeftArrow:
                    cursorX--;
                    break;
                case ConsoleKey.RightArrow:
                    cursorX++;
                    break;
                case ConsoleKey.Escape:
                    return 0;
                default:
                    return 3;
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine(cursorX + " : " + cursorY);

            //boundry check for the puzzle to stop cursor going out of range
            if (cursorX > puzzleData.GetLength(0) -1)
            {
                cursorX = 0;
            }
            else if (cursorX < 0)
            {
                cursorX = puzzleData.GetLength(0) -1;
            }

            if (cursorY > puzzleData.GetLength(1) -1)
            {
                cursorY = 0;
            }
            else if (cursorY < 0)
            {
                cursorY = puzzleData.GetLength(1) - 1;
            }

            puzzleData[cursorX, cursorY] = 2;
            return 3;

        }

        //Use x & y as starting location for the puzzle to draw
        public static void DrawPuzzle(int x, int y)
        {
            Console.CursorVisible = false;
            //draw puzzle 

            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    Console.SetCursorPosition(x + i, y + j);
                    if (puzzleData[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (puzzleData[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write("*");
                }
            }


            // Console.WriteLine("");
            // Console.WriteLine("");
            // Console.WriteLine(cursorX + " : " + cursorY);
        }
    }
}