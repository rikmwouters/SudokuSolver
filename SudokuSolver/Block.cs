using System;
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
                if(i == 3 || i == 6)
                {
                    currentCell = currentCell.GetNextCell().GetNextCell().GetNextCell().GetNextCell().GetNextCell().GetNextCell();
                }
                AddMember(currentCell);
                currentCell = currentCell.GetNextCell();
            }

            WhetherToPlaceNewBlock(cell);
        }

        private void AddMember(Cell cell)
        {
            members.Add(cell);
            cell.SetAssociatedBlock(this);
        }

        private void WhetherToPlaceNewBlock(Cell cell)
        {
            if (cell.GetNextCell().GetNextCell().GetNextCell().GetAssociatedBlock() == null || blockNumber != 8)
            {
                WhereToPlaceNewBlock(cell);
            }
        }

        private void WhereToPlaceNewBlock(Cell cell)
        {
            if (blockNumber != 2 && blockNumber != 5)
            {
                Block block = new Block(GetBlockNumber() + 1, cell.GetNextCell().GetNextCell().GetNextCell());
            } else
            {
                NewLineOfBlocks(cell);
            }
        }

        private void NewLineOfBlocks(Cell cell)
        {
            Cell currentCell = cell;
            for (int i = 0; i < 21; i++)
            {
                currentCell = currentCell.GetNextCell();
            }
            Block block = new Block(GetBlockNumber() + 1, currentCell);
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
                return competitor.GetAssociatedColumn().CheckValueObjections(value, level + 1) |
                    competitor.GetAssociatedRow().CheckValueObjections(value, level + 1);
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
                Console.WriteLine("Max level reached for search in Block " + blockNumber);
                return true;
            }
        }

        public int GetBlockNumber() => blockNumber;
        internal int CountMembers() => members.Count();
    }
}
