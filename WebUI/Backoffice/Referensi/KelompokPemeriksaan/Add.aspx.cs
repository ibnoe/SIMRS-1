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

public partial class Backoffice_Referensi_KelompokPemeriksaan_Add : System.Web.UI.Page
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
            if (Session["KelompokPemeriksaanManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListJenisPemeriksaan();
        }
    }
    public void GetListJenisPemeriksaan()
    {
        string Id = "";
        if (Request.QueryString["Id"] != null)
            Id = Request.QueryString["Id"].ToString();

        SIMRS.DataAccess.RS_JenisPemeriksaan myObj = new SIMRS.DataAccess.RS_JenisPemeriksaan();
        DataTable dt = myObj.GetList();
        cmbJenisPemeriksaan.Items.Clear();
        int i = 0;
        cmbJenisPemeriksaan.Items.Add("");
        cmbJenisPemeriksaan.Items[i].Text = "";
        cmbJenisPemeriksaan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbJenisPemeriksaan.Items.Add("");
            cmbJenisPemeriksaan.Items[i].Text = dr["Nama"].ToString();
            cmbJenisPemeriksaan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == Id)
            {
                cmbJenisPemeriksaan.SelectedIndex = i;
            }
            i++;
        }
    }

    /// <summary>
    /// This function is responsible for save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnSave(Object sender, EventArgs e)
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
        /*
        if (txtTanggalLahir.Text != "")
        {
            try
            {
                DateTime.Parse(txtTanggalLahir.Text);
            }
            catch
            {
                return; 
            }            
        }
        */

        SIMRS.DataAccess.RS_KelompokPemeriksaan myObj = new SIMRS.DataAccess.RS_KelompokPemeriksaan();
        myObj.Id = 0;
        if (cmbJenisPemeriksaan.SelectedIndex > 0)
            myObj.JenisPemeriksaanId = int.Parse(cmbJenisPemeriksaan.SelectedItem.Value);
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        myObj.Keterangan = txtKeterangan.Text;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistKelompokPemeriksaan");
            return;
        }
        else
        {
            myObj.Insert();
            HttpRuntime.Cache.Remove("SIMRS_KelompokPemeriksaan");
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
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
