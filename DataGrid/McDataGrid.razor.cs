using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MC.Blazor
{
    public class McDataGridBase<IType>: ComponentBase
    {
        [CascadingParameter(Name = "Result")]
        protected McDataGridResponse<IType> Response { get; set; }
        [Parameter] public bool EnablePagination { get; set; } = true;
        [Parameter] public string Title { get; set; }
        [Parameter] public string CardCssClass { get; set; }
        [Parameter] public string TitleCssClass { get; set; }
        [Parameter] public List<McDataGridColumn> Columns { get; set; }
        [Parameter] public bool HideCreate { get; set; }
        [Parameter] public bool IsLoading { get; set; }

        [Parameter] public EventCallback<object> OnUpdateClicked { get; set; }
        [Parameter] public EventCallback<object> OnDeleteClicked { get; set; }
        [Parameter] public EventCallback OnCreateClicked { get; set; }
        [Parameter] public EventCallback<McDataGridResponse<IType>> OnRefreshClicked { get; set; }
        [Parameter] public EventCallback<int> OnRecordPerPageChanged { get; set; }
        [Parameter] public EventCallback<string> OnSearchClicked { get; set; }
        [Parameter] public EventCallback<McDataGridResponse<IType>> OnResetSearchClicked { get; set; }
        [Parameter] public EventCallback<McDataGridCellCheckboxState> OnChangedCheckbox { get; set; }

        [Parameter] public RenderFragment McHeader { get; set; }
        [Parameter] public RenderFragment TableHeader { get; set; }        
        [Parameter] public RenderFragment TableFirstRow { get; set; }
        [Parameter] public RenderFragment McFooter { get; set; }

        protected async Task OnDelete(object id)
        {
            await OnDeleteClicked.InvokeAsync(id);
        }

        protected async Task OnUpdate(object id)
        {
            await OnUpdateClicked.InvokeAsync(id);
        }

        protected async Task OnRefresh()
        {
            Response.IsRefreshing = true;
            await OnRefreshClicked.InvokeAsync(Response);
            Response.IsRefreshing = false;
        }

        protected async Task OnSearch(string searchText)
        {
            Response.Search = searchText;
            await OnSearchClicked.InvokeAsync(searchText);
        }

        protected async Task OnResetSearch()
        {
            Response.Search = string.Empty;
            await OnResetSearchClicked.InvokeAsync(Response);
        }
    
        protected async Task OnChangedCheckboxVoid(McDataGridCellCheckboxState state)
        {
            await OnChangedCheckbox.InvokeAsync(state);
        }

        protected async Task OnRecordPerPageChangedVoid(int RecordPerPage)
        {
            await OnRecordPerPageChanged.InvokeAsync(RecordPerPage);
        }
    }
}
