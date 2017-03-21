using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCQuotationConverter
{
    public partial class PCQuotationConverter : Form
    {
        public PCQuotationConverter()
        {
            InitializeComponent();
            webBrowser1.Navigated += WebBrowser1_Navigated;
        }

        private async void btn_convert_Click(object sender, EventArgs e)
        {
            // webBrowser1.Navigate(@"http://coolpc.tw/tmp/1489501146278745.htm");
            // webBrowser1.Navigate(@"https://www.sinya.com.tw/diy/diy_search/1489501043");
            webBrowser1.Navigate(textBox1.Text);


            //PCQuotation.CoolPC.CoolPCQuotationProvider coolPcProvider = new PCQuotation.CoolPC.CoolPCQuotationProvider();
            //var q = await coolPcProvider.ParseAsync(@"http://coolpc.tw/tmp/1489501146278745.htm");
            //textBox2.Text = q.ToString();
        }

        private void WebBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PCQuotation.CoolPC.CoolPCQuotationProvider coolPcProvider = new PCQuotation.CoolPC.CoolPCQuotationProvider();
            //PCQuotation.Sinya.SinyaQuotationProvider sinyaQuotationProvider = new PCQuotation.Sinya.SinyaQuotationProvider();

            try
            {
                var q = coolPcProvider.Parse(webBrowser1.Document);
                textBox2.Text = q.ToString();
            }
            catch (Exception ex)
            {
                textBox2.Text = ex.Message;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
