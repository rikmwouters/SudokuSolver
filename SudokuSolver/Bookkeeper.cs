using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    class Bookkeeper
    {
        private List<Row> allRows = new List<Row>();
        private List<Column> allColumns = new List<Column>();
        private List<Block> allBlocks = new List<Block>();

        public Bookkeeper()
        {

        }

        /// PROCESSING NEW ELEMENTS

        public void ProcessNewRow(Row newRow, int StartPosition)
        {
            allRows.Add(newRow);
            newRow.SendAssignedCells(Enumerable.Range(StartPosition, 9).ToArray());
        }

        public void ProcessNewColumn(Column newColumn, int columnNumber)
        {
            allColumns.Add(newColumn);
            int[] positions = new int[9];

            for (int i = 0; i < 9; i++)
            {
                positions[i] = columnNumber + i * 9;
            }
            newColumn.SendAssignedCells(positions);
        }

        public void ProcessNewBlock(Block newBlock, int StartPosition)
        {
            allBlocks.Add(newBlock);
            int currentPositionNumber = StartPosition;
            int[] positions = new int[9];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    currentPositionNumber = j + i * 3;
                    positions[currentPositionNumber] = j + i * 9;
                }
            }
            newBlock.SendAssignedCells(positions);
        }

        /// REQUESTING GROUPING SUGGESTION

        public Row RowSuggestion(int trial)
        {
            return allRows[trial];
        }

        public Column ColumnSuggestion(int trial)
        {
            return allColumns[trial];
        }

        public Block BlockSuggestion(int trial)
        {
            return allBlocks[trial];
        }

        /// GETTERS AND SETTERS

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
