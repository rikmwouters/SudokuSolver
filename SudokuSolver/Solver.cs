

namespace SudokuSolver
{
    class Solver
    {
        public Solver(Cell startCell)
        {
            Viewer viewer = new Viewer(startCell);
            startCell.SolveSudoku(0);
        }
    }
}
