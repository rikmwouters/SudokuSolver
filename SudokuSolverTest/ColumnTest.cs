using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverTest
{
    [TestClass]
    public class ColumnTest
    {
        [TestMethod]
        public void FirstColumnContainsNineCells()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Assert.AreEqual(9, parser.startCell.GetAssociatedColumn().CountMembers());
        }

        [TestMethod]
        public void AllCellsHaveAColumn()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.startCell;

            for (int i = 0; i < 81; i++)
            {
                Assert.IsNotNull(currentCell.GetAssociatedColumn());
                currentCell = currentCell.GetNextCell();
            }
        }

        [TestMethod]
        public void AllCellsHaveTheirExpectedColumn()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.startCell;
            int[] expectedColumnNumbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8, 0, 1, 2, 3, 4, 5, 6, 7, 8 };

            for (int i = 0; i < 81; i++)
            {
                if (expectedColumnNumbers[i] != currentCell.GetAssociatedColumn().GetColumnNumber())
                {
                    Console.WriteLine(expectedColumnNumbers[i] + " is verwacht op positie " + i + " maar werkelijke column is: " + currentCell.GetAssociatedColumn().GetColumnNumber());
                }
                Assert.AreEqual(expectedColumnNumbers[i], currentCell.GetAssociatedColumn().GetColumnNumber());
                currentCell = currentCell.GetNextCell();
            }
        }
    }
}
