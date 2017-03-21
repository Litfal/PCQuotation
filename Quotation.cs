using PCQuotation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCQuotation
{
    public class Quotation : IQuotation
    {
        public List<QuotationItem> Items { get; set; } = new List<QuotationItem>();

        public string TotalAmount { get; set; }

        IEnumerable<IQuotationItem> IQuotation.Items
        {
            get { return Items; }
        }

        public override string ToString()
        {
            return string.Join("\r\n", Items);
        }
    }
}
