using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
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

            Assert.AreEqual(9, parser.GetStartCell().GetAssociatedColumn().CountMembers());
        }

        [TestMethod]
        public void AllCellsHaveAColumn()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);
            Cell currentCell = parser.GetStartCell();

            for (int i = 0; i < 81; i++)
            {
                Assert.IsNotNull(currentCell.GetAssociatedColumn());
                currentCell = currentCell.GetNextCell();
            }


        }
    }
}
