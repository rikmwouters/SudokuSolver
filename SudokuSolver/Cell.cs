using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Cell
    {
        private readonly int cellNumber;
        private char value;
        private List<char> possibleValues = new List<char>{ '1', '2', '3', '4', '5', '6', '7', '8', '9' };
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
            if(value != '0') { possibleValues.Clear(); }
        }

        public Cell() { }//Start cell

        public Cell(char value, List<char> possibleValues) //for test
        {
            this.value = value;
            this.possibleValues = possibleValues;
        }

        public void SolveSudoku(int numberOfLoops)
        {
            UpdateAndConsiderPossibleValues();
            if (gameCompleted == false)
            {
                nextCell.SolveSudoku(numberOfLoops + 1);
            }
        }

        public bool UpdateAndConsiderPossibleValues()
        {
            bool changesMade = false;
            if (CheckForNeededValue())
            {
                if (UpdatePossibleValues()) { changesMade = true; };
                if (UpdateValueIfOnlyPossibility()) { return true; };
                if (UpdatePossibleValuesOfCompetitors()) { changesMade = true; };
                if (UpdatePossibleValues()) { changesMade = true; };
                if (UpdateValueIfOnlyPossibility()) { return true; };
                if (IsAnyPossibilityNotPossibleElsewhere()) { return true; };
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

        public bool UpdatePossibleValues()
        {
            List<char> oldPossibleValues = possibleValues;
            possibleValues = possibleValues.Except(associatedRow.GetValuesWithinRow()).ToList();
            possibleValues = possibleValues.Except(associatedColumn.GetValuesWithinColumn()).ToList();
            possibleValues = possibleValues.Except(associatedBlock.GetValuesWithinBlock()).ToList();
            if(oldPossibleValues != possibleValues) { return true; }
            else { return false; }
        }

        public bool UpdateValueIfOnlyPossibility()
        {
            if(possibleValues.Count() == 1)
            {
                UpdateValue(possibleValues.Single());
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool UpdatePossibleValuesOfCompetitors()
        {
            bool changesMade = false;
            if(associatedRow.UpdatePossibleValuesWithinRow(this)) changesMade = true;
            if(associatedColumn.UpdatePossibleValuesWithinColumn(this)) changesMade = true;
            if(associatedBlock.UpdatePossibleValuesWithinBlock(this)) changesMade = true;
            return changesMade;
        }

        private bool IsAnyPossibilityNotPossibleElsewhere()
        {
            foreach(char possibleValue in possibleValues)
            {
                if (NotPossibleInRemainderOfAnyGroup(possibleValue)) { return true; }
            }
            return false;
        }

        private bool NotPossibleInRemainderOfAnyGroup(char possibleValue)
        {
            if (!associatedRow.CheckForExistenceOfPossibleValue(possibleValue, this) ||
                !associatedColumn.CheckForExistenceOfPossibleValue(possibleValue, this) ||
                !associatedBlock.CheckForExistenceOfPossibleValue(possibleValue, this))
            {
                UpdateValue(possibleValue);
                return true;
            }
            else { return false; }
        }

        private void ShowViewer()
        {
            Cell startCell = FindStartCell();
            Viewer viewer = new Viewer(startCell);
        }

        public bool CouldBe(char value)
        {
            return possibleValues.Contains(value);
        }
        
        private void UpdateValue(char value)
        {
            this.value = value;
            possibleValues.Clear();
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
