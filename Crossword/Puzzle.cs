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

        public static Word[,] CreateData(int rows, int columns)
        {
            Word[,] puzzleData = new Word[rows, columns];

            //fill array
            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    puzzleData[i, j] = new Word('#', i + j, Word.Direction.across);
                }
            }
            // while(true)
            // {
            //     DrawPuzzle(5, 5, puzzleData);
            //     UpdatePos();
            //     boundryCheck(puzzleData);
            // }
            return puzzleData;
        }

        public static void UpdatePos()
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
            }
        }

        //Use x & y as starting location for the puzzle to draw
        public static void DrawPuzzle(int x, int y, Word[,] puzzleData)
        {
            Console.CursorVisible = false;
            //draw puzzle 
            //not set to an instance of an object?? 
            for (int i = 0; i < puzzleData.GetLength(0); i++)
            {
                for (int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    Console.SetCursorPosition(x + i, y + j);


                    if (cursorX == i && cursorY == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(puzzleData[i, j].Character);
                }
            }
        }
        
        public static void BoundryCheck(Word[,] puzzleData)
        {
            //boundry check for the puzzle to stop cursor going out of range
            if (cursorX > puzzleData.GetLength(0) - 1)
            {
                cursorX = 0;
            }
            else if (cursorX < 0)
            {
                cursorX = puzzleData.GetLength(0) - 1;
            }

            if (cursorY > puzzleData.GetLength(1) - 1)
            {
                cursorY = 0;
            }
            else if (cursorY < 0)
            {
                cursorY = puzzleData.GetLength(1) - 1;
            }
        }
    }
}