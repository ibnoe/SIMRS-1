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

public partial class Backoffice_Referensi_Pangkat_Delete : System.Web.UI.Page
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
            if (Session["PangkatManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnDelete.Text = "<center><img onclick=\"if(confirm('Apakah Anda yakin akan menghapus data ini !')) {return true}else{return false}\"  alt=\"" + Resources.GetString("", "Delete") + "\" src=\"" + Request.ApplicationPath + "/images/delete_f2.gif\" align=\"middle\" border=\"0\" name=\"delete\" value=\"delete\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }

    }

    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                lblStatusNama.Text = row["StatusNama"].ToString();
                lblKode.Text = row["Kode"].ToString();
                lblNama.Text = row["Nama"].ToString();
                lblKelompokPangkat.Text = row["KelompokPangkatNama"].ToString();
                lblKeterangan.Text = row["Keterangan"].ToString();
                lblPublished.Text = row["Published"].ToString() == "True" ? "Aktif":"Tidak";
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.Pangkat::Delete::Draw::Error occured.", ex);
        }

    }


    /// <summary>
    /// This function is responsible for save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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

        SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
        myObj.Id = int.Parse(txtId.Text);
        try
        {
            myObj.Delete();
            HttpRuntime.Cache.Remove("SIMRS_Pangkat");
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
