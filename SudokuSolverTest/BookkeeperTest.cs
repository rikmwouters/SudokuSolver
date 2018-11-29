using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverTest
{
    [TestClass]
    public class BookkeeperTest
    {
        [TestMethod]
        public void BookkeeperExists()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Assert.IsNotNull(parser.GetBookkeeper());
        }

        [TestMethod]
        public void AllRowsListExists()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Assert.IsNotNull(parser.GetBookkeeper().GetAllRows());
        }

        [TestMethod]
        public void AllRowsListContainsNineRows()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            List<Row> allRows = parser.GetBookkeeper().GetAllRows();
            Assert.AreEqual(allRows.Count, 9);
        }

        [TestMethod]
        public void AllRowsListContainsAllRowNumbers()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            List<Row> allRows = parser.GetBookkeeper().GetAllRows();
            
            for(int i = 0; i < 9; i++)
            {
                Assert.IsTrue(allRows.Contains(allRows.Single(row => row.rowNumber == i)));
            }
        }
    }
}