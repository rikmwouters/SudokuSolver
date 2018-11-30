using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class Column
    {
        public int columnNumber;
        private int[] vacancies;
        private List<Cell> members = new List<Cell>();

        public Column(int columnNumber) => this.columnNumber = columnNumber;

        public void SendAssignedCells(int[] positions)
        {
            vacancies = positions;
        }

        public bool RequestMembership(int cellNumber, Cell cell)
        {
            bool approval = false;
            if (vacancies.Contains(cellNumber))
            {
                approval = true;
                vacancies[Array.IndexOf(vacancies, cellNumber)] = cellNumber + 100;
                members.Add(cell);
            }
            return approval;
        }

        public int GetRowNumber()
        {
            return columnNumber;
        }

        internal List<Cell> GetMembers() //for test
        {
            return members;
        }

        internal int[] GetVacancies() //for test
        {
            return vacancies;
        }
    }
}
