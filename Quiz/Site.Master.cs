using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (LoginInfo.Current != null)
                {
                    this.lblWelcome.Text = "Welcome " + LoginInfo.Current.UserName.ToString();
                }
            }

        }
        protected void lnkSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();           
            Page.Response.Redirect("~/Login.aspx");
        }
    }
}