namespace Crossword
{
    class Solver
    {
        
        //static attribute here - we're only every going to have one of these loaded into the system at once. 
        //private as I only want to mutate the var from this class
        //private static Word[,] solverCopy;
        /// <summary>
        /// loads the crossword from a json file. always checks the crosswords directory. If does not exist, returns null.
        /// copies that crossword into the internal copy variable for solving later
        /// </summary>
        /// <param name="fileName">filename of the crossword </param>
        public static CrosswordSaver LoadCrossword(string fileName)
        {
            CrosswordSaver saver;
            try
            {
                saver = FileManager.ReturnCrosswordFromJson(Directory.GetCurrentDirectory() + @"\\Crosswords\\" + fileName);
                
            }
            catch (Exception e)
            {
                Console.WriteLine("No crossword file exists: " + e);
                saver = null!;
            }
            return saver!;
        }
        /// <summary>
        /// Primary class used for displaying the solver
        /// </summary>
        public static void DrawSolver(Word[,] puzzleData, CrosswordSettings crosswordSettings)
        {
            Word[,] solverCopy = Puzzle.CreateData(crosswordSettings.Rows, crosswordSettings.Columns);

            CrosswordSettings.DrawPlayUI(solverCopy, crosswordSettings, false);
            DrawSolverScreen(10, 5, solverCopy, puzzleData);
            while (true)
            {
                switch (CrosswordScreen.UpdatePuzzle(solverCopy))
                {
                    case 1:
                        UserInputGuess(solverCopy, puzzleData);
                        CheckGuesses(solverCopy, puzzleData);
                        break;
                    case 2:
                        // probably need to remove this as it has a save option and would save over the created crossword
                        CrosswordScreen.EscapeMenu(crosswordSettings, solverCopy);
                        return;
                }

            CrosswordSettings.DrawPlayUI(solverCopy, crosswordSettings, false);
            DrawSolverScreen(10, 5, solverCopy, puzzleData);
            }
        }

        /// <summary>
        /// Used to input a guess into the copied Word[,] array
        /// </summary>
        public static void UserInputGuess(Word[,] solverCopy, Word[,] puzzleData)
        {
            Console.Clear();
            CrosswordSettings.DrawInputWordUI();
            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 6);
            string inputtedWord = Console.ReadLine();
            char[] arrayInpuutedWord = inputtedWord.ToCharArray();

            if(puzzleData[Puzzle.CursorX, Puzzle.CursorY].wordDirection == Word.Direction.across)
            {
                for(int i =0; i < arrayInpuutedWord.Length; i++)
                {
                    solverCopy[Puzzle.CursorX, Puzzle.CursorY + i].Character = arrayInpuutedWord[i];
                }
            }
            else
            {
                for(int i =0; i < arrayInpuutedWord.Length; i++)
                {
                    solverCopy[Puzzle.CursorX + i, Puzzle.CursorY].Character = arrayInpuutedWord[i];
                }
            }
        }
        /// <summary>
        /// draws the array for the solver section of the program
        /// </summary>
        public static void DrawSolverScreen(int x, int y, Word[,] solverCopy, Word[,] puzzleData)
        {
            Console.CursorVisible = false;

            for (int i = 0; i < solverCopy.GetLength(0); i++)
            {
                Console.SetCursorPosition(x, y + i);
                for(int j = 0; j < solverCopy.GetLength(1); j++)
                { 
                    if(solverCopy[i,j].Character != '■')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    } 
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }

                    if(puzzleData[i, j].Character != '■')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }

                    if (solverCopy[i, j].CorrectGuess == true && solverCopy[i,j].Character != '■')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if(solverCopy[i,j].CorrectGuess == false && solverCopy[i,j].Character != '■')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }


                    if(Puzzle.CursorX == i && Puzzle.CursorY == j)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    Console.Write(solverCopy[i, j].Character + " ");
                }
                Console.WriteLine();
            }
        }

        public static void CheckGuesses(Word[,] solverCopy, Word[,] puzzleData)
        {
            for(int i = 0; i < puzzleData.GetLength(0); i++)
            {
                for(int j = 0; j < puzzleData.GetLength(1); j++)
                {
                    if(solverCopy[i, j].Character != '■' && solverCopy[i,j].Character == puzzleData[i, j].Character)
                    {
                        solverCopy[i,j].CorrectGuess = true;
                    }
                    else
                    {
                        solverCopy[i,j].CorrectGuess = false;
                    }
                }
            }
        }

    }
}