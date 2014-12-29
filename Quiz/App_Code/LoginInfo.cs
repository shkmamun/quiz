using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiz
{
    public class LoginInfo
    {
        public LoginInfo()
        {
        }

        public static void SetLoginInfo(UserInfo userInfo)
        {
            HttpContext.Current.Session["userinfo"] = userInfo;
        }

        public static UserInfo Current
        {
            get
            {
                if (HttpContext.Current.Session["userinfo"] == null)
                {
                    HttpContext.Current.Response.Redirect("~/Login.aspx/?ReturnURL="+HttpContext.Current.Request.Url.AbsoluteUri);
                }
                return (UserInfo)HttpContext.Current.Session["userinfo"];
            }
        }
    }

}