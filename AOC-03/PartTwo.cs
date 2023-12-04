namespace AOC_01
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class PartTwo
    { 
        public int Handle()
        {
            int sum = 0;
            var lines = File.ReadAllLines("input.txt");

            var cells = this.ReadCells(lines);

            var stars = this.FindStarts(cells);

            foreach (var star in stars)
            {
                this.SetGuid(cells, star.Guid, star.Row, star.Col);
            }

            var numbers = this.FindNumbers(cells);
                        
            sum = this.CountNumbers(numbers);

            return sum;
        }

        private void SetGuid(Cell[,] cells, Guid guid, int row, int col)
        {
            if (row < 0) return;
            if (col < 0) return;
            if (row > cells.GetLength(0) - 1) return;
            if (col > cells.GetLength(1) - 1) return;

            var cell = cells[row, col];

            if (cell.CheckedTimes > 0) return;

            cell.CheckedTimes++;

            if (cell.IsDigit && cell.GuidIsEmpty)
            {
                cell.Guid = guid;
            }

            if (cell.IsDigit || cell.IsStar)
            {
                this.SetGuid(cells, guid, row - 1, col - 1);
                this.SetGuid(cells, guid, row - 1, col);
                this.SetGuid(cells, guid, row - 1, col + 1);

                this.SetGuid(cells, guid, row, col - 1);
                this.SetGuid(cells, guid, row, col + 1);

                this.SetGuid(cells, guid, row + 1, col - 1);
                this.SetGuid(cells, guid, row + 1, col);
                this.SetGuid(cells, guid, row + 1, col + 1);
            }
        }

        private List<Cell> FindStarts(Cell[,] cells)
        {
            var stars = new List<Cell>();
            foreach (var cell in cells)
            {
                if (cell.IsStar)
                {
                    cell.Guid = Guid.NewGuid();
                    stars.Add(cell);
                }
            }
            return stars;
        }

        private int CountNumbers(Dictionary<Guid, List<int>> numbers)
        {
            var sum = 0;

            foreach (var number in numbers.Keys)
            {
                if (numbers[number].Count < 2)
                {
                    continue;
                }

                sum += numbers[number][0] * numbers[number][1];
            }

            return sum;
        }

        private Dictionary<Guid, List<int>> FindNumbers(Cell[,] cells)
        {
            var dict = new Dictionary<Guid, List<int>>();
            
            var s = string.Empty;
            var currGuid = Guid.Empty;
            
            for (int row = 0; row < cells.GetLength(0); row++)
            {
                this.SetNumber(dict, s, currGuid);

                s = string.Empty;
                currGuid = Guid.Empty;

                for (int col = 0; col < cells.GetLength(1); col++)
                {
                    var cell = cells[row, col];
                    if (cell.GuidIsEmpty == false && cell.IsDigit)
                    {
                        s += cell.Value;
                        currGuid = cell.Guid;
                    }
                    else
                    {
                        this.SetNumber(dict, s, currGuid);
                        
                        s = string.Empty;
                        currGuid = Guid.Empty;
                    }
                }
            }

            return dict;
        }

        private void SetNumber(Dictionary<Guid, List<int>> dict, string number, Guid guid)
        {
            if(number.Length==0)
            {
                return;
            }
            if(dict.ContainsKey(guid) == false)
            {
                dict.Add(guid, new List<int>());
            }
            dict[guid].Add(int.Parse(number));
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
    }
}
