using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DeskMultipassSpike;
using System.Configuration;

namespace SupportCenterKnowledgeBase
{
    public partial class JoeysHackathon :System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty((string)Session["userType"]))
                {
                    Response.Redirect("/Default.aspx");
                }
                else
                {
                    brandLabel.Text = Session["userType"].ToString();
                }

                
            }
        }

        private void Temp()
        {
            /*var multiPassGenerator = new MultipassGenerator(ConfigurationManager.AppSettings["siteName"], ConfigurationManager.AppSettings["apiKey"]);
            string url = multiPassGenerator.GenerateLine(tbName.Text, tbEmail.Text, tbLevel.Text, ddlBrand.SelectedValue);
            Response.Redirect(url);*/
        }

        protected void brandLinkButton_Click(object sender, EventArgs e)
        {

        }
    }
}