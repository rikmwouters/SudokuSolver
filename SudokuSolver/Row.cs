﻿using System;
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

        public List<char> GetValuesWithinRow()
        {
            return members.Select(x => x.GetValue()).Distinct().ToList();
        }

        public void UpdatePotentialValuesWithinRow(Cell OriginalCell)
        {
            foreach (Cell member in members)
            {
                if (member != OriginalCell && member.CheckForNeededValue())
                {
                    member.UpdatePotentialValues();
                    member.UpdateValueIfSinglePossibility();
                }
            }
        }

        public bool CheckForExistenceOfPotentialValue(char givenValue, Cell OriginalCell)
        {
            var origin = new List<Cell> { OriginalCell };
            var rest = members.Except(origin).ToList();
            return rest.Exists(x => x.GetPotentialValues().Equals(givenValue));
        }

        public int GetRowNumber() => rowNumber;
        internal int CountMembers => members.Count();
    }
}
