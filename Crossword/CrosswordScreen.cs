namespace Crossword
{
    /// <summary>
    /// Screen manager for handeling the main interactions between crossword settings & puzzle classes
    /// </summary>
    class CrosswordScreen
    {   
        public static void PopulatePuzzle()
        {
            CrosswordSettings.DrawNewCrosswordScreen();
            CrosswordSettings newCrossword = CrosswordSettings.NewCrosswordScreen();
            Word[,] puzzleData = Puzzle.CreateData(newCrossword.Rows, newCrossword.Columns);
            Console.Clear();

            while (true)
            {
                switch (UpdatePuzzle(puzzleData))
                {
                    case 1:
                        UserInputWord(puzzleData, newCrossword);
                        break;
                    case 2:
                        Console.Write("You cannot escape");
                        break;
                }
                DrawPlayScreen(puzzleData, newCrossword);

                //UpdatePuzzle(puzzleData);
            }
        }

        public static int UpdatePuzzle(Word[,] puzzleData)
        {
            return  Puzzle.UpdatePos(puzzleData);
        }
        public static void DrawPlayScreen(Word[,] puzzleData, CrosswordSettings crossword)
        {
            Puzzle.DrawPuzzle(10, 5, puzzleData);
            CrosswordSettings.DrawPlayUI(crossword);

        }

        public static void UserInputWord(Word[,] puzzleData, CrosswordSettings crossword)
        {
            Console.Clear();
            CrosswordSettings.DrawInputWordUI();
            Puzzle.DrawPuzzle(10, 5, puzzleData);
            string inputtedWord = Console.ReadLine();
            string directionWord = Console.ReadLine().ToUpper();

            char[] arrayInpuutedWord = inputtedWord.ToCharArray();

            if (arrayInpuutedWord.Length < crossword.Rows - Puzzle.CursorX || arrayInpuutedWord.Length < crossword.Columns - Puzzle.CursorY)
            {
                for (int i = 0; i < arrayInpuutedWord.Length; i++)
                {
                    switch (directionWord)
                    {
                        //below are swapped because using a 2D array swaps the x & y
                        case "A":
                            puzzleData[Puzzle.CursorX, Puzzle.CursorY + i].Character = arrayInpuutedWord[i];
                            break;
                        case "D":
                            puzzleData[Puzzle.CursorX + i, Puzzle.CursorY].Character = arrayInpuutedWord[i];
                            break;
                    }
                }
            }
            Console.Clear();
        }    
    }
}