using System;

namespace SudokuSolver
{
    class Cell
    {
        private int cellNumber;
        private int value;
        private Row associatedRow;

        public Cell(char value, int cellNumber, Bookkeeper bookkeeper)
        {
            this.cellNumber = cellNumber;
            this.value = value;
            JoinRow(bookkeeper);
        }

        public void JoinRow(Bookkeeper bookkeeper)
        {
            Row assignedRow = bookkeeper.RequestRow(cellNumber);
            if (assignedRow.RequestMembership(cellNumber, this)) { associatedRow = assignedRow; }
        }
    }
}
