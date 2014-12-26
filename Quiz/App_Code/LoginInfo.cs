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
                    HttpContext.Current.Response.Redirect("~/Login.aspx");
                }
                return (UserInfo)HttpContext.Current.Session["userinfo"];
            }
        }
    }
    public class UserInfo
    {
        public string LoginName { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Email { set; get; }
        public int RoleId { set; get; }
    }
}