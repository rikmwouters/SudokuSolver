using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuSolver;

namespace SudokuSolverTest
{
    [TestClass]
    public class ConstructorTest
    {
        [TestMethod]
        public void ConstructorExists()
        {
            string input = "000820090500000000308040007100000040006402503000090010093004000004035200000700900";
            Parser parser = new Parser(input);

            Assert.IsNotNull(parser.GetConstructor());
        }
    }
}