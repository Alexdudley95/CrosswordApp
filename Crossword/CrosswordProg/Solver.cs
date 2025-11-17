namespace Crossword
{
    class Solver
    {
        

        public static void LoadCrossword(string fileName)
        {
            // fileName = "egg";
            CrosswordSaver saver = FileManager.ReturnCrosswordFromJson(Directory.GetCurrentDirectory() + "\\Crosswords\\" + fileName);


            CrosswordScreen.DrawPlayScreen(saver.PuzzleData, saver.CrosswordSettings, true);
            while (true)
            {
                switch (CrosswordScreen.UpdatePuzzle(saver.PuzzleData))
                {
                    case 1:
                        CrosswordScreen.UserInputWord(saver.PuzzleData, saver.CrosswordSettings);
                        break;
                    case 2:
                        CrosswordScreen.escapeMenu(saver.CrosswordSettings, saver.PuzzleData);
                        return;
                }
            CrosswordScreen.DrawPlayScreen(saver.PuzzleData, saver.CrosswordSettings, true);
            }
        }
    }
}