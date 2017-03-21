using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCQuotation.Interface
{
    public interface IQuotationItem
    {
        string Name { get;  }
        string Quantity { get;  }
        string UnitPrice { get;  }
        string TotalAmount { get;  }
    }
}
