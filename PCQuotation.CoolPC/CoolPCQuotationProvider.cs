using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCQuotation.Interface;
using System.Net.Http;
using System.Windows.Forms;

namespace PCQuotation.CoolPC
{
    public class CoolPCQuotationProvider : IQuotationProvider<HtmlDocument>
    {
        public IQuotation Parse(HtmlDocument htmlDoc)
        {
            
            // [1].GetElementsByTagName("td")[2].InnerHtml
            var rows = htmlDoc.GetElementById("CPrice").GetElementsByTagName("tr");
            if (null == rows || rows.Count <= 2) throw new Exception("Parse failed, can't find quotation table.");
            Quotation q = new Quotation();

            for(int i = 1; i < rows.Count - 1; i++)  // skip header and total
            {
                q.Items.Add(parseItemRow(rows[i]));
            }

            try
            {
                q.TotalAmount = htmlDoc.GetElementById("t").InnerText;
            }
            catch
            {
                throw new Exception("Parse total amount failed.");
            }
            return q;
        }

        private QuotationItem parseItemRow(HtmlElement itemRow)
        {
            try
            {
                var td = itemRow.GetElementsByTagName("td");
                return new QuotationItem()
                {
                    Name = td[1].InnerText,
                    Quantity = td[2].InnerText,
                    UnitPrice = td[3].InnerText,
                    TotalAmount = td[4].InnerText,
                };
            }
            catch
            {
                throw new Exception("Parse item failed. html=" + itemRow.OuterHtml);
            }
        }

    }
}
