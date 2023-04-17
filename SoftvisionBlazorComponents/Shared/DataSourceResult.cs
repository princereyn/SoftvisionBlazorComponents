using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftvisionBlazorComponents.Shared
{
    public class DataSourceResult<TEntity>
    {
        public int Count { get; set; }

        public IEnumerable<TEntity> Items { get; set; }
    }
}
