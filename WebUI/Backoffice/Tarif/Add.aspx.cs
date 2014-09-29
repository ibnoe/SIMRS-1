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

public partial class Backoffice_Tarif_Add : System.Web.UI.Page
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
            if (Session["AddTarif"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListKelompokLayanan();
            GetListJenisLayanan();
            GetListPoliklinik();
        }

    }

    public void GetListKelompokLayanan()
    {
        string KelompokLayananId = "";
        SIMRS.DataAccess.RS_KelompokLayanan myObj = new SIMRS.DataAccess.RS_KelompokLayanan();
        DataTable dt = myObj.GetList();
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
    public void GetListJenisLayanan()
    {
        string JenisLayananId = "";
        SIMRS.DataAccess.RS_JenisLayanan myObj = new SIMRS.DataAccess.RS_JenisLayanan();
        DataTable dt = myObj.GetList();
        cmbJenisLayanan.Items.Clear();
        int i = 0;
        cmbJenisLayanan.Items.Add("");
        cmbJenisLayanan.Items[i].Text = "";
        cmbJenisLayanan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbJenisLayanan.Items.Add("");
            cmbJenisLayanan.Items[i].Text = dr["Kode"].ToString() + ". " + dr["Nama"].ToString();
            cmbJenisLayanan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisLayananId)
                cmbJenisLayanan.SelectedIndex = i;
            i++;
        }
    }
    public void GetListPoliklinik()
    {
        string PoliklinikId = "";
        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        DataTable dt = myObj.GetList();
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
        if (cmbJenisLayanan.SelectedIndex > 0)
            myObj.JenisLayananId = int.Parse(cmbJenisLayanan.SelectedItem.Value);
        if (cmbPoliklinik.SelectedIndex > 0)
            myObj.PoliklinikId = int.Parse(cmbPoliklinik.SelectedItem.Value);
        if (cmbKelompokLayanan.SelectedIndex > 0)
            myObj.KelompokLayananId = int.Parse(cmbKelompokLayanan.SelectedItem.Value);
        myObj.Keterangan = txtKeterangan.Text;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistLayanan");
            return;
        }
        else
        {
            myObj.Insert();
            HttpRuntime.Cache.Remove("SIMRS_Layanan");
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
