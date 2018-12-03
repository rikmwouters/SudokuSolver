

namespace SudokuSolver
{
    class Parser
    {
        private Cell startCell;

        public Parser(string input)
        {
            PrepareParser(input);
            CreateFirstGroups();
            Viewer viewer = new Viewer(startCell);
        }

        private void PrepareParser(string input)
        {
            char[] charArray = input.ToCharArray();
            startCell = new Cell();
            RunParser(charArray, 0, startCell);
        }

        private void RunParser(char[] charArray, int cellNumber, Cell startCell)
        {
            Cell currentCell = startCell;
            foreach (char value in charArray)
            {
                Cell nextCell = new Cell(value, cellNumber);
                currentCell.SetNextCell(nextCell);
                currentCell = nextCell;
                cellNumber++;
            }
            MakeFieldCircular(currentCell);
        }

        private void MakeFieldCircular(Cell finalCell)
        {
            startCell = startCell.GetNextCell();
            finalCell.SetNextCell(startCell);
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
