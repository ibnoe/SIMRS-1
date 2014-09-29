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

public partial class Backoffice_Registrasi_RIEditRegistrasi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["RawatInapId"] != null && Request.QueryString["RawatInapId"].ToString() != "")
            {
                if (Session["SIMRS.UserId"] == null)
                {
                    Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
                }
                int UserId = (int)Session["SIMRS.UserId"];
                if (Session["RegistrasiRI"] == null)
                {
                    Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
                }
                EditRegistrasiRI1.Draw(Request.QueryString["RawatInapId"].ToString());
            }
            else
            {
                Response.Redirect(Request.ApplicationPath + "error.aspx");
            }
        }
    }
    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (EditRegistrasiRI1.OnSave())
        {
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            string RawatInapId = "";
            if (Request.QueryString["RawatInapId"] != null && Request.QueryString["RawatInapId"].ToString() != "")
                RawatInapId = Request.QueryString["RawatInapId"].ToString();
            Response.Redirect("RIView.aspx?CurrentPage=" + CurrentPage + "&RawatInapId=" + RawatInapId);
        }
    }
    protected void btnCancel_Click(object sender, ImageClickEventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        string RawatInapId = "";
        if (Request.QueryString["RawatInapId"] != null && Request.QueryString["RawatInapId"].ToString() != "")
            RawatInapId = Request.QueryString["RawatInapId"].ToString();
        Response.Redirect("RIView.aspx?CurrentPage=" + CurrentPage + "&RawatInapId=" + RawatInapId);
    }
}
