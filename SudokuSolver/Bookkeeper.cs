using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Bookkeeper
    {
        private List<Row> allRows = new List<Row>();

        public Bookkeeper()
        {

        }

        public void ProcessNewRow(Row newRow, int StartPosition)
        {
            allRows.Add(newRow);
            newRow.SendAssignedCells(Enumerable.Range(StartPosition, 9).ToArray());
        }

        public Row RequestRow(int cellNumber)
        {
            int associatedRowNumber = 0;

            switch (cellNumber)
            {
                case int n when (n <= 9):
                    associatedRowNumber = 1;
                    break;

                case int n when (n > 9 && n <= 18):
                    associatedRowNumber = 2;
                    break;

                case int n when (n > 18 && n <= 27):
                    associatedRowNumber = 3;
                    break;

                case int n when (n > 27 && n <= 36):
                    associatedRowNumber = 4;
                    break;

                case int n when (n > 36 && n <= 45):
                    associatedRowNumber = 5;
                    break;

                case int n when (n > 45 && n <= 54):
                    associatedRowNumber = 6;
                    break;

                case int n when (n > 54 && n <= 63):
                    associatedRowNumber = 7;
                    break;

                case int n when (n > 63 && n <= 72):
                    associatedRowNumber = 8;
                    break;

                case int n when (n > 72 && n <= 81):
                    associatedRowNumber = 9;
                    break;

                default:
                    return null;
            }

            return allRows.Single(row => row.rowNumber == associatedRowNumber);
        }

        internal List<Row> GetAllRows() //for test
        {
            return allRows;
        }
    }
}
