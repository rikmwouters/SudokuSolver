using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Cell
    {
        private readonly int cellNumber;
        private char value;
        private List<char> potentialValues = new List<char>{ '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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

        public void UpdateInChain(int numberOfLoops)
        {
            while(CheckForNeededValue())
            {
                UpdatePotentialValues();
                if (UpdateValueIfSinglePossibility()) { break; };
                UpdatePotentialValuesOfCompetitors();
                UpdatePotentialValues();
                if (UpdateValueIfSinglePossibility()) { break; };
                //CheckForUniquePotentialValue();
                break;
            }
            NextCellsTurn(numberOfLoops);
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

        public void UpdatePotentialValues()
        {
            potentialValues = potentialValues.Except(associatedRow.GetValuesWithinRow()).ToList();
            potentialValues = potentialValues.Except(associatedColumn.GetValuesWithinColumn()).ToList();
            potentialValues = potentialValues.Except(associatedBlock.GetValuesWithinBlock()).ToList();
        }

        public bool UpdateValueIfSinglePossibility()
        {
            if(potentialValues.Count() == 1)
            {
                value = potentialValues.Single();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void UpdatePotentialValuesOfCompetitors()
        {
            associatedRow.UpdatePotentialValuesWithinRow(this);
            associatedColumn.UpdatePotentialValuesWithinColumn(this);
            associatedBlock.UpdatePotentialValuesWithinBlock(this);
        }

        private void CheckForUniquePotentialValue()
        {
            foreach(char potentialValue in potentialValues)
            {
                if (!associatedRow.CheckForExistenceOfPotentialValue(potentialValue, this) ||
                !associatedColumn.CheckForExistenceOfPotentialValue(potentialValue, this) ||
                !associatedBlock.CheckForExistenceOfPotentialValue(potentialValue, this))
                {
                    value = potentialValue;
                }
            }
        }

        private void NextCellsTurn(int numberOfLoops)
        {
            if (numberOfLoops != 1619)
            {
                nextCell.UpdateInChain(numberOfLoops + 1);
            }
            else
            {
                Viewer viewer = new Viewer(nextCell);
            }
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
