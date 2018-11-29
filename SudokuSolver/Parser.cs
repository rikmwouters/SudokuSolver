

namespace SudokuSolver
{
    class Parser
    {
        internal Constructor constructor; //for test
        internal Bookkeeper bookkeeper; //for test

        public Parser(string input)
        {
            Constructor constructor = new Constructor();
            this.constructor = constructor; //for test
            Bookkeeper bookkeeper = constructor.GetBookkeeper();
            this.bookkeeper = bookkeeper; //for test
            ParseInput(input, bookkeeper);
        }

        private void ParseInput(string input, Bookkeeper bookkeeper)
        {
            char[] charArray = input.ToCharArray();
            int cellNumber = 0;

            foreach(char value in charArray)
            {
                Cell cell = new Cell(value, cellNumber, bookkeeper);
            }
        }

        internal Constructor GetConstructor() //for test
        {
            return constructor;
        }

        internal Bookkeeper GetBookkeeper() //for test
        {
            return bookkeeper;
        }
    }
}
