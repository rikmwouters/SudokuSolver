using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverTest
{
    [TestClass]
    public class BlockTest
    {


        [TestMethod]
        public void FirstBlockContainsNineCells()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Assert.AreEqual(9, parser.startCell.GetAssociatedBlock().CountMembers());
        }

        [TestMethod]
        public void AllCellsHaveABlock()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.startCell;

            for (int i = 0; i < 81; i++)
            {
                Assert.IsNotNull(currentCell.GetAssociatedBlock());
                currentCell = currentCell.GetNextCell();
            }
        }

        [TestMethod]
        public void AllCellsHaveTheirExpectedBlock()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.startCell;
            int[] expectedBlockNumbers = { 0, 0, 0, 1, 1, 1, 2, 2, 2, 0, 0, 0, 1, 1, 1, 2, 2, 2, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 3, 3, 3, 4, 4, 4, 5, 5, 5, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 6, 6, 6, 7, 7, 7, 8, 8, 8, 6, 6, 6, 7, 7, 7, 8, 8, 8 };

            for (int i = 0; i < 81; i++)
            {
                if (expectedBlockNumbers[i] != currentCell.GetAssociatedBlock().GetBlockNumber())
                {
                    Console.WriteLine(expectedBlockNumbers[i] + " is verwacht op positie " + i + " maar werkelijke block is: " + currentCell.GetAssociatedBlock().GetBlockNumber());
                }
                Assert.AreEqual(expectedBlockNumbers[i], currentCell.GetAssociatedBlock().GetBlockNumber());
                currentCell = currentCell.GetNextCell();
            }
        }
    }
}
