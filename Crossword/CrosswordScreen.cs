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

            DrawPlayScreen(puzzleData, newCrossword);
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
            }
        }

        public static int UpdatePuzzle(Word[,] puzzleData)
        {
            return  Puzzle.UpdatePos(puzzleData);
        }
        public static void DrawPlayScreen(Word[,] puzzleData, CrosswordSettings crossword)
        {
            Puzzle.DrawPuzzle(10, 5, puzzleData);
            CrosswordSettings.DrawPlayUI(puzzleData, crossword);

        }

        public static void UserInputWord(Word[,] puzzleData, CrosswordSettings crossword)
        {
            Console.Clear();
            CrosswordSettings.DrawInputWordUI();
            Puzzle.DrawPuzzle(10, 5, puzzleData);
            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 6);
            string inputtedWord = Console.ReadLine();
            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 8);
            string directionWord = Console.ReadLine().ToUpper();
            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 10);
            string inputtedClue = Console.ReadLine();

            char[] arrayInpuutedWord = inputtedWord.ToCharArray();

            //checks direction via switch case, then checks if word can fit in space, if yes, populates the objects with data
            //if not, displays error message and calls itself again.
            switch (directionWord){
                case "A":
                    if (arrayInpuutedWord.Length < (crossword.Columns - Puzzle.CursorY) + 1)
                    {
                        for (int i = 0; i < arrayInpuutedWord.Length; i++)
                        {
                            puzzleData[Puzzle.CursorX, Puzzle.CursorY + i].Character = arrayInpuutedWord[i];
                            puzzleData[Puzzle.CursorX, Puzzle.CursorY + i].Clue = inputtedClue;
                            puzzleData[Puzzle.CursorX, Puzzle.CursorY + i].CurrentWord = inputtedWord;
                            puzzleData[Puzzle.CursorX, Puzzle.CursorY + i].wordDirection = Word.Direction.across;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(25, 25);
                        Console.Write("Word too long, please try again");
                        Console.ReadLine();
                        UserInputWord(puzzleData, crossword);
                    }
                    break;
                case "D":
                    if (arrayInpuutedWord.Length < (crossword.Rows - Puzzle.CursorX) + 1)
                    {
                        for (int i = 0; i < arrayInpuutedWord.Length; i++)
                        {
                            puzzleData[Puzzle.CursorX + i, Puzzle.CursorY].Character = arrayInpuutedWord[i];
                            puzzleData[Puzzle.CursorX + i, Puzzle.CursorY].Clue = inputtedClue;
                            puzzleData[Puzzle.CursorX + i, Puzzle.CursorY].CurrentWord = inputtedWord;
                            puzzleData[Puzzle.CursorX + i, Puzzle.CursorY].wordDirection = Word.Direction.down;
                        }
                    }
                    else
                    {
                        Console.SetCursorPosition(25, 25);
                        Console.Write("Word too long, please try again");
                        Console.ReadLine();
                        UserInputWord(puzzleData, crossword);
                    }
                    break;
            }
            Console.Clear();
        }    
    }
}