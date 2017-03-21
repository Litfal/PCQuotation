using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCQuotation.Interface
{
    public interface IQuotation
    {
        IEnumerable<IQuotationItem> Items { get; }

        string TotalAmount { get; }
    }
}
