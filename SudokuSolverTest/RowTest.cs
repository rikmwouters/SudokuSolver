using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolverTest
{
    [TestClass]
    public class RowTest
    {
        [TestMethod]
        public void RowAcceptsCellIntoVacancy()
        {
            Row row = new Row(0);
            int[] positions = { 1, 2, 3 };
            row.SendAssignedCells(positions);
            Cell cell = new Cell('1', 1);
            row.RequestMembership(1, cell);

            Assert.AreEqual(1, row.GetMembers().Count());
        }

        [TestMethod]
        public void RowAcceptsOnlyOneCellPerVacancy()
        {
            Row row = new Row(0);
            int[] positions = { 1, 2, 3 };
            row.SendAssignedCells(positions);
            Cell cell1 = new Cell('1', 1);
            Cell cell2 = new Cell('1', 1);
            row.RequestMembership(1, cell1);
            row.RequestMembership(1, cell2);

            Assert.AreEqual(1, row.GetMembers().Count());
        }

        [TestMethod]
        public void RowsContainNineCells()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            List<Row> allRows = parser.GetBookkeeper().GetAllRows();

            foreach(Row row in allRows)
            {
                Assert.AreEqual(9, row.GetMembers().Count());
            }
        }

        [TestMethod]
        public void AllVancanciesFinallyCleared()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            List<Row> allRows = parser.GetBookkeeper().GetAllRows();

            foreach (Row row in allRows)
            {
                for(int i = 0; i < 9; i++)
                {
                    Assert.IsTrue(row.GetVacancies()[i] >= 100);
                }
            }
        }
    }
}
