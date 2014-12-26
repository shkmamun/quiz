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
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string refCode = Convert.ToString(Request.QueryString["RefCode"]);

                if (!string.IsNullOrWhiteSpace(refCode))
                {
                    DBGateway db = new DBGateway();

                    int result = db.ActivateParticipant(refCode);
                    if (result > 0)
                    {
                        divSucess.Visible = true;
                    }
                    else
                    {
                        divError.Visible = true;
                    }
                }
            }

        }
 
    }
}