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

        private void ConstructBlocks()
        {
            int[] StartPosition = { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
            for (int i = 0; i < 9; i++)
            {
                Block newBlock = new Block(i);
                bookkeeper.ProcessNewBlock(newBlock, StartPosition[i]);
            }
        }

        public Bookkeeper GetBookkeeper()
        {
            return bookkeeper;
        }
    }
}
