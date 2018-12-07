using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Block
    {
        private readonly int blockNumber;
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

        public List<char> GetValuesWithinBlock()
        {
            return members.Select(x => x.GetValue()).Distinct().ToList();
        }

        public bool UpdatePossibleValuesWithinBlock(Cell OriginalCell)
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

        public int GetBlockNumber() => blockNumber;
        internal int CountMembers() => members.Count();
    }
}
