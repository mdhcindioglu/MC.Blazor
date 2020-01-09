using System;
using System.Collections.Generic;
using System.Text;

namespace MC.Blazor
{
    public class McAutoCompleteObject
    {
        public McAutoCompleteObject(string id, string text)
        {
            Id = id;
            Text = text;
        }
        
        public McAutoCompleteObject()
        {
            Id = string.Empty;
            Text = string.Empty;
        }

        public string Id { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
