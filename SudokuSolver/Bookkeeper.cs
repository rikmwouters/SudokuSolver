using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Bookkeeper
    {
        private List<Row> allRows = new List<Row>();
        private List<Column> allColumns = new List<Column>();

        public Bookkeeper()
        {

        }

        public void ProcessNewRow(Row newRow, int StartPosition)
        {
            allRows.Add(newRow);
            newRow.SendAssignedCells(Enumerable.Range(StartPosition, 9).ToArray());
        }

        public void ProcessNewColumn(Column newColumn, int columnNumber)
        {
            allColumns.Add(newColumn);
            int[] positions = {
                columnNumber,
                columnNumber + 9,
                columnNumber + 18,
                columnNumber + 27,
                columnNumber + 36,
                columnNumber + 45,
                columnNumber + 54,
                columnNumber + 63,
                columnNumber + 72 };
            newColumn.SendAssignedCells(positions);
        }

        public Row RequestRow(int cellNumber)
        {
            int associatedRowNumber = -1; //I chose a random number that isn't valid

            switch (cellNumber)
            {
                case int n when (n < 9):
                    associatedRowNumber = 0;
                    break;

                case int n when (n >= 9 && n < 18):
                    associatedRowNumber = 1;
                    break;

                case int n when (n >= 18 && n < 27):
                    associatedRowNumber = 2;
                    break;

                case int n when (n >= 27 && n < 36):
                    associatedRowNumber = 3;
                    break;

                case int n when (n >= 36 && n < 45):
                    associatedRowNumber = 4;
                    break;

                case int n when (n >= 45 && n < 54):
                    associatedRowNumber = 5;
                    break;

                case int n when (n >= 54 && n < 63):
                    associatedRowNumber = 6;
                    break;

                case int n when (n >= 63 && n < 72):
                    associatedRowNumber = 7;
                    break;

                case int n when (n >= 72 && n < 81):
                    associatedRowNumber = 8;
                    break;

                default:
                    return null;
            }

            return allRows.Single(row => row.rowNumber == associatedRowNumber);
        }

        public Column RequestColumn(int cellNumber)
        {
            int associatedColumnNumber = -1; //I chose a random number that isn't valid

            switch (cellNumber)
            {
                case int n when (n % 9 == 0):
                    associatedColumnNumber = 0;
                    break;

                case int n when (n % 9 == 1):
                    associatedColumnNumber = 1;
                    break;

                case int n when (n % 9 == 2):
                    associatedColumnNumber = 2;
                    break;

                case int n when (n % 9 == 3):
                    associatedColumnNumber = 3;
                    break;

                case int n when (n % 9 == 4):
                    associatedColumnNumber = 4;
                    break;

                case int n when (n % 9 == 5):
                    associatedColumnNumber = 5;
                    break;

                case int n when (n % 9 == 6):
                    associatedColumnNumber = 6;
                    break;

                case int n when (n % 9 == 7):
                    associatedColumnNumber = 7;
                    break;

                case int n when (n % 9 == 8):
                    associatedColumnNumber = 8;
                    break;

                default:
                    return null;
            }

            return allColumns.Single(column => column.columnNumber == associatedColumnNumber);
        }

        internal List<Row> GetAllRows() //for test
        {
            return allRows;
        }

        internal List<Column> GetAllColumns() //for test
        {
            return allColumns;
        }
    }
}
