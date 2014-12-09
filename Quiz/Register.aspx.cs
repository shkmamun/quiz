
using DataAccess;
using Entity;
using Quiz.Utility;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;


namespace Quiz
{
    public partial class Register : Page
    {
        protected void CreateParticipant_Click(object sender, EventArgs e)
        {

            string ranString = UtilityManager.CreateRandomString(16);
            Participant part = new Participant
            {
                
                Address = txtAddress.Text,
                Age = UtilityManager.GetAgeYear(wcDOB.SelectedDate),
                City = txtCity.Text,
                DateOfBirth = wcDOB.SelectedDate,
                Device = BrowserAttributes[1,2],
                Email = txtEmail.Text,
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Gender = ddlGender.SelectedItem.Value,
                IPAddress = UtilityManager.GetIpAddress(),
                Organization = txtOrganization.Text,
                ParticipantId = 0,
                Phone = txtPhone.Text,
                Profession = txtProfession.Text,
                RefCode = ranString
            };

            DBGateway db = new DBGateway();
            db.InsertParticipant(part);
            //ranString = HttpUtility.UrlEncode(UtilityManager.Encrypt(ranString));
            Response.Redirect("~/RegistrationConfirmation.aspx");
            //Clear();
            //pnlConfimation.Visible = true;
            //lblMessage.Text = "Participate has been successfully created.";
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Alert", "Data has been saved", true);

        }

        private void Clear()
        {
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtOrganization.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtProfession.Text = string.Empty;
            ddlGender.SelectedValue = "0";
            txtCity.Text = string.Empty;
            
        }

        #region Get Browser capabilities
        /// <summary>Browser capabilities: 2D array of Name/Values</summary>
        public static string[,] BrowserAttributes
        {
            get
            {
                string _agent = String.Empty;
                if (HttpContext.Current == null) return null;
                try
                {
                    // detailed string describing some of browser capabilities
                    _agent = HttpContext.Current.Request.UserAgent;
                    // browser capabilities object
                    HttpBrowserCapabilities _browser = HttpContext.Current.Request.Browser;
                    // browser capabilities (properties) 2D array of strings, Name/Value
                    string[,] arrFieldValue = 
                {
                    {
                    //"Type",
                    "Name",
                    "Version",
                    //"Major Version",
                    //"Minor Version",
                    "Platform",
                    "ECMA Script Version",
                    "Is Mobile Device",
                    "Is Beta",
                    //"Is Crawler",
                    //"Is AOL",
                    "Is Win16",
                    "Is Win32",
                    "Supports Frames",
                    "Supports Tables",
                    "Supports Cookies",
                    "Supports CSS",
                    "Supports VB Script",
                    "Supports JavaScript",
                    "Supports Java Applets",
                    "Supports ActiveX Controls",
                    "Supports CallBack",
                    "Supports XMLHttp",
                    
                    String.Empty,
                    "User Agent Details"
                    }, 
                    {
                    //_browser.Type,
                    
                    (_agent.ToLower().Contains("chrome"))? "Chrome" :_browser.Browser,
                    (_agent.ToLower().Contains("chrome"))? 
			"See User Agent Details below" :_browser.Version,
                    
                    //_browser.MajorVersion.ToString(),
                    //_browser.MinorVersion.ToString(),
                    
                    _browser.Platform,
                    _browser.EcmaScriptVersion.ToString(),
                    
                    (_browser.IsMobileDevice)? "YES": "NO",
                    (_browser.Beta)? "YES": "NO",
                    
                    //_browser.Crawler.ToString(),
                    //_browser.AOL.ToString(),
                    (_browser.Win16)? "YES": "NO",
                    (_browser.Win32)? "YES": "NO",
                    
                    (_browser.Frames)? "YES": "NO",
                    (_browser.Tables)? "YES": "NO",
                    (_browser.Cookies)? "YES": "NO",
                    (_browser.SupportsCss)? "YES": "NO",
                    (_browser.VBScript)? "YES": "NO",
                    (_browser.JavaScript)? "YES": "NO",
                    (_browser.JavaApplets)? "YES": "NO",
                    (_browser.ActiveXControls)? "YES": "NO",
                    (_browser.SupportsCallback)? "YES": "NO",
                    (_browser.SupportsXmlHttp)? "YES": "NO",
                    String.Empty,
                    _agent
                    }
                };
                    return arrFieldValue;
                }
                catch { return null; }
            }
        }
        /// <summary>JavaScript string to containing Browsers capabilities</summary>
        public static string BrowserJavaScript
        {
            get
            {
                // return string contains JavaScript
                string MsgBrowser = String.Empty;
                string[,] arrBrowser = BrowserAttributes;
                if (arrBrowser == null) return String.Empty;
                try
                {
                    // pop-up message using JavaScript:alert function
                    MsgBrowser = "javascript:alert('Your Browser properties: \\n";
                    for (int i = 0; i < arrBrowser.GetLength(1); i++)
                    { MsgBrowser += "\\n" + arrBrowser[0, i] + " : " + arrBrowser[1, i]; }
                    return MsgBrowser += "')";
                }
                catch { return String.Empty; }
            }
        }
        #endregion

    }
}