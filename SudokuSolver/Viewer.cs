using System;

namespace SudokuSolver
{
    class Viewer
    {
        public Viewer(Cell StartCell)
        {
            ViewSheet(StartCell);
        }

        private void ViewSheet(Cell startCell)
        {
            Console.Write("\n\n");
            Cell currentCell = startCell;
            for(int i = 0; i < 81; i++)
            {
                Formatting(i);
                Console.Write(currentCell.GetValue() + " ");
                currentCell = currentCell.GetNextCell();
            }
            Console.Write("\n\n");
        }

        private void Formatting(int i)
        {
            if (i % 9 == 0 && i != 0 && i != 27 && i != 54) { Console.Write("\n"); }
            else if (i == 27 || i == 54) { Console.Write("\n--------------------\n"); }
            else if (i % 3 == 0 && i != 0) { Console.Write("| "); }
        }
    }
}
