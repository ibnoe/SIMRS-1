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

public partial class Backoffice_Referensi_SatuanKerja_Delete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["SIMRS.UserId"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
            }
            int UserId = (int)Session["SIMRS.UserId"];
            if (Session["SatuanKerjaManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnDelete.AlternateText = Resources.GetString("", "Delete");
            btnDelete.ImageUrl = Request.ApplicationPath + "/images/delete_f2.gif";
            btnCancel.AlternateText = Resources.GetString("", "Cancel");
            btnCancel.ImageUrl = Request.ApplicationPath + "/images/cancel_f2.gif";
            
            Draw();
        }

    }
    
    public void Draw()
    {
        try
        {
            string IdSatuanKerja = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
            myObj.IdSatuanKerja = Convert.ToInt32(IdSatuanKerja);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtIdSatuanKerja.Text = row["IdSatuanKerja"].ToString();
                lblKode.Text = row["Kode"].ToString();
                lblNamaSatker.Text = row["NamaSatker"].ToString();
                lblKeterangan.Text = row["Keterangan"].ToString();
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.SatuanKerja::Delete::Draw::Error occured.", ex);
        }

    }

    public void OnDelete(Object sender, EventArgs e)
    {
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        int UserId = (int)Session["SIMRS.UserId"];
        if (!Page.IsValid)
        {
            return;
        }

        SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
        myObj.IdSatuanKerja = int.Parse(txtIdSatuanKerja.Text);
        try
        {
            myObj.Delete();
            HttpRuntime.Cache.Remove("SIMRS_SatuanKerja");
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
        }
        catch
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            Response.Write("<script>alert(\"" + Resources.GetString("", "WarAlreadyUsed") + "\"); window.history.go(-1)</script>");
        }


    }
    /// <summary>
    /// This function is responsible for cancel save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
    }
}
