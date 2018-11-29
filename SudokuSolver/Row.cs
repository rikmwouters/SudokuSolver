using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Row
    {
        private int[] vacancies;
        private List<Cell> members = new List<Cell>();
        public int rowNumber;

        public Row(int rowNumber)
        {
            this.rowNumber = rowNumber;
        }

        public void SendAssignedCells(int[] positions)
        {
            this.vacancies = positions;
        }

        public bool RequestMembership(int cellNumber, Cell cell)
        {
            bool approval = false;
            if (vacancies.Contains(cellNumber))
            {
                approval = true;
                vacancies[Array.IndexOf(vacancies, cellNumber)] = -cellNumber;
                members.Add(cell);
            }
            return approval;
        }

        public int GetRowNumber()
        {
            return rowNumber;
        }

        internal List<Cell> GetMembers() //for test
        {
            return members;
        }
    }
}
