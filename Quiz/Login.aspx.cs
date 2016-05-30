
using DataAccess;
using Entity;
using System;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Quiz
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";

            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }

            if (!IsPostBack)
            {

                HttpCookie cookRememberMe = Request.Cookies["RememberMe"];
                if (cookRememberMe != null && !string.IsNullOrWhiteSpace(cookRememberMe.Value))
                {
                    if (cookRememberMe.Value.ToLower() == "true")
                    {
                        RememberMe.Checked = true;

                        HttpCookie cookUserId = Request.Cookies["userId"];
                        HttpCookie cookPass = Request.Cookies["Pass"];

                        if (cookUserId != null && !string.IsNullOrWhiteSpace(cookUserId.Value))
                        {
                            UserName.Text = cookUserId.Value;
                        }

                        if (cookPass != null && !string.IsNullOrWhiteSpace(cookPass.Value))
                        {
                            Password.Attributes.Add("value", cookPass.Value);
                        }
                    }
                }
                else
                {

                }

            }

        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                UserInfo user = null;

                if (!string.IsNullOrWhiteSpace(UserName.Text) && !string.IsNullOrWhiteSpace(Password.Text))
                {
                    DBGateway db = new DBGateway();
                    user = db.GetLoginInfo(UserName.Text);
                    //if (obj != null)
                    //{
                    //   if( obj.Password.CompareTo(Password.Text.Trim())!=0)
                    //   {

                    //   }
                    //   else
                    //   {
                    //       user = new UserInfo();
                    //       user.LoginName = obj.Email;
                    //       user.Password = obj.Password;
                    //       user.UserName = obj.FirstName+" "+obj.LastName;
                    //       user.Email = obj.Email;
                    //       user.RoleId = 0;
                    //   }
                    //}
                }

                if (user != null && user.Password.CompareTo(Password.Text.Trim()) == 0)
                {
                    LoginInfo.SetLoginInfo(user);
                    FormsAuthentication.RedirectFromLoginPage(user.UserName, true);
                   
                    RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);

                    CookieManagement(user);
                }
                else
                {
                    FailureText.Text = "Invalid username or password.";
                    ErrorMessage.Visible = true;
                }


                
            }
        }
        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
        }

        private void RedirectToReturnUrl(string returnUrl, HttpResponse response)
        {
            if (!String.IsNullOrEmpty(returnUrl) )//&& IsLocalUrl(returnUrl))
            {
                response.Redirect(returnUrl);
            }
            else
            {
                response.Redirect("~/");
            }
        }

        private void CookieManagement(UserInfo user)
        {
            if (RememberMe.Checked == true)
            {
                int CookieExpireDay = 1;


                HttpCookie cookUserId = new HttpCookie("userId", user.LoginName);
                cookUserId.Expires = DateTime.Now.AddDays(CookieExpireDay);
                HttpCookie cookPass = new HttpCookie("Pass", user.Password);
                cookPass.Expires = DateTime.Now.AddDays(CookieExpireDay);
                HttpCookie cookRememberMe = new HttpCookie("RememberMe", "true");
                cookRememberMe.Expires = DateTime.Now.AddDays(CookieExpireDay);

                HttpContext context = HttpContext.Current;
                context.Response.Cookies.Add(cookUserId);
                context.Response.Cookies.Add(cookPass);
                context.Response.Cookies.Add(cookRememberMe);
            }
            else
            {
                /* Make the cookies obsolete */
                HttpCookie cookUserId = new HttpCookie("userId");
                cookUserId.Expires = DateTime.Now.AddDays(-1);
                HttpCookie cookPass = new HttpCookie("Pass");
                cookPass.Expires = DateTime.Now.AddDays(-1);
                HttpCookie cookRememberMe = new HttpCookie("RememberMe");
                cookRememberMe.Expires = DateTime.Now.AddDays(-1);

                HttpContext context = HttpContext.Current;
                context.Response.Cookies.Add(cookUserId);
                context.Response.Cookies.Add(cookPass);
                context.Response.Cookies.Add(cookRememberMe);

            }
        }
    }
}