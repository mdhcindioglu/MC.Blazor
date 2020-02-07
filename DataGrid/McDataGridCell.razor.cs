using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MC.Blazor
{
    public class McDataGridCellBase : ComponentBase
    {
        [CascadingParameter(Name = "Result")]
        protected McDataGridResponse<object> Response { get; set; }
        [CascadingParameter(Name = "Item")]
        protected object Item { get; set; }
        [CascadingParameter(Name = "Col")]
        protected McDataGridColumn Col { get; set; }

        [Parameter] public EventCallback<string> OnDeleteClick { get; set; }
        [Parameter] public EventCallback<string> OnUpdateClick { get; set; }
        [Parameter] public EventCallback<McDataGridCellCheckboxState> OnChangedCheckbox { get; set; }
        protected string cssFormat;
        object name;

        protected override void OnInitialized()
        {
            cssFormat = Col.CssFormating.ToLower();
            name = Item.GetValue(Col.Name);
            if (Col.Type == typeof(decimal))
            {
                decimal value = Item.GetDecimal(Col.Name);
                if (cssFormat.Contains("text-value"))
                {
                    cssFormat = cssFormat.Replace("text-value", value >= 0 ? "text-info" : "text-danger");
                    if (value < 0) name = (-value).ToString();
                }

                if (value == 0 && Col.HideZiro)
                    name = string.Empty;
                else
                    name = value.ToString();
            }
            else if (Col.Type == typeof(DateTime))
            {
                name = ((DateTime)name);// My.GetDateTime(Item, Col.Name);
            }
        }

        protected async Task OnDelete(string id)
        {
            (Item as McBaseResponse).IsDeleting = true;
            await OnDeleteClick.InvokeAsync(id);
        }

        protected async Task OnUpdate(string id)
        {
            (Item as McBaseResponse).IsEditing = true;
            await OnUpdateClick.InvokeAsync(id);
        }

        protected async Task OnChangedCheckboxVoid(McDataGridCellCheckboxState state)
        {
            await OnChangedCheckbox.InvokeAsync(state);
        }
    }
}
