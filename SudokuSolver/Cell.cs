using System;

namespace SudokuSolver
{
    class Cell
    {
        private int cellNumber;
        private char value;
        private char[] possibleValues = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private Cell nextCell;
        private Row associatedRow;
        private Column associatedColumn;
        private Block associatedBlock;

        public Cell(char value, int cellNumber)
        {
            this.cellNumber = cellNumber;
            this.value = value;
        }

        public Cell() { }//Start cell

        public void CheckForNeededValue()
        {
            if(value.Equals('0'))
            {
                RequestNewValue();
            }
            NextCellsTurn();
        }

        private void RequestNewValue()
        {
            for(int i = 0; i < 9; i++)
            {
                if (!associatedBlock.CheckValueObjections(possibleValues[i], 0))
                {
                    value = possibleValues[i];
                    Console.WriteLine("New value added to Cell " + cellNumber);
                    break;
                }
            }
        }

        private void NextCellsTurn()
        {
            if (cellNumber != 80)
            {
                nextCell.CheckForNeededValue();
            }
            else
            {
                Viewer viewer = new Viewer(nextCell);
            }
        }

        public Cell GetNextCell() => nextCell;
        public char GetValue() => value;

        public void SetNextCell(Cell nextCell) => this.nextCell = nextCell;
        public void SetAssociatedRow(Row row) => this.associatedRow = row;
        public void SetAssociatedColumn(Column column) => this.associatedColumn = column;
        public void SetAssociatedBlock(Block block) => this.associatedBlock = block;

        internal int CellNumber => cellNumber; //for test
        internal Row GetAssociatedRow() => associatedRow; //for test
        internal Column GetAssociatedColumn() => associatedColumn; //for test
        internal Block GetAssociatedBlock() => associatedBlock; //for test
    }
}
