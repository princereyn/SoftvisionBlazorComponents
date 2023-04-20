using CSVBlazor.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace CSVBlazor.BaseComponents
{
    public partial class Pagination : ComponentBase
    {
        private int _pageCount;
        ElementReference _pageFirst,
                         _pagePrev,
                         _pageNext,
                         _pageLast,
                         _pageInput,
                         _pageSizeInput;

        [Parameter]
        public int Page { get; set; } = 1; // Current page

        [Parameter]
        public int PageSize { get; set; } // Items per page

        [Parameter]
        public int ItemCount { get; set; }

        [Parameter]
        public EventCallback<DataSourceParameter> Callback { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await EnableOrDisableNavigationButtons();
        }

        protected override void OnParametersSet()
        {
            _pageCount = (int)Math.Ceiling((double)ItemCount / PageSize);
        }

        private async void OnPageChange(ChangeEventArgs e)
        {
            if (int.TryParse(e.Value?.ToString(), out var page) &&
                page > 0 && page <= _pageCount)
            {
                Page = page;
                await Callback.InvokeAsync(new DataSourceParameter { Page = Page, PageSize = PageSize });
            }
            else
            {
                await _jsHelper.SetInputValue(_pageInput, Page);
            }
        }

        private async void OnPageSizeChange(ChangeEventArgs e)
        {
            var isValid = true;
            var newValue = e.Value?.ToString();

            if (newValue!.Equals("All", StringComparison.OrdinalIgnoreCase))
                PageSize = int.MaxValue;
            else if (int.TryParse(newValue, out var pageSize) && pageSize > 0)
                PageSize = pageSize;
            else
            {
                isValid = false;
                await _jsHelper.SetInputValue(_pageSizeInput, PageSize == int.MaxValue ? "All" : PageSize.ToString());
            }

            if (isValid)
            {
                Page = 1;
                await Callback.InvokeAsync(new DataSourceParameter { Page = Page, PageSize = PageSize });
            }
        }

        private async void OnPageClick(MouseEventArgs e, int page)
        {
            if (page > 0 && page <= _pageCount &&
                page != Page)
            {
                Page = page;
                await Callback.InvokeAsync(new DataSourceParameter { Page = Page, PageSize = PageSize });
            }
        }

        private async void OnPageSizeClick(MouseEventArgs e, int pageSize)
        {
            if (pageSize != PageSize)
            {
                Page = 1;
                PageSize = pageSize;
                await Callback.InvokeAsync(new DataSourceParameter { Page = Page, PageSize = PageSize });
            }
        }

        private async void OnRefresh()
        {
            await Callback.InvokeAsync(new DataSourceParameter { Page = Page, PageSize = PageSize });
        }

        private async Task EnableOrDisableNavigationButtons()
        {
            if (Page > 1)
            {
                await _jsHelper.EnableNavButton(_pageFirst);
                await _jsHelper.EnableNavButton(_pagePrev);
            }
            else
            {
                await _jsHelper.EnableNavButton(_pageFirst, false);
                await _jsHelper.EnableNavButton(_pagePrev, false);
            }
            if (Page < _pageCount)
            {
                await _jsHelper.EnableNavButton(_pageNext);
                await _jsHelper.EnableNavButton(_pageLast);
            }
            else
            {
                await _jsHelper.EnableNavButton(_pageNext, false);
                await _jsHelper.EnableNavButton(_pageLast, false);
            }
        }
    }
}
