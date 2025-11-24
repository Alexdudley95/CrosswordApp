namespace Crossword
{
    /// <summary>
    /// This class is used to combine the puzzle data and the crossword settings so that it can be saved within the file system.
    /// This class is later then loaded into the system for the crossword solver. 
    /// </summary>
    public class CrosswordSaver
    {
        private CrosswordSettings _crosswordSettings;
        private Word[,] _puzzleData;
    
        public CrosswordSettings CrosswordSettings
        {
            get => _crosswordSettings;
            set
            {
                _crosswordSettings = value;
            }
        }
        public Word[,] PuzzleData
        {
            get => _puzzleData;
            set
            {
                _puzzleData = value;
            }
        }

        public CrosswordSaver(CrosswordSettings settings, Word[,] puzzleData)
        {
            CrosswordSettings = settings;
            PuzzleData = puzzleData;
        }
        
    }
}