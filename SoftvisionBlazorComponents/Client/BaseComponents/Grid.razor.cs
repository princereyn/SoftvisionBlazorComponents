using Microsoft.AspNetCore.Components;

namespace SoftvisionBlazorComponents.Client.BaseComponents
{
    public partial class Grid<TItem> : ComponentBase
    {
        [Parameter]
        public IList<TItem> Items { get; set; }

        [Parameter]
        public RenderFragment<TItem> Columns { get; set; }

        [Parameter]
        public bool Paging { get; set; }
    }
}
