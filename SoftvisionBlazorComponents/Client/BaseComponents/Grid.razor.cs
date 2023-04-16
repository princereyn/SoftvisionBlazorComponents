using Microsoft.AspNetCore.Components;

namespace SoftvisionBlazorComponents.Client.BaseComponents
{
    public partial class Grid<TItem> : ComponentBase
    {
        private GridInfo _gridInfo = new GridInfo();

        [Parameter]
        public IList<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment<TItem> Columns { get; set; }

        [Parameter]
        public bool Paging { get; set; }

        [Parameter]
        public string PageSize { get; set; } = "10";

        protected override void OnInitialized()
        {
            _gridInfo.Page = 1;
            if (PageSize.Equals("All", StringComparison.OrdinalIgnoreCase))
                _gridInfo.PageSize = int.MaxValue;
            else if (int.TryParse(PageSize, out var pageSize) && pageSize > 0)
                _gridInfo.PageSize = pageSize;
            else
                throw new ArgumentException("Invalid page size!");
        }

        private void OnPaginationChange(int page, int pageSize)
        {
            _gridInfo.Page = page;
            _gridInfo.PageSize = pageSize;
            // Load data for the new page that becomes the current page
        }
    }

    public class GridInfo
    {
        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
