using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
 

namespace Quiz
{
    public class ParticipantPage : System.Web.UI.Page
    {

        public string CurrentUserName
        {
            get { return LoginInfo.Current.UserName; }
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session["userinfo"] == null)
                {
                    HttpContext.Current.Response.Redirect("/Login.aspx",false);
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}