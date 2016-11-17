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

            int userNameIntCheck = 0;
            if (userNameTextBox.Text.Trim().Length == 0)
            {
                return;
            }
            if(!int.TryParse(userNameTextBox.Text, out userNameIntCheck))
            {
                return;
            }
            
            //Username check
            if(userNameTextBox.Text == "Advisor")
            {

            }

        }

      
    }
}