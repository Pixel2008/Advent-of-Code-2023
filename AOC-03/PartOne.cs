namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class PartOne
    {
        public int Handle()
        {
            int sum = 0;
            var lines = File.ReadAllLines("input.txt");

            var cells = this.ReadCells(lines);


            while (this.NotBelongsExisted(cells))
            {
                this.CheckAllCells(cells);
            }

            var stringLines = this.BuildLines(cells);

            sum = this.CheckStringLines(stringLines);

            return sum;
        }

        private int CheckStringLines(List<string> lines)
        {
            var sum = 0;
            foreach (var line in lines)
            {
                var numbers = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var number in numbers)
                {
                    sum += int.Parse(number);
                }
            }
            return sum;
        }

        private Cell[,] ReadCells(string[] lines)
        {
            var numRows = lines.Length;
            var numCols = lines[0].Length;

            var cells = new Cell[numRows, numRows];

            for (int row = 0; row < lines.Length; row++)
            {
                var line = lines[row];
                for (int col = 0; col < line.Length; col++)
                {
                    var cell = new Cell(row, col);
                    cell.Value = line[col].ToString();
                    cells[row, col] = cell;
                }
            }

            return cells;
        }

        private void CheckAllCells(Cell[,] cells)
        {
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    var cell = cells[row, col];
                    if (cell.IsSymbol || cell.BelongsToSymbol)
                    {
                        this.SetBelongsToSymbol(cells, row, col);
                    }
                }
            }
        }

        private void SetBelongsToSymbol(Cell[,] cells, int row, int col)
        {
            int maxRows = cells.GetLength(0);
            int maxCols = cells.GetLength(1);

            if (row > 0 && col > 0)
            {
                cells[row - 1, col - 1].BelongsToSymbol = true;
            }
            if (row > 0)
            {
                cells[row - 1, col].BelongsToSymbol = true;
            }
            if (row > 0 && col < maxCols - 1)
            {
                cells[row - 1, col + 1].BelongsToSymbol = true;
            }

            if (col > 0)
            {
                cells[row, col - 1].BelongsToSymbol = true;
            }
            cells[row, col].BelongsToSymbol = true;
            if (col < maxCols - 1)
            {
                cells[row, col + 1].BelongsToSymbol = true;
            }

            if (row < maxRows - 1 && col > 0)
            {
                cells[row + 1, col - 1].BelongsToSymbol = true;
            }
            if (row < maxRows - 1)
            {
                cells[row + 1, col].BelongsToSymbol = true;
            }
            if (row < maxRows - 1 && col < maxCols - 1)
            {
                cells[row + 1, col + 1].BelongsToSymbol = true;
            }

            /*
            -1,-1   -1,0   -1,+1
            0,-1    0,0    0,+1
            +1,-1   +1,0   +1,+1
            */
        }

        private bool NotBelongsExisted(Cell[,] cells)
        {
            foreach (Cell cell in cells)
            {
                cell.CheckedTimes++;
                if (cell.IsDot == false && cell.BelongsToSymbol == false && cell.CheckedTimes < 9)
                {
                    return true;
                }
            }
            return false;
        }
        private List<string> BuildLines(Cell[,] cells)
        {
            var lines = new List<string>();

            for (int row = 0; row < cells.GetLength(0); row++)
            {
                var s = string.Empty;
                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    var cell = cells[row, col];

                    s += cell.BelongsToSymbol && cell.IsDigit
                        ? cell.Value
                        : " ";
                }
                lines.Add(s);
            }

            return lines;
        }
    }
}
