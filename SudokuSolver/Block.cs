using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Block
    {
        public int blockNumber;
        private List<Cell> members = new List<Cell>();

        public Block(int blockNumber, Cell cell)
        {
            this.blockNumber = blockNumber;
            RecruitMembers(cell);
        }

        private void RecruitMembers(Cell cell)
        {
            Cell currentCell = cell;
            for (int i = 0; i < 9; i++)
            {
                if(i == 3)
                {
                    currentCell = currentCell.GetNextCell().GetNextCell().GetNextCell().GetNextCell().GetNextCell().GetNextCell();
                }
                AddMember(currentCell);
                currentCell = currentCell.GetNextCell();
            }
        }

        private void AddMember(Cell cell)
        {
            members.Add(cell);
            cell.SetAssociatedBlock(this);
        }

        public int GetBlockNumber()
        {
            return blockNumber;
        }

        internal int CountMembers()
        {
            return members.Count();
        }
    }
}
