namespace AOC_01
{
    using System;

    internal class Cell
    {
        public int Col { get; }
        public int Row { get; }
        public string Value { get; set; }
        public bool IsDot => Value == ".";

        public bool IsStar => Value == "*";

        public bool IsSymbol
        {
            get
            {
                if (this.IsDot)
                {
                    return false;
                }
                if (int.TryParse(this.Value, out var _))
                {
                    return false;
                }
                return true;
            }
        }
        public bool IsDigit => int.TryParse(this.Value, out _);
        public int CheckedTimes { get; set; }
        private bool _belongsToSymbol = false;
        public bool BelongsToSymbol
        {
            get
            {
                return this._belongsToSymbol;
            }
            set
            {
                this._belongsToSymbol = value && this.IsDot == false;
            }
        }
        public bool GuidIsEmpty => this.Guid == Guid.Empty;

        public Guid Guid { get; set; }

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }
    }
}
