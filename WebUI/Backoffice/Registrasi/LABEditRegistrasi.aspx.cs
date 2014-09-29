using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Backoffice_Registrasi_LABEditRegistrasi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
            {
                if (Session["SIMRS.UserId"] == null)
                {
                    Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
                }
                int UserId = (int)Session["SIMRS.UserId"];
                if (Session["RegistrasiLAB"] == null)
                {
                    Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
                }
                EditRegistrasiLAB1.Draw(Request.QueryString["RawatJalanId"].ToString());
            }
            else
            {
                Response.Redirect(Request.ApplicationPath + "error.aspx");
            }
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (EditRegistrasiLAB1.OnSave())
        {
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            string RawatJalanId = "";
            if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
                RawatJalanId = Request.QueryString["RawatJalanId"].ToString();
            Response.Redirect("LABView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + RawatJalanId);
        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        string RawatJalanId = "";
        if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
            RawatJalanId = Request.QueryString["RawatJalanId"].ToString();
        Response.Redirect("LABView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + RawatJalanId);
    }
}
