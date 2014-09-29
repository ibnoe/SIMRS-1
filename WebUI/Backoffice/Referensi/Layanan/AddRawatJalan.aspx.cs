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

public partial class Backoffice_Referensi_Layanan_AddRawatJalan : System.Web.UI.Page
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
            if (Session["LayananManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.ImageUrl = Request.ApplicationPath + "/images/save_f2.gif";
            btnSave.AlternateText = Resources.GetString("", "Save");
            btnCancel.ImageUrl = Request.ApplicationPath + "/images/cancel_f2.gif";
            btnCancel.AlternateText = Resources.GetString("", "Cancel");
            
            GetListKelompokLayanan();
            //GetListJenisLayanan();
            GetListPoliklinik();
        }

    }

    public void GetListKelompokLayanan()
    {
        string KelompokLayananId = "";
        if (Request.QueryString["KelompokLayananId"] != null && Request.QueryString["KelompokLayananId"].ToString()!= "")
            KelompokLayananId = Request.QueryString["KelompokLayananId"].ToString();
        SIMRS.DataAccess.RS_KelompokLayanan myObj = new SIMRS.DataAccess.RS_KelompokLayanan();
        DataTable dt = myObj.SelectAll();
        cmbKelompokLayanan.Items.Clear();
        int i = 0;
        cmbKelompokLayanan.Items.Add("");
        cmbKelompokLayanan.Items[i].Text = "";
        cmbKelompokLayanan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelompokLayanan.Items.Add("");
            cmbKelompokLayanan.Items[i].Text = dr["Kode"].ToString()+". "+dr["Nama"].ToString();
            cmbKelompokLayanan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelompokLayananId)
                cmbKelompokLayanan.SelectedIndex = i;
            i++;
        }
    }

    public void GetListPoliklinik()
    {
        string PoliklinikId = "";
        if (Request.QueryString["PoliklinikId"] != null && Request.QueryString["PoliklinikId"].ToString() != "")
            PoliklinikId = Request.QueryString["PoliklinikId"].ToString();
        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        DataTable dt = myObj.SelectAll();
        cmbPoliklinik.Items.Clear();
        int i = 0;
        cmbPoliklinik.Items.Add("");
        cmbPoliklinik.Items[i].Text = "";
        cmbPoliklinik.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPoliklinik.Items.Add("");
            cmbPoliklinik.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString() + " (" + dr["KelompokPoliklinikNama"].ToString()+ ")";
            cmbPoliklinik.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PoliklinikId)
                cmbPoliklinik.SelectedIndex = i;
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

        SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
        myObj.Id = 0;
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        //if (cmbJenisLayanan.SelectedIndex > 0)
        //    myObj.JenisLayananId = int.Parse(cmbJenisLayanan.SelectedItem.Value);
        myObj.JenisLayananId = 1;//RawatJalan
        if (cmbPoliklinik.SelectedIndex > 0)
            myObj.PoliklinikId = int.Parse(cmbPoliklinik.SelectedItem.Value);
        if (cmbKelompokLayanan.SelectedIndex > 0)
            myObj.KelompokLayananId = int.Parse(cmbKelompokLayanan.SelectedItem.Value);
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistLayanan");
            return;
        }
        else
        {
            if (myObj.Insert())
            {
                SIMRS.DataAccess.RS_Tarif myTarif = new SIMRS.DataAccess.RS_Tarif();
                myTarif.Id = 0;
                myTarif.LayananId = myObj.Id;
                myTarif.Satuan = txtSatuan.Text;
                if (txtTarif.Value != "")
                    myTarif.Tarif = decimal.Parse(txtTarif.Value);
                myTarif.Keterangan = txtKeterangan.Text;
                myTarif.Published = true;
                myTarif.CreatedBy = UserId;
                myTarif.CreatedDate = DateTime.Now;
                myTarif.Insert();
                string PoliklinikId = "";
                if (cmbPoliklinik.SelectedIndex > 0)
                    PoliklinikId = cmbPoliklinik.SelectedItem.Value;
                string KelompokLayananId = "";
                if (cmbKelompokLayanan.SelectedIndex > 0)
                    KelompokLayananId = cmbKelompokLayanan.SelectedItem.Value;
                string CurrentPage = "";
                if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                    CurrentPage = Request.QueryString["CurrentPage"].ToString();
                Response.Redirect("ListRawatJalan.aspx?CurrentPage=" + CurrentPage + "&PoliklinikId=" + PoliklinikId + "&KelompokLayananId=" + KelompokLayananId);
            }
        }
    }
    /// <summary>
    /// This function is responsible for cancel save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnCancel(Object sender, EventArgs e)
    {
        string PoliklinikId = "";
        if (Request.QueryString["PoliklinikId"] != null && Request.QueryString["PoliklinikId"].ToString() != "")
            PoliklinikId = Request.QueryString["PoliklinikId"].ToString();
        string KelompokLayananId = "";
        if (Request.QueryString["KelompokLayananId"] != null && Request.QueryString["KelompokLayananId"].ToString() != "")
            KelompokLayananId = Request.QueryString["KelompokLayananId"].ToString();
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("ListRawatJalan.aspx?CurrentPage=" + CurrentPage + "&PoliklinikId=" + PoliklinikId + "&KelompokLayananId=" + KelompokLayananId);
    }
}
