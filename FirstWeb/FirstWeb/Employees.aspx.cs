using FirstWeb.EF;
using IronPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FirstWeb
{
    public partial class Employees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HR db = new HR();
            GridView2.DataSource = db.EMPLOYEES.ToList();
            GridView2.DataBind();

            PdfPrintOptions option = new PdfPrintOptions() { 
                DPI=300
            };
            AspxToPdf.RenderThisPageAsPdf();

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            GridView2.PageSize = int.Parse(((Button)sender).Text);
        }
    }
}