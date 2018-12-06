using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace SudokuSolverTest
{
    [TestClass]
    public class FieldsToSolve
    {
        
        [TestMethod]
        public void SingleMissingValueIsSolved()
        {
            string input = "083921657967345821251876493548132976729564138136798245372689514814253769695417382";
            Parser parser = new Parser(input);

            Assert.AreEqual('4', parser.StartCell.GetValue());
        }

        [TestMethod]
        public void VeryEasyFieldIsSolved()
        {
            string input = "483921057967345821250870093548132000729564138100798245300689514814200769605417002";
            Parser parser = new Parser(input);

            Cell currentCell = parser.StartCell;

            for(int i = 0; i < 81; i++)
            {
                Assert.AreNotEqual('0', currentCell.GetValue());
                currentCell = currentCell.GetNextCell();
            }
        }

        [TestMethod]
        public void ReasonablySimpleFieldIsSolved()
        {
            string input = "530070000600195000098000060800060003400803001700020006060000280000419005000080079";
            Parser parser = new Parser(input);

            Cell currentCell = parser.StartCell;

            for (int i = 0; i < 81; i++)
            {
                Assert.AreNotEqual('0', currentCell.GetValue());
                currentCell = currentCell.GetNextCell();
            }
        }

        
        [TestMethod]
        public void SogyoFieldIsSolved()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Cell currentCell = parser.StartCell;

            for (int i = 0; i < 81; i++)
            {
                Assert.AreNotEqual('0', currentCell.GetValue());
                currentCell = currentCell.GetNextCell();
            }
        }

    }
}