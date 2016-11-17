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

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {

            // Error checking for no value
            if (userNameTextBox.Text.Trim().Length == 0)
            {
                return;
            }

            LoginCheck();
        }

        private const string _DeskUrl =
      "https://{0}.desk.com/customer/authentication/multipass/callback?multipass={1}&signature={2}";
        int mSiteKey = 1;
        int multipass = 12;
        int signature = 123;

        int emSiteKey = 2;
        int emultipass = 23;
        int esignature = 234;

        int imSiteKey = 3;
        int imultipass = 34;
        int isignature = 345;

        private string LoginCheck()
        {
           
            //Check for Brand 
            if (userNameTextBox.Text == "Advisor" && passwordTextBox.Text == "Advisor")
            {
                return resultLabel.Text = string.Format(_DeskUrl, mSiteKey, multipass, signature);
            }
            else if (userNameTextBox.Text == "Eqisarian" && passwordTextBox.Text == "Eqisarian")
            {
                return resultLabel.Text = string.Format(_DeskUrl, emSiteKey, emultipass, esignature);
            }
            else if (userNameTextBox.Text == "Investor" && passwordTextBox.Text == "Investor")
            {
                return resultLabel.Text = string.Format(_DeskUrl, imSiteKey, imultipass, isignature);
            }
            else
            {
                return resultLabel.Text = "ERROR";
            }
        }
    }
}