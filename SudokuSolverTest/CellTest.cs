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

            Cell startCell = parser.StartCell;
            Cell currentCell = startCell;

            for (int i = 0; i < 41; i++)
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

        [TestMethod]
        public void UniquePotentialValueFound()
        {
            List<char> potentialValues = new List<char> { '1', '2', '3' };
            Cell cell1 = new Cell('0', potentialValues);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell2 = new Cell('0', potentialValues);
            cell1.SetNextCell(cell2);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell3 = new Cell('0', potentialValues);
            cell2.SetNextCell(cell3);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell4 = new Cell('0', potentialValues);
            cell3.SetNextCell(cell4);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell5 = new Cell('0', potentialValues);
            cell4.SetNextCell(cell5);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell6 = new Cell('0', potentialValues);
            cell5.SetNextCell(cell6);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell7 = new Cell('0', potentialValues);
            cell6.SetNextCell(cell7);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell8 = new Cell('0', potentialValues);
            cell7.SetNextCell(cell8);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell9 = new Cell('0', potentialValues);
            cell8.SetNextCell(cell9);
            cell9.SetNextCell(cell1);

            Row row = new Row(0, cell1);

            Assert.IsFalse(row.CheckForExistenceOfPotentialValue('1', cell1));
        }

        [TestMethod]
        public void ExistingPotentialValueFound()
        {
            List<char> potentialValues = new List<char> { '1', '2', '3' };
            Cell cell1 = new Cell('0', potentialValues);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell2 = new Cell('0', potentialValues);
            cell1.SetNextCell(cell2);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell3 = new Cell('0', potentialValues);
            cell2.SetNextCell(cell3);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell4 = new Cell('0', potentialValues);
            cell3.SetNextCell(cell4);
            potentialValues = new List<char> { '1', '3', '5' };
            Cell cell5 = new Cell('0', potentialValues);
            cell4.SetNextCell(cell5);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell6 = new Cell('0', potentialValues);
            cell5.SetNextCell(cell6);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell7 = new Cell('0', potentialValues);
            cell6.SetNextCell(cell7);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell8 = new Cell('0', potentialValues);
            cell7.SetNextCell(cell8);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell9 = new Cell('0', potentialValues);
            cell8.SetNextCell(cell9);
            cell9.SetNextCell(cell1);

            Row row = new Row(0, cell1);

            Assert.IsTrue(row.CheckForExistenceOfPotentialValue('1', cell1));
        }

        [TestMethod]
        public void UpdateValueWhenSinglePotentialValue()
        {
            List<char> potentialValues = new List<char> { '1', '2', '3' };
            Cell cell1 = new Cell('0', potentialValues);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell2 = new Cell('0', potentialValues);
            cell1.SetNextCell(cell2);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell3 = new Cell('0', potentialValues);
            cell2.SetNextCell(cell3);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell4 = new Cell('0', potentialValues);
            cell3.SetNextCell(cell4);
            potentialValues = new List<char> { '1', '3', '5' };
            Cell cell5 = new Cell('0', potentialValues);
            cell4.SetNextCell(cell5);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell6 = new Cell('0', potentialValues);
            cell5.SetNextCell(cell6);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell7 = new Cell('0', potentialValues);
            cell6.SetNextCell(cell7);
            potentialValues = new List<char> { '2' };
            Cell cell8 = new Cell('0', potentialValues);
            cell7.SetNextCell(cell8);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell9 = new Cell('0', potentialValues);
            cell8.SetNextCell(cell9);
            cell9.SetNextCell(cell1);

            Row row = new Row(0, cell1);

            Assert.IsTrue(cell8.UpdateValueIfSinglePossibility());
            Assert.AreEqual('2', cell8.GetValue());
        }

        [TestMethod]
        public void DontUpdateValueWhenMultiPotentialValue()
        {
            List<char> potentialValues = new List<char> { '1', '2', '3' };
            Cell cell1 = new Cell('0', potentialValues);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell2 = new Cell('0', potentialValues);
            cell1.SetNextCell(cell2);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell3 = new Cell('0', potentialValues);
            cell2.SetNextCell(cell3);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell4 = new Cell('0', potentialValues);
            cell3.SetNextCell(cell4);
            potentialValues = new List<char> { '1', '3', '5' };
            Cell cell5 = new Cell('0', potentialValues);
            cell4.SetNextCell(cell5);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell6 = new Cell('0', potentialValues);
            cell5.SetNextCell(cell6);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell7 = new Cell('0', potentialValues);
            cell6.SetNextCell(cell7);
            potentialValues = new List<char> { '2' };
            Cell cell8 = new Cell('0', potentialValues);
            cell7.SetNextCell(cell8);
            potentialValues = new List<char> { '2', '3', '5' };
            Cell cell9 = new Cell('0', potentialValues);
            cell8.SetNextCell(cell9);
            cell9.SetNextCell(cell1);

            Row row = new Row(0, cell1);

            Assert.IsFalse(cell7.UpdateValueIfSinglePossibility());
            Assert.AreEqual('0', cell7.GetValue());
        }

        [TestMethod]
        public void SolvableCell1Solved()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            Parser parser = new Parser(input);

            Cell currentCell = parser.StartCell;

            for(int i = 0; i < 47; i++)
            {
                currentCell = currentCell.GetNextCell();
            }

            currentCell.UpdateAndConsiderPotentialValues();

            Assert.AreEqual('3', currentCell.GetValue());
        }

        [TestMethod]
        public void SolvableCell2Solved()
        {
            //This cell is solvable without involvement of cells that are filled in already.
            //That is, all filled in cells are also covered under the influence of another 8.
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            Parser parser = new Parser(input);

            Cell currentCell = parser.StartCell;

            for (int i = 0; i < 64; i++)
            {
                currentCell = currentCell.GetNextCell();
            }

            currentCell.UpdateAndConsiderPotentialValues();

            Assert.AreEqual('8', currentCell.GetValue());
        }

        [TestMethod]
        public void SolvableCell3Solved()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            Parser parser = new Parser(input);

            Cell currentCell = parser.StartCell;

            for (int i = 0; i < 24; i++)
            {
                currentCell = currentCell.GetNextCell();
            }

            currentCell.UpdateAndConsiderPotentialValues();

            Assert.AreEqual('5', currentCell.GetValue());
        }
    }
}
