using System;

namespace SudokuSolver
{
    class Cell
    {
        private int cellNumber;
        private int value;
        private Row associatedRow;
        private Column associatedColumn;
        private Block associatedBlock;

        public Cell(char value, int cellNumber, Bookkeeper bookkeeper)
        {
            this.cellNumber = cellNumber;
            this.value = value;
            FindRow(bookkeeper);
            FindColumn(bookkeeper);
            //FindBlock(bookkeeper);
        }

        public Cell(char value, int cellNumber) //for test
        {
            this.cellNumber = cellNumber;
            this.value = value;
        }

        private void FindRow(Bookkeeper bookkeeper)
        {
            for(int i = 0; i < 9; i++)
            {
                Row SuggestedRow = bookkeeper.RowSuggestion(i);
                if (SuggestedRow.RequestMembership(cellNumber, this)) { associatedRow = SuggestedRow; break; }
            }
        }

        private void FindColumn(Bookkeeper bookkeeper)
        {
            for (int i = 0; i < 9; i++)
            {
                Column SuggestedColumn = bookkeeper.ColumnSuggestion(i);
                if (SuggestedColumn.RequestMembership(cellNumber, this)) { associatedColumn = SuggestedColumn; break; }
            }
        }

        private void FindBlock(Bookkeeper bookkeeper)
        {
            for (int i = 0; i < 9; i++)
            {
                Block SuggestedBlock = bookkeeper.BlockSuggestion(i);
                if (SuggestedBlock.RequestMembership(cellNumber, this)) { associatedBlock = SuggestedBlock; break; }
            }
        }

        internal int GetCellNumber() //for test
        {
            return cellNumber;
        }
    }
}
