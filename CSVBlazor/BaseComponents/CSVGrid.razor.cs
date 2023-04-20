using CSVBlazor.Data;
using Microsoft.AspNetCore.Components;

namespace CSVBlazor.BaseComponents
{
    public partial class CSVGrid<TItem> : ComponentBase
    {
        private DataSourceParameter _gridInfo = new DataSourceParameter();

        [Parameter]
        public DataSourceResult<TItem> DataSource { get; set; }

        [Parameter]
        public RenderFragment<TItem> Columns { get; set; }

        [Parameter]
        public bool Paging { get; set; }

        [Parameter]
        public string PageSize { get; set; } = "10";

        [Parameter]
        public EventCallback<DataSourceParameter> Callback { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _gridInfo.Page = 1;
            if (PageSize.Equals("All", StringComparison.OrdinalIgnoreCase))
                _gridInfo.PageSize = int.MaxValue;
            else if (int.TryParse(PageSize, out var pageSize) && pageSize > 0)
                _gridInfo.PageSize = pageSize;
            else
                throw new ArgumentException("Invalid page size!");

            await Callback.InvokeAsync(_gridInfo);
        }

        private async Task OnPaginationChange(int page, int pageSize)
        {
            _gridInfo.Page = page;
            _gridInfo.PageSize = pageSize;
            await Callback.InvokeAsync(_gridInfo);
        }
    }
}
