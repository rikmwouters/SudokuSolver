using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    class Block
    {
        public int blockNumber;
        private int[] vacancies;
        private List<Cell> members = new List<Cell>();

        public Block(int blockNumber) => this.blockNumber = blockNumber;

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

        public int GetBlockNumber()
        {
            return blockNumber;
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
