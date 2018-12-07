using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Column
    {
        private readonly int columnNumber;
        private List<Cell> members = new List<Cell>();

        public Column(int columnNumber, Cell cell)
        {
            this.columnNumber = columnNumber;
            RecruitMembers(cell);
        }

        private void RecruitMembers(Cell cell)
        {
            Cell currentCell = cell;
            for (int i = 0; i < 73; i++)
                //73 because the last row doesn't have to be 
                //completely iterated, so 72 is the last.
            {
                if (i % 9 == 0) { AddMember(currentCell); }
                currentCell = currentCell.GetNextCell();
            }

            MaybeCreateNextColumn(cell);
        }

        private void AddMember(Cell cell)
        {
            members.Add(cell);
            cell.SetAssociatedColumn(this);
        }

        private void MaybeCreateNextColumn(Cell cell)
        {
            if (cell.GetNextCell().GetAssociatedColumn() == null)
            {
                Column column = new Column(GetColumnNumber() + 1, cell.GetNextCell());
            }
        }

        public List<char> GetValuesWithinColumn()
        {
            return members.Select(x => x.GetValue()).Distinct().ToList();
        }

        public bool UpdatePossibleValuesWithinColumn(Cell OriginalCell)
        {
            bool updatesMade = false;
            foreach (Cell member in members)
            {
                if (member != OriginalCell && member.CheckForNeededValue())
                {
                    if (member.UpdatePossibleValues() ||
                    member.UpdateValueIfOnlyPossibility())
                    {
                        updatesMade = true;
                    }
                }
            }
            return updatesMade;
        }

        public bool CheckForExistenceOfPossibleValue(char givenValue, Cell OriginalCell)
        {
            var origin = new List<Cell> { OriginalCell };
            var rest = members.Except(origin).ToList();
            return rest.Any(x => x.CouldBe(givenValue));
        }

        public int GetColumnNumber() => columnNumber;
        internal int CountMembers() => members.Count();
    }
}
