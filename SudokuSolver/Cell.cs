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
        private bool completenessStartFlag = false;
        private bool gameCompleted = false;

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

        public void MainChainOfCellUpdates(int numberOfLoops)
        {
            UpdateAndConsiderPotentialValues();
            if (gameCompleted == false)
            {
                nextCell.MainChainOfCellUpdates(numberOfLoops + 1);
            }
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
                UpdateValue(potentialValues.Single());
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
                    UpdateValue(potentialValue);
                    return true;
                }
            }
            return false;
        }

        private void ShowViewer()
        {
            Cell startCell = FindStartCell();
            Viewer viewer = new Viewer(startCell);
        }

        public bool CouldBe(char value)
        {
            return potentialValues.Contains(value);
        }
        
        private void UpdateValue(char value)
        {
            this.value = value;
            potentialValues.Clear();
            InitializeCompletenessTest();
        }

        private void InitializeCompletenessTest()
        {
            completenessStartFlag = true;
            if (!nextCell.FieldIsCompleted())
            {
                completenessStartFlag = false;
            }
            else
            {
                GameOver();
            }
        }

        public bool FieldIsCompleted()
        {
            if (completenessStartFlag == true) { return true; }
            if (value == '0') { return false; }
            if (!nextCell.FieldIsCompleted())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GameOver()
        {
            gameCompleted = true;
            ShowViewer();
        }

        private Cell FindStartCell()
        {
            Cell currentCell = this;
            for(int i = 0; i < 81; i++)
            {
                if (currentCell.cellNumber != 0)
                {
                    currentCell = currentCell.GetNextCell();
                }
            }
            return currentCell;
        }

        public Cell GetNextCell() => nextCell;
        public char GetValue() => value;
        internal int CellNumber => cellNumber;

        public void SetNextCell(Cell nextCell) => this.nextCell = nextCell;
        public void SetAssociatedRow(Row row) => this.associatedRow = row;
        public void SetAssociatedColumn(Column column) => this.associatedColumn = column;
        public void SetAssociatedBlock(Block block) => this.associatedBlock = block;

        
        internal Row GetAssociatedRow() => associatedRow; //for test
        internal Column GetAssociatedColumn() => associatedColumn; //for test
        internal Block GetAssociatedBlock() => associatedBlock; //for test
    }
}
