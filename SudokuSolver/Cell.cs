using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Cell
    {
        private readonly int cellNumber;
        private char value;
        private int changeNumber= -1; //met deze op 0 wordt het eerste vakje overgeslagen
        private List<char> potentialValues = new List<char>{ '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private Cell nextCell;
        private Row associatedRow;
        private Column associatedColumn;
        private Block associatedBlock;

        public Cell(char value, int cellNumber)
        {
            this.cellNumber = cellNumber;
            this.value = value;
            if(value != '0') { potentialValues.Clear(); }
        }

        public Cell() { }//Start cell

        public Cell(char value, List<char> potentialValues) //for test
        {
            this.value = value;
            this.potentialValues = potentialValues;
        }

        public void MainChainOfCellUpdates(int numberOfLoops, int changeNumber)
        {
            //if(this.changeNumber != changeNumber)
            //{
                this.changeNumber = changeNumber;
                if (UpdateAndConsiderPotentialValues()) { changeNumber++; };
                NextCellsTurn(numberOfLoops);
            //}
            //else
            //{
            //    this.changeNumber++;
            //    NextCellsTurn(numberOfLoops % 81 + 1539); //The numbers here makes sure to finish at the Start cell.
            //}
        }

        public bool UpdateAndConsiderPotentialValues()
        {
            bool changesMade = false;
            if (CheckForNeededValue())
            {
                if (UpdatePotentialValues()) { changesMade = true; };
                if (UpdateValueIfSinglePossibility()) { return true; };
                if (UpdatePotentialValuesOfCompetitors()) { changesMade = true; };
                if (UpdatePotentialValues()) { changesMade = true; };
                if (UpdateValueIfSinglePossibility()) { return true; };
                if (IsAnyPotentialValueUniqueWithinAGroup()) { return true; };
            }
            return changesMade;
        }
        
        public bool CheckForNeededValue()
        {
            if(value.Equals('0'))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePotentialValues()
        {
            List<char> oldPotentialValues = potentialValues;
            potentialValues = potentialValues.Except(associatedRow.GetValuesWithinRow()).ToList();
            potentialValues = potentialValues.Except(associatedColumn.GetValuesWithinColumn()).ToList();
            potentialValues = potentialValues.Except(associatedBlock.GetValuesWithinBlock()).ToList();
            if(oldPotentialValues != potentialValues) { return true; }
            else { return false; }
        }

        public bool UpdateValueIfSinglePossibility()
        {
            if(potentialValues.Count() == 1)
            {
                value = potentialValues.Single();
                potentialValues.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdatePotentialValuesOfCompetitors()
        {
            bool changesMade = false;
            if(associatedRow.UpdatePotentialValuesWithinRow(this)) changesMade = true;
            if(associatedColumn.UpdatePotentialValuesWithinColumn(this)) changesMade = true;
            if(associatedBlock.UpdatePotentialValuesWithinBlock(this)) changesMade = true;
            return changesMade;
        }

        private bool IsAnyPotentialValueUniqueWithinAGroup()
        {
            foreach(char potentialValue in potentialValues)
            {
                if (!associatedRow.CheckForExistenceOfPotentialValue(potentialValue, this) ||
                !associatedColumn.CheckForExistenceOfPotentialValue(potentialValue, this) ||
                !associatedBlock.CheckForExistenceOfPotentialValue(potentialValue, this))
                {
                    value = potentialValue;
                    potentialValues.Clear();
                    return true;
                }
            }
            return false;
        }

        private void NextCellsTurn(int numberOfLoops)
        {
            if (numberOfLoops != 1619)
            {
                nextCell.MainChainOfCellUpdates(numberOfLoops + 1, changeNumber);
            }
            else
            {
                Viewer viewer = new Viewer(nextCell);
            }
        }

        public bool CanBe(char value)
        {
            return GetPotentialValues().Contains(value);
        }
        

        public Cell GetNextCell() => nextCell;
        public char GetValue() => value;
        public List<char> GetPotentialValues() => potentialValues;

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
