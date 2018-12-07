

namespace SudokuSolver
{
    class Parser
    {
        public Cell StartCell { get; private set; }

        public Parser(string input)
        {
            char[] charArray = input.ToCharArray();
            StartCell = new Cell();

            RunParser(charArray, 0, StartCell);
            CreateFirstGroups();
            new Solver(StartCell);
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
            StartCell = StartCell.GetNextCell();
            finalCell.SetNextCell(StartCell);
        }

        private void CreateFirstGroups()
        {
            new Row(0, StartCell);
            new Column(0, StartCell);
            new Block(0, StartCell);
        }

        
    }
}
