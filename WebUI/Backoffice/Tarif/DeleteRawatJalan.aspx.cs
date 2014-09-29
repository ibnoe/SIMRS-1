using System;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Backoffice_Tarif_DeleteRawatJalan : System.Web.UI.Page
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
            if (Session["DeleteTarif"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnDelete.ImageUrl = Request.ApplicationPath + "/images/delete_f2.gif" ;
            btnCancel.ImageUrl = Request.ApplicationPath + "/images/cancel_f2.gif";

            Draw();
        }

    }
    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOneRawatJalan();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                lblJenisLayanan.Text= row["JenisLayananNama"].ToString();
                lblPolikinik.Text = row["PoliklinikNama"].ToString();
                lblKelompok.Text = row["KelompokLayananNama"].ToString();
                lblKode.Text = row["Kode"].ToString();
                lblNama.Text = row["Nama"].ToString();
                lblKeterangan.Text = row["Keterangan"].ToString();
                lblPublished.Text =  row["Published"].ToString() == "True"? "Ya": "Tidak";
                lblSatuan.Text = row["Satuan"].ToString();
                lblTarif.Text = row["Tarif"].ToString() != "" ? ((decimal)row["Tarif"]).ToString("N"):"";
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.Layanan::Edit::Draw::Error occured.", ex);
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

        SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
        myObj.Id = int.Parse(txtId.Text);
        try
        {
            myObj.Delete();
            SIMRS.DataAccess.RS_Tarif myTarif = new SIMRS.DataAccess.RS_Tarif();
            myTarif.LayananId = int.Parse(txtId.Text);
            myTarif.DeleteAllWLayananIdLogic();
        
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("ListRawatJalan.aspx?CurrentPage=" + CurrentPage);
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
        Response.Redirect("ListRawatJalan.aspx?CurrentPage=" + CurrentPage);
    }
}
