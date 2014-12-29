using DataAccess;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Quiz.Admin
{
    public partial class Questions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
                LoadQuestions();
            }
        }

        public void LoadCategories()
        {
            DBGateway db = new DBGateway();
            ddlCategories.DataSource = db.GetAllCategories();
            ddlCategories.AppendDataBoundItems = true;
            ddlCategories.DataBind();
        }

        protected void LoadQuestions()
        {
            DBGateway db = new DBGateway();
            gvwQuestions.DataSource = db.GetAllQuestions();
            gvwQuestions.DataBind();
        }
        protected void gvwQuestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvwQuestions.PageIndex = e.NewPageIndex;
            LoadQuestions();
        }

        protected void imgUpdate_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgUpdate = (ImageButton)(sender);
            int questionID = Convert.ToInt32(imgUpdate.CommandArgument.ToString());
            Response.Redirect("~/AddUpdateQuestion.aspx?QuestionId="+ questionID);
        }

        protected void imgDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgDelete = (ImageButton)(sender);
            int questionID = Convert.ToInt32(imgDelete.CommandArgument.ToString());
            DBGateway db = new DBGateway();
            db.DeleteQuestion(questionID);
            LoadQuestions();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DBGateway db = new DBGateway();
            string active = ddlActive.SelectedItem.Value == "0" ? string.Empty : ddlActive.SelectedItem.Value;
            List<Question> questions = db.GetQuestionsBySearch(Convert.ToInt32(ddlCategories.SelectedItem.Value), Convert.ToInt32(ddlPriority.SelectedItem.Value), Convert.ToInt32(ddlDifficulty.SelectedItem.Value), txtQuestion.Text, active);

            gvwQuestions.DataSource = questions;
            gvwQuestions.DataBind();
        }
    }

}