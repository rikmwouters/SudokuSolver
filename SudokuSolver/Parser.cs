

namespace SudokuSolver
{
    class Parser
    {
        private Cell startCell;

        public Parser(string input)
        {
            ParseInput(input);
            CreateFirstGroups();
        }

        private void ParseInput(string input)
        {
            char[] charArray = input.ToCharArray();
            int cellNumber = 0;
            startCell = new Cell();
            Cell previousCell = startCell;

            foreach(char value in charArray)
            {
                Cell currentCell = new Cell(value, cellNumber);
                previousCell.SetNextCell(currentCell);
                previousCell = currentCell;
                cellNumber++;
            }

            startCell = startCell.GetNextCell();
            previousCell.SetNextCell(startCell);
        }

        private void CreateFirstGroups()
        {
            Row row = new Row(0, startCell);
            Column column = new Column(0, startCell);
            Block block = new Block(0, startCell);
        }

        public Cell GetStartCell() //for test
        {
            return startCell;
        }
    }
}
