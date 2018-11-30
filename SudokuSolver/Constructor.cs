namespace SudokuSolver
{
    class Constructor
    {
        private Bookkeeper bookkeeper = new Bookkeeper();

        public Constructor()
        {
            ConstructRows();
            ConstructColumns();
        }

        private void ConstructRows()
        {
            int StartPosition = 0;
            for(int i = 0; i < 9; i++)
            {
                Row newRow = new Row(i);
                bookkeeper.ProcessNewRow(newRow, StartPosition);
                StartPosition = StartPosition + 9;
            }
        }

        private void ConstructColumns()
        {
            for(int i = 0; i < 9; i++)
            {
                Column newColumn = new Column(i);
                bookkeeper.ProcessNewColumn(newColumn, i);
            }
        }

        public Bookkeeper GetBookkeeper()
        {
            return bookkeeper;
        }
    }
}
