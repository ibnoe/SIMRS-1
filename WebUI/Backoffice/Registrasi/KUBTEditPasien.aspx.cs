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

public partial class Backoffice_Registrasi_KUBTEditPasien : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["PasienId"] != null && Request.QueryString["PasienId"].ToString() != "")
            {
                if (Session["SIMRS.UserId"] == null)
                {
                    Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
                }
                int UserId = (int)Session["SIMRS.UserId"];
                if (Session["RegistrasiKUBT"] == null)
                {
                    Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
                }
                EditPasien1.Draw(Request.QueryString["PasienId"].ToString());
            }
            else
            {
                Response.Redirect(Request.ApplicationPath + "error.aspx");
            }
        }
    }


    protected void btnSave_Click(object sender, ImageClickEventArgs e)
    {
        if (EditPasien1.OnSave())
        {
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            string RawatJalanId = "";
            if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
                RawatJalanId = Request.QueryString["RawatJalanId"].ToString();
            string PasienId = "";
            if (Request.QueryString["PasienId"] != null && Request.QueryString["PasienId"].ToString() != "")
                PasienId = Request.QueryString["PasienId"].ToString();
            if (RawatJalanId != "")
                Response.Redirect("KUBTView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + RawatJalanId);
            else
                Response.Redirect("ViewPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + PasienId);
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
        string PasienId = "";
        if (Request.QueryString["PasienId"] != null && Request.QueryString["PasienId"].ToString() != "")
            PasienId = Request.QueryString["PasienId"].ToString();
        if (RawatJalanId != "")
            Response.Redirect("KUBTView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + RawatJalanId);
        else
            Response.Redirect("ViewPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + PasienId);
    }
}
