using System;
using System.Reflection;
using System.Web.Security;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace DotNetConcept
{
    public partial class LogIn : System.Web.UI.Page
    {
        Boolean IsAuthenticated = false;
        HttpClient WebAPIServiceClient = null;
        HttpResponseMessage response;
        string jsonString = string.Empty;
        DataTable _dt;
        public string UserId
        {
            get
            {
                return txtUserId.Text;
            }
            set
            {
                txtUserId.Text = value;
            }
        }
        public string Password
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
            }
        }
        public bool RememberMe
        {
            get
            {
                return chkBoxRememberMe.Checked;
            }
            set
            {
                chkBoxRememberMe.Checked = value;
            }
        }
        public string Message
        {
            get
            {
                return lblErrorMessage.Text;
            }
            set
            {
                lblErrorMessage.Text = value;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {            
            lblVersionInfo.Text = "Version :" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (!IsAuthenticated)
            {
                //your own action item
            }
        }      
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            AuthenticateUser();
        }
        public void AuthenticateUser()
        {
            if (!string.IsNullOrEmpty(UserId.Trim()) || !string.IsNullOrEmpty(Password.Trim()))
            {
                if (ValidateId(UserId))
                {
                    Message = "LoggingIn...";
                    FormsAuthentication.RedirectFromLoginPage(UserId, RememberMe);
                }
                else
                {
                    Message = "LogInErrorInvalidCredential";
                }
            }
            else
            {
                Message = "LogInErrorInvalidCredential";
            }
        }        
        public bool ValidateId(string UserId)
        {
            bool IsValid;            
            #region Consume GET method of webAPI
            using (WebAPIServiceClient = new HttpClient())
            {
                WebAPIServiceClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIServiceUrl"].ToString());
                WebAPIServiceClient.DefaultRequestHeaders.Accept.Clear();
                WebAPIServiceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = WebAPIServiceClient.GetAsync("api/values/GetValidateID?id=" + UserId).Result;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = response.Content.ReadAsStringAsync().Result;
                    _dt = GetUserData(UserId);
                }
                else
                {
                    Message = "Internal server Error with API";
                }
            }
            #endregion
            return bool.TryParse(jsonString, out IsValid);
        }        
        public DataTable GetUserData(string id)
        {
            using (WebAPIServiceClient = new HttpClient())
            {
                #region Consume GET method
                WebAPIServiceClient.BaseAddress = new Uri(ConfigurationManager.AppSettings["WebAPIServiceUrl"].ToString());
                WebAPIServiceClient.DefaultRequestHeaders.Accept.Clear();
                WebAPIServiceClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = WebAPIServiceClient.GetAsync("api/values/GetUserData?id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    jsonString = response.Content.ReadAsStringAsync().Result;
                    _dt=(DataTable)JsonConvert.DeserializeObject(jsonString,(typeof(DataTable)));
                }
                else
                {
                    Message = "Internal server Error with API";
                }
            }           
            #endregion
            return _dt;
        }        
    }
}