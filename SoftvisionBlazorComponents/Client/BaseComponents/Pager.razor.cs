using Microsoft.AspNetCore.Components;
using SoftvisionBlazorComponents.Shared.Data;

namespace SoftvisionBlazorComponents.Client.BaseComponents
{
	public partial class Pager : ComponentBase
	{
		[Parameter]
		public PagedResultBase Result { get; set; }

		[Parameter]
		public Action<int> PageChanged { get; set; }

		protected int StartIndex { get; private set; } = 0;
		protected int FinishIndex { get; private set; } = 0;

		protected override void OnParametersSet()
		{
			StartIndex = Math.Max(Result.CurrentPage - 5, 1);
			FinishIndex = Math.Min(Result.CurrentPage + 5, Result.PageCount);
			base.OnParametersSet();
		}

		protected void PagerButtonClicked(int page)
		{
			PageChanged?.Invoke(page);
		}
	}
}
