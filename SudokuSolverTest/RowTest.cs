using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

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

            Assert.AreEqual(9, parser.GetStartCell().GetAssociatedRow().CountMembers());
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
    }
}
