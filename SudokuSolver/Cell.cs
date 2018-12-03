using System;

namespace SudokuSolver
{
    class Cell
    {
        private int cellNumber;
        private int value;
        private Cell nextCell;
        private Row associatedRow;
        private Column associatedColumn;
        private Block associatedBlock;

        public Cell(char value, int cellNumber) //for test
        {
            this.cellNumber = cellNumber;
            this.value = value;
        }

        public Cell() //Start cell
        {

        }

        public void SetNextCell(Cell nextCell)
        {
            this.nextCell = nextCell;
        }

        public Cell GetNextCell()
        {
            return nextCell;
        }

        public void SetAssociatedRow(Row row)
        {
            this.associatedRow = row;
        }

        public void SetAssociatedColumn(Column column)
        {
            this.associatedColumn = column;
        }

        public void SetAssociatedBlock(Block block)
        {
            this.associatedBlock = block;
        }

        internal int GetCellNumber() //for test
        {
            return cellNumber;
        }

        internal Row GetAssociatedRow() => associatedRow; //for test
        internal Column GetAssociatedColumn() => associatedColumn; //for test
        internal Block GetAssociatedBlock() => associatedBlock; //for test
    }
}
