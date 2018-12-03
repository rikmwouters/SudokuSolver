using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Row
    {
        private List<Cell> members = new List<Cell>();
        public int rowNumber;

        public Row(int rowNumber, Cell cell)
        {
            this.rowNumber = rowNumber;
            RecruitMembers(cell);
        }

        private void RecruitMembers(Cell cell)
        {
            Cell currentCell = cell;
            for(int i = 0; i < 9; i++)
            {
                AddMember(currentCell);
                currentCell = currentCell.GetNextCell();
            }

            MaybeCreateNextRow(currentCell);
        }

        private void MaybeCreateNextRow(Cell currentCell)
        {
            if (currentCell.GetNextCell().GetAssociatedRow() == null)
            {
                Row row = new Row(GetRowNumber() + 1, currentCell.GetNextCell());
            }
        }

        private void AddMember(Cell cell)
        {
            members.Add(cell);
            cell.SetAssociatedRow(this);
        }

        public int GetRowNumber()
        {
            return rowNumber;
        }

        internal int CountMembers()
        {
            return members.Count();
        }
    }
}
