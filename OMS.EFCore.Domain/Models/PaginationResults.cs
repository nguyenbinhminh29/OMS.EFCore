using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMS.EFCore.Domain.Models
{
    public class PaginationResults<T>
    {
        public PaginationResults(List<T> results, int take, int totalCount)
        {
            this.Results = results;
            this.TotalResultCount = totalCount;

            if (TotalResultCount == 0 || take == 0)
            {
                TotalPageCount = 0;
                return;
            }

            TotalPageCount = (int)Math.Ceiling((decimal)TotalResultCount / take);
        }

        public List<T> Results { get; }
        public int TotalResultCount { get; }
        public int TotalPageCount { get; }
    }
}
