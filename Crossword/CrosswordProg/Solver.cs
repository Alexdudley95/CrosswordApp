namespace Crossword
{
    class Solver
    {
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

            DrawSolverScreen(10, 5, solverCopy, puzzleData);
            CrosswordSettings.DrawPlayUI(solverCopy, crosswordSettings, false);
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

            DrawSolverScreen(10, 5, solverCopy, puzzleData);
            CrosswordSettings.DrawPlayUI(puzzleData, crosswordSettings, false);
            }
        }

        /// <summary>
        /// Used to input a guess into the copied Word[,] array
        /// </summary>
        public static void UserInputGuess(Word[,] solverCopy, Word[,] puzzleData)
        {
            Console.Clear();
            DrawGuessScreen();
            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 7);
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

        public static void DrawGuessScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(Console.WindowWidth / 2 + 10, 5);
            Console.Write("Please input guess: ");
        }


        //K17
        /// <summary>
        /// Draws the main crossword array. Checks character & other params to display the colour of the character.
        /// </summary>
        /// <param name="x"> X Location to draw from </param>
        /// <param name="y"> Y Location to draw from </param>
        /// <param name="solverCopy"> 2D array of words, this usually does not contain the full data for the completed puzzle </param> 
        /// <param name="puzzleData"> 2D array of words </param>
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
        /// <summary>
        /// Loops through the Puzzle array and checks the characters in each position for matches
        /// </summary>
        /// <param name="solverCopy">This contains the users guesses.</param>
        /// <param name="puzzleData">This contains the puzzle data & words.</param>
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