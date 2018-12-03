using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverTest
{
    [TestClass]
    public class CellTest
    {
        [TestMethod]
        public void FieldIsCircular()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Cell startCell = parser.GetStartCell();
            Cell currentCell = startCell;

            for(int i = 0; i < 41; i++)
            {
                currentCell = currentCell.GetNextCell();
            }
            Assert.AreNotEqual(currentCell, startCell);

            for (int i = 0; i < 40; i++)
            {
                currentCell = currentCell.GetNextCell();
            }
            Assert.AreEqual(currentCell, startCell);
        }
    }
}
