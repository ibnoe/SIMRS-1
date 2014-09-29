using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Reflection;
using System.ComponentModel;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Backoffice_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_ServerClick(object sender, System.EventArgs e)
    {
        if (txtUserName.Value == "")
        {
            txtHeader.Text = "Masukan Username!";
            return;
        }
        if (txtPassword.Value == "")
        {
            txtHeader.Text = "Masukan Password!";
            return;
        }
        BkNet.Common.Crypto myCripto = new BkNet.Common.Crypto();
        BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
        myUser.UserName = txtUserName.Value;
        myUser.Password = myCripto.Encrypt(txtPassword.Value);
        string errorMessage = myUser.Login();

        if (errorMessage != "")
            txtHeader.Text = errorMessage;
        else
        {
            int UserId = (int)myUser.UserId;
            int GroupId = (int)myUser.GroupId;

            Session.Add("SIMRS.UserId", UserId);
            Session.Add("SIMRS.UserName", txtUserName.Value.ToString());
            Session.Add("SIMRS.GroupId", GroupId);
            BkNet.DataAccess.Groups myGroup = new BkNet.DataAccess.Groups();
            myGroup.GroupId = GroupId;
            myGroup.SelectOne();
            Session.Add("SIMRS.GroupName", myGroup.GroupName);

            DataTable myPolicy = myUser.GetAllPolicy();
            if (myPolicy.Rows.Count > 0)
            {
                foreach (DataRow dr in myPolicy.Rows)
                {
                    Session.Add(dr["PolicyName"].ToString(), dr["PolicyName"].ToString());
                }
            }


            FormsAuthentication.RedirectFromLoginPage("*", false);
            if (Request.QueryString["ReturnUrl"] != null && Request.QueryString["ReturnUrl"].ToString() != "")
                Response.Redirect(Request.QueryString["ReturnUrl"].ToString());
            else
                Response.Redirect("Default.aspx");
        }
    }

    #region Assembly Attribute Accessors

    public string AssemblyTitle
    {
        get
        {
            // Get all Title attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            // If there is at least one Title attribute
            if (attributes.Length > 0)
            {
                // Select the first one
                AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                // If it is not an empty string, return it
                if (titleAttribute.Title != "")
                    return titleAttribute.Title;
            }
            // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
            return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        }
    }

    public string AssemblyVersion
    {
        get
        {
            return Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }

    public string AssemblyDescription
    {
        get
        {
            // Get all Description attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
            // If there aren't any Description attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Description attribute, return its value
            return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        }
    }

    public string AssemblyProduct
    {
        get
        {
            // Get all Product attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
            // If there aren't any Product attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Product attribute, return its value
            return ((AssemblyProductAttribute)attributes[0]).Product;
        }
    }

    public string AssemblyCopyright
    {
        get
        {
            // Get all Copyright attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
            // If there aren't any Copyright attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Copyright attribute, return its value
            return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
        }
    }

    public string AssemblyCompany
    {
        get
        {
            // Get all Company attributes on this assembly
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            // If there aren't any Company attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Company attribute, return its value
            return ((AssemblyCompanyAttribute)attributes[0]).Company;
        }
    }
    #endregion
}
