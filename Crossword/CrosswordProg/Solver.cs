namespace Crossword
{
    class Solver
    {
        /// <summary>
        /// loads the crossword from a json file. always checks the crosswords directory. If does not exist, returns null.
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

        public static void DrawSolver(Word[,] puzzleData, CrosswordSettings crosswordSettings)
        {
            CrosswordScreen.DrawPlayScreen(puzzleData, crosswordSettings, true);
            while (true)
            {
                switch (CrosswordScreen.UpdatePuzzle(puzzleData))
                {
                    case 1:
                        CrosswordScreen.UserInputWord(puzzleData, crosswordSettings);
                        break;
                    case 2:
                        CrosswordScreen.EscapeMenu(crosswordSettings, puzzleData);
                        return;
                }
            CrosswordScreen.DrawPlayScreen(puzzleData, crosswordSettings, true);
            }
        }
    }
}