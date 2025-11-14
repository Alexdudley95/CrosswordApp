namespace Crossword
{
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