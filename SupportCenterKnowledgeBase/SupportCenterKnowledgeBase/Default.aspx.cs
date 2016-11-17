using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupportCenterKnowledgeBase
{
    public partial class Default :System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            InitializingPageonFirstLoad();
        }

        private void InitializingPageonFirstLoad()
        {

            if(!IsPostBack)
            Session["userType"] = userNameTextBox.Text = passwordTextBox.Text = string.Empty;
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private const string _DeskUrl =
      "https://{0}.desk.com/customer/authentication/multipass/callback?multipass={1}&signature={2}";
        int mSiteKey = 1;
        int multipass = 12;
        int signature = 123;

        private string LoginCheck()
        {
           
            //Check for Brand 
            if (userNameTextBox.Text == "Advisor" && passwordTextBox.Text == "Advisor")
            {
                GoToUserTypePage("Advisor");
                return resultLabel.Text = string.Format(_DeskUrl, mSiteKey, multipass, signature);
            }
            else if (userNameTextBox.Text == "Eqisarian" && passwordTextBox.Text == "Eqisarian")
            {
                GoToUserTypePage("Eqisarian");
                return resultLabel.Text = string.Format(_DeskUrl, mSiteKey, multipass, signature);
            }
            else if (userNameTextBox.Text == "Investor" && passwordTextBox.Text == "Investor")
            {
                GoToUserTypePage("Investor");
                return resultLabel.Text = string.Format(_DeskUrl, mSiteKey, multipass, signature);
            }
            else
            {
                return resultLabel.Text = "ERROR";
            }
        }

        private void GoToUserTypePage(string userType)
        {
            Session["userType"] = userType;
            Response.Redirect("/JoeysHackathon.aspx");
        }
    }
}