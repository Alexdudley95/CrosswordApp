namespace Crossword
{
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
                DrawPlayScreen(puzzleData, newCrossword);
                UpdatePuzzle(puzzleData);
            }
        }

        public static void UpdatePuzzle(Word[,] puzzleData)
        {
            Puzzle.UpdatePos();
            Puzzle.BoundryCheck(puzzleData);
        }
        public static void DrawPlayScreen(Word[,] puzzleData, CrosswordSettings crossword)
        {
            Puzzle.DrawPuzzle(5, 5, puzzleData);
            CrosswordSettings.DrawPlayUI(crossword);
        }
        


    }
}