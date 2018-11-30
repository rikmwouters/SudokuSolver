using System;

namespace SudokuSolver
{
    class Cell
    {
        private int cellNumber;
        private int value;
        private Row associatedRow;
        private Column associatedColumn;

        public Cell(char value, int cellNumber, Bookkeeper bookkeeper)
        {
            this.cellNumber = cellNumber;
            this.value = value;
            JoinRow(bookkeeper);
            JoinColumn(bookkeeper);
        }

        public Cell(char value, int cellNumber) //for test
        {
            this.cellNumber = cellNumber;
            this.value = value;
        }

        private void JoinRow(Bookkeeper bookkeeper)
        {
            Row assignedRow = bookkeeper.RequestRow(cellNumber);
            if (assignedRow.RequestMembership(cellNumber, this)) { associatedRow = assignedRow; }
        }

        private void JoinColumn(Bookkeeper bookkeeper)
        {
            Column assignedColumn = bookkeeper.RequestColumn(cellNumber);
            if (assignedColumn.RequestMembership(cellNumber, this)) { associatedColumn = assignedColumn; }
        }

        internal int GetCellNumber() //for test
        {
            return cellNumber;
        }
    }
}
