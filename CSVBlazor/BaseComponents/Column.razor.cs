using Microsoft.AspNetCore.Components;

namespace CSVBlazor.BaseComponents
{
    public partial class Column<TItem> : ComponentBase
    {
        [Parameter]
        public string Name { get; set; }

        [Parameter]
        public string Label { get; set; }

        [CascadingParameter]
        public TItem Item { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }
    }
}
