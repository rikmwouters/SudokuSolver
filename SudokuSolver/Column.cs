using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Column
    {
        public int columnNumber;
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

        public bool CheckValueObjections(char value, int level)
        {
            if (!members.Where(v => v.GetValue() == value).ToList<Cell>().Any()) { return true; }
            else
            {
                return CheckSearchLevel(value, level);
            }
        }

        private bool CheckCompetitors(char value, int level)
        {
            List<Cell> competitors = members.Where(v => v.GetValue() == '0').ToList<Cell>();
            foreach (Cell competitor in competitors)
            {
                return competitor.GetAssociatedRow().CheckValueObjections(value, level + 1) |
                    competitor.GetAssociatedBlock().CheckValueObjections(value, level + 1);
            }
            return false;
        }

        private bool CheckSearchLevel(char value, int level)
        {
            if (level < 9)
            {
                return CheckCompetitors(value, level + 1);
            }
            else
            {
                Console.WriteLine("Max level reached for search in Column " + columnNumber);
                return true;
            }
        }

        public int GetColumnNumber() => columnNumber;
        internal int CountMembers() => members.Count();
    }
}
