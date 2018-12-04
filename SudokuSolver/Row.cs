using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Row
    {
        private List<Cell> members = new List<Cell>();
        private int rowNumber;

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

        private void AddMember(Cell cell)
        {
            members.Add(cell);
            cell.SetAssociatedRow(this);
        }

        private void MaybeCreateNextRow(Cell currentCell)
        {
            if (currentCell.GetAssociatedRow() == null)
            {
                Row row = new Row(rowNumber + 1, currentCell);
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
            foreach(Cell competitor in competitors)
            {
                return competitor.GetAssociatedColumn().CheckValueObjections(value, level + 1) |
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
                Console.WriteLine("Max level reached for search in Row " + rowNumber);
                return true;
            }
        }

        public int GetRowNumber() => rowNumber;
        internal int CountMembers => members.Count();
    }
}
