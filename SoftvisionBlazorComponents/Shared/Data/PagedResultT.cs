using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftvisionBlazorComponents.Shared.Data
{
	public class PagedResult<T> : PagedResultBase where T : class
	{
		public IList<T> Results { get; set; }

		public IList<T> AllResults { get; set; }

		public PagedResult()
		{
			Results = new List<T>();
		}
	}
}
