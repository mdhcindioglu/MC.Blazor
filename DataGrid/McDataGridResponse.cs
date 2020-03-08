using System;
using System.Collections.Generic;
using System.Text;

namespace MC.Blazor
{
    public class McDataGridResponse<T>
    {
        public IEnumerable<T> Items { get; set; } = new List<T>();
        public int Count { get; set; }
        public int CountFilter { get; set; }
        public int RecPerPage { get; set; }
        public int TotalPageQuantity { get; set; }
        public int CurrentPage { get; set; } = 1;

        public string Search { get; set; } = string.Empty;
        public string OrderBy { get; set; } = "Id";
        public McOrderDirect OrderDirect { get; set; } = McOrderDirect.Asc;

        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public decimal Total { get; set; }

        public int FirstRec => (int)(CurrentPage - 1) * RecPerPage + 1;
        public int LastRec => FirstRec + RecPerPage - 1 <= CountFilter ? FirstRec + RecPerPage - 1 : CountFilter;

        public bool CanCreate { get; set; }
        public bool IsCreating { get; set; }
        public bool IsRefreshing { get; set; }
    }
    public enum McOrderDirect
    {
        Asc,
        Desc,
    }
}
