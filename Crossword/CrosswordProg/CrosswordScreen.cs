namespace Crossword
{
    /// <summary>
    /// Screen manager for handeling the main interactions between crossword settings & puzzle classes
    /// </summary>
    class CrosswordScreen
    {      
        /// <summary>
        /// Creates a puzzle by using CrosswordSettings.NewCrosswordScreen()
        /// This data is then passed into an array using Puzzle.CreateData()
        /// A while loop is then used to update the screen.
        /// If this function completes, the user is returned to dashboard. 
        /// </summary>
        public static void PopulatePuzzle()
        {
            Puzzle.ResetCursorPos();
            CrosswordSettings.DrawNewCrosswordScreen();
            CrosswordSettings newCrossword = CrosswordSettings.NewCrosswordScreen();

            //newcrosssword can only return null if the user input was incorrect.
            if(newCrossword == null)
            {
                Console.Clear();
                Console.WriteLine("Error: Rows or columns need to be between 1 & 16.");
                Console.WriteLine("Please try again.");
                Console.ReadKey();
                return;
            }
            Word[,] puzzleData = Puzzle.CreateData(newCrossword.Rows, newCrossword.Columns);
            Console.Clear();

            DrawPlayScreen(puzzleData, newCrossword, false);
            while (true)
            {
                switch (UpdatePuzzle(puzzleData))
                {
                    case 1:
                        UserInputWord(puzzleData, newCrossword);
                        break;
                    case 2:
                        EscapeMenu(newCrossword, puzzleData);
                        return;
                }
                DrawPlayScreen(puzzleData, newCrossword, false);
            }
        }

        //calling this function this way incase other things need updating in the future.
        // could just be used with Puzzle.updatePos(puzzleData)
        public static int UpdatePuzzle(Word[,] puzzleData)
        {
            return Puzzle.UpdatePos(puzzleData);
        }
        /// <summary>
        /// This draws both the array of words at the left of the screen and information on the right of the screen.
        /// </summary>
        /// <param name="hidehcar">Setting this to true doesn't display the characters</param>
        public static void DrawPlayScreen(Word[,] puzzleData, CrosswordSettings crossword, bool hidehcar)
        {
            Puzzle.DrawPuzzle(10, 5, puzzleData, hidehcar);
            CrosswordSettings.DrawPlayUI(puzzleData, crossword);
        }
        /// <summary>
        /// This currently saves the crossword straight to a Json file.
        /// </summary>
        public static void EscapeMenu(CrosswordSettings crossword, Word[,] puzzleData)
        {
            Console.SetCursorPosition(25, 23);
            Console.WriteLine("Press escape to quit, S to save & quit");
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    return;

                case ConsoleKey.S:
                    FileManager.SaveCrosswordToJson(crossword, puzzleData);
                    return;
            }
        }
        /// <summary>
        /// Main function for inputting words in the crossword creator. When called, will take inputted word, direction & clue - check they are the correct length map them into the 2D array
        /// </summary>
        public static void UserInputWord(Word[,] puzzleData, CrosswordSettings crossword)
        {
            Console.Clear();
            CrosswordSettings.DrawInputWordUI();
            Puzzle.DrawPuzzle(10, 5, puzzleData, false);
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