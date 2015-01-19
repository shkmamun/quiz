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
    public partial class AddUpdateQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDefault();
                LoadForUpdate();
            }
        }

        public void LoadDefault()
        {
            LoadCategories(); 
        }

        public void LoadForUpdate()
        {
            DBGateway db = new DBGateway();
            try
            {
                if (Request["QuestionId"] != null)
                {
                    Question question = db.GetQuestionByID(Convert.ToInt32(Request["QuestionId"].ToString()));
                    ddlCategories.SelectedValue= question.CategoryId.ToString();
                    ddlDifficulty.SelectedValue = question.DifficultyLevel.ToString();
                    ddlPriority.SelectedValue = question.Priority.ToString();
                    txtQuestion.Text = question.QuestionText;
                    txtOptionA.Text = question.OptionA;
                    txtOptionB.Text = question.OptionB;
                    txtOptionC.Text = question.OptionC;
                    txtOptionD.Text = question.OptionD;
                    txtAnswer.Text = question.AnswerText;
                    txtTimeLimit.Text = question.TimeLimit.ToString();
                    chkActive.Checked = question.IsActive;
                    ltPageTitle.Text = "Upadte Question.";
                    btnSubmit.Text = "Update";
                }
            }
            catch (Exception ex) { }
        }

        public void LoadCategories()
        {
            DBGateway db = new DBGateway();
            ddlCategories.DataSource = db.GetAllCategories();
            ddlCategories.AppendDataBoundItems = true;
            ddlCategories.DataBind();
        }

        
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Question question = new Question
            {
                AnswerText = txtAnswer.Text,
                CategoryId = Convert.ToInt32(ddlCategories.SelectedItem.Value),
                DifficultyLevel = Convert.ToInt32(ddlDifficulty.SelectedItem.Value),
                TimeLimit = Convert.ToInt32(txtTimeLimit.Text),
                QuestionText = txtQuestion.Text,
                Priority = Convert.ToInt32(ddlPriority.SelectedItem.Value),
                IsActive = chkActive.Checked,
                OptionA = txtOptionA.Text,
                OptionB = txtOptionB.Text,
                OptionC = txtOptionC.Text,
                OptionD = txtOptionD.Text
                

            };
            DBGateway db = new DBGateway();
            if (Request["QuestionId"] != null)
            {
                question.QuestionId = Convert.ToInt32(Request["QuestionId"].ToString());
                db.UpdateQuestion(question);
            }
            else
                db.InsertQuestion(question);

            Response.Redirect("~/Questions");
            Clear();
            pnlConfimation.Visible = true;
            if (Request["QuestionId"] != null) 
                lblMessage.Text = "Quesiton has been successfully Updated.";
            else
                lblMessage.Text = "Quesiton has been successfully inserted.";
        }

        private void Clear()
        {
            txtAnswer.Text = string.Empty;
            txtOptionA.Text = string.Empty;
            txtOptionB.Text = string.Empty;
            txtOptionC.Text = string.Empty;
            txtOptionD.Text = string.Empty;
            txtQuestion.Text = string.Empty;
            txtTimeLimit.Text = string.Empty;
            ddlCategories.SelectedValue = "0";
            ddlDifficulty.SelectedValue = "0";
            ddlPriority.SelectedValue = "0";
            chkActive.Checked = false;
        }

    }
}