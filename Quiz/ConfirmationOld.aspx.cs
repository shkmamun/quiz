using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz
{
    public partial class ConfirmationOld : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string refCode = Convert.ToString(Request.QueryString["RefCode"]);

                if (!string.IsNullOrWhiteSpace(refCode))
                {
                    DBGateway db = new DBGateway();

                    Contest obj = db.GetContestValidation(refCode);

                    if (obj.Status == 0)
                    {
                        divError.Visible = true;
                    }
                    else if (obj.Status == 1)
                    {
                        divNotStarted.Visible = true;
                        lblStartDate.Text = obj.StartDate.ToString("MMM dd, yyyy");
                    }
                    else if (obj.Status == 2)
                    {
                        divEnd.Visible = true;
                        lblEndDate.Text = obj.EndDate.ToString("MMM dd, yyyy");
                    }
                    else if (obj.Status == 3)
                    {
                        divFinish.Visible = true;
                    }
                    else if (obj.Status == 4)
                    {
                        divUnIdentified.Visible = true;
                    }
                    else if (obj.Status == 5)
                    {
                        divQuiz.Visible = true;
                        lblNumOfQuestion.Text = obj.NumOfQuestion.ToString();
                    }
                }
                else
                {
                    divError.Visible = true;
                }
            }

        }
        protected void Start_Click(object sender, EventArgs e)
        {
            string refCode = Convert.ToString(Request.QueryString["RefCode"]);

            if (!string.IsNullOrWhiteSpace(refCode))
            {
                string vertual = string.Empty;
                //if (!string.IsNullOrWhiteSpace(HttpRuntime.AppDomainAppVirtualPath))
                //{
                //    if (HttpRuntime.AppDomainAppVirtualPath.Length > 1)
                //    {
                //        vertual = HttpRuntime.AppDomainAppVirtualPath;
                //    }
                //}
                string url = "/QuizRun?RefCode=" + refCode;
                Response.Redirect(url);
            }
            else
            {
                divError.Visible = true;
            }
        }
        protected void Cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/About");
        }
    }
}