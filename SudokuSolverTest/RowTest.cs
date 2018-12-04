using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;

namespace SudokuSolverTest
{
    [TestClass]
    public class RowTest
    {
        [TestMethod]
        public void FirstRowContainsNineCells()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Assert.AreEqual(9, parser.GetStartCell().GetAssociatedRow().CountMembers);
        }

        [TestMethod]
        public void AllCellsHaveARow()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.GetStartCell();

            for (int i = 0; i < 81; i++)
            {
                Assert.IsNotNull(currentCell.GetAssociatedRow());
                currentCell = currentCell.GetNextCell();
            }
        }

        [TestMethod]
        public void AllCellsHaveTheirExpectedRow()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.GetStartCell();
            int[] expectedRowNumbers = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8 };

            for (int i = 0; i < 81; i++)
            {
                if (expectedRowNumbers[i] != currentCell.GetAssociatedRow().GetRowNumber())
                {
                    Console.WriteLine(expectedRowNumbers[i] + " is verwacht op positie " + i + " maar werkelijke row is: " + currentCell.GetAssociatedRow().GetRowNumber());
                }
                Assert.AreEqual(expectedRowNumbers[i], currentCell.GetAssociatedRow().GetRowNumber());
                currentCell = currentCell.GetNextCell();
            }
        }
    }
}
