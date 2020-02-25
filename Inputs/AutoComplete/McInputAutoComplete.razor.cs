using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MC.Blazor
{
    public class McInputAutoCompleteBase : InputBase<string>
    {
        [Parameter] public string Id { get; set; }
        [Parameter] public string InputCssClass { get; set; }
        [Parameter] public Dictionary<string, string> Items { get; set; }
        [Parameter] public Expression<Func<string>> ValidationFor { get; set; }
        [Parameter] public EventCallback<string> OnItemSelected { get; set; }
        [Parameter] public EventCallback<string> OnTextChanged { get; set; }

        protected object SelectedId { get; set; }

        protected override bool TryParseValueFromString(string value, out string result, out string validationErrorMessage)
        {
            result = value;
            validationErrorMessage = null;
            return true;
        }

        protected async Task OnTextChangedVoid(string value)
        {
            await OnTextChanged.InvokeAsync(value);
        }

        protected async Task OnSelected(string value)
        {
            Items = null;
            CurrentValue = value;
            await OnItemSelected.InvokeAsync(value);

        }

        protected void OnLostFocus()
        {
            Items = null;
            SelectedId = null;
            CurrentValue = string.Empty;
        }
    }
}
