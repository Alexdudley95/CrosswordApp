namespace Crossword
{
    public static class Create
    {
        //This class will be used to create the crosswords on the screen
        //Should handle the drawing and displaying of the data
        //Implement another class which handles the data side of the crosswords
        //MVC implementation maybe?? 


        public static void DrawCrossword()
        {
            
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write('*');
                }
            }
        }

    }
}