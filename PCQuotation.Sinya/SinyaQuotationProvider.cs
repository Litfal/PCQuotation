using HtmlAgilityPack;
using PCQuotation.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PCQuotation.Sinya
{
    public class SinyaQuotationProvider
    {
        public IQuotation Parse(System.Windows.Forms.HtmlDocument wbHtmlDoc)
        {
            Quotation q = new Quotation();

            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(wbHtmlDoc.Body.OuterHtml);

            // find select text span of quantity
            var nodes = htmlDoc.DocumentNode.SelectNodes("//span[contains(@class,'current')]");

            if (nodes == null) throw new Exception("Can't find text span of quantity.");

            foreach (var quantitySpanNode in nodes)
            {
                string quantityText = quantitySpanNode.InnerText.Trim();
                // if there is not quantity text, notstock
                int qry;
                if (!int.TryParse(quantityText, out qry)) continue;
                // if (string.IsNullOrWhiteSpace((quantityText))) continue;

                // get parent of name / price ...
                var parentDiv = quantitySpanNode.SelectSingleNode("../../..");

                // get prod name
                var prodNameAnchor = parentDiv.SelectSingleNode(".//div[contains(@class, 'prod_name_choose')]/a");
                if (null == prodNameAnchor) throw new Exception("Can't find prod name anchor.");
                string prodName = prodNameAnchor.InnerText.Trim();

                // get diy price
                var diyPriceDiv = parentDiv.SelectSingleNode(".//div[contains(@class, 'diy_price')]");
                if (null == diyPriceDiv) throw new Exception("Can't find diy price div.");

                string diyPrice = diyPriceDiv.InnerText.Trim();

                q.Items.Add(new QuotationItem()
                {
                    Name = prodName,
                    Quantity = quantityText,
                    TotalAmount = diyPrice,
                });
            }

            var totalPriceSpan = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='subtotal']");
            if (null != totalPriceSpan) q.TotalAmount = totalPriceSpan.InnerText.Trim();


            return q;

        }


    }
}
