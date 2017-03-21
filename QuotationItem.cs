using PCQuotation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCQuotation
{
    public class QuotationItem : IQuotationItem
    {
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
        public string TotalAmount { get; set; }

        public override string ToString()
        {
            int qtyNum;
            if( int.TryParse(Quantity, out qtyNum) && qtyNum > 1)
            {
                return $"{Name} (x{qtyNum}) {TotalAmount}";
            }
            return $"{Name} {TotalAmount}";
        }
    }
}
