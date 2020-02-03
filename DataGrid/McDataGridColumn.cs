using System;
using System.Collections.Generic;
using System.Text;

namespace MC.Blazor
{
    public class DataGridColumn
    {
        public string Title { get; set; }
        public string Name { get; set; } = "Name";
        public string FormatString { get; set; } = string.Empty;
        public string CssFormating { get; set; } = string.Empty;
        public string CssHeaderFormating { get; set; } = string.Empty;
        public Type Type { get; set; } = typeof(String);
        public int Width { get; set; } = 10;
        public ColumnKind Kind { get; set; } = ColumnKind.Normal;
        public bool HideZiro { get; set; } = true;
    }

    public enum ColumnKind { Normal, Update, Delete, Email, Phone }
}
