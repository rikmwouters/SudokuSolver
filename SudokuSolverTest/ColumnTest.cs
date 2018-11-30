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
        public void ColumnAcceptsCellIntoVacancy()
        {
            Column column = new Column(0);
            int[] positions = { 1, 10, 19 };
            column.SendAssignedCells(positions);
            Cell cell = new Cell('1', 1);
            column.RequestMembership(1, cell);

            Assert.AreEqual(1, column.GetMembers().Count());
        }

        [TestMethod]
        public void ColumnAcceptsOnlyOneCellPerVacancy()
        {
            Column column = new Column(0);
            int[] positions = { 1, 2, 3 };
            column.SendAssignedCells(positions);
            Cell cell1 = new Cell('1', 1);
            Cell cell2 = new Cell('1', 1);
            column.RequestMembership(1, cell1);
            column.RequestMembership(1, cell2);

            Assert.AreEqual(1, column.GetMembers().Count());
        }

        [TestMethod]
        public void ColumnsContainNineCells()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            List<Column> allColumns = parser.GetBookkeeper().GetAllColumns();

            foreach (Column column in allColumns)
            {
                Assert.AreEqual(9, column.GetMembers().Count());
            }
        }

        [TestMethod]
        public void AllVancanciesFinallyCleared()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            List<Column> allColumns = parser.GetBookkeeper().GetAllColumns();

            foreach (Column column in allColumns)
            {
                for (int i = 0; i < 9; i++)
                {
                    Assert.IsTrue(column.GetVacancies()[i] >= 100);
                }
            }
        }
    }
}
