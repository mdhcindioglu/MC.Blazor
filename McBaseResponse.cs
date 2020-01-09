using System;
using System.Collections.Generic;
using System.Text;

namespace MC.Blazor
{
    public class McBaseResponse
    {
        public UnitState State { get; set; }
        public bool IsDeleting { get; set; }
        public bool IsEditing { get; set; }
    }

    public enum UnitState
    {
        Failed = -1,
        Success = 0,
        NotFound = 1,
        AddedBefore = 2,
    }
}
