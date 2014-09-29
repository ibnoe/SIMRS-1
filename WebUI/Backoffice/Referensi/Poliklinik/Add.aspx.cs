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

public partial class Backoffice_Referensi_Poliklinik_Add : System.Web.UI.Page
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
            if (Session["PoliklinikManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.ImageUrl = Request.ApplicationPath + "/images/save_f2.gif";
            btnSave.AlternateText = Resources.GetString("", "Save");
            btnCancel.ImageUrl = Request.ApplicationPath + "/images/cancel_f2.gif";
            btnCancel.AlternateText = Resources.GetString("", "Cancel");
            
            GetListKelompokPoliklinik();
            GetListJenisPoliklinik();

        }

    }

    public void GetListKelompokPoliklinik()
    {
        string KelompokPoliklinikId = "";
        SIMRS.DataAccess.RS_KelompokPoliklinik myObj = new SIMRS.DataAccess.RS_KelompokPoliklinik();
        DataTable dt = myObj.GetList();
        cmbKelompokPoliklinik.Items.Clear();
        int i = 0;
        cmbKelompokPoliklinik.Items.Add("");
        cmbKelompokPoliklinik.Items[i].Text = "";
        cmbKelompokPoliklinik.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelompokPoliklinik.Items.Add("");
            cmbKelompokPoliklinik.Items[i].Text = dr["Nama"].ToString();
            cmbKelompokPoliklinik.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelompokPoliklinikId)
                cmbKelompokPoliklinik.SelectedIndex = i;
            i++;
        }
    }
    public void GetListJenisPoliklinik()
    {
        string JenisPoliklinikId = "";
        SIMRS.DataAccess.RS_JenisPoliklinik myObj = new SIMRS.DataAccess.RS_JenisPoliklinik();
        DataTable dt = myObj.GetList();
        cmbJenisPoliklinik.Items.Clear();
        int i = 0;
        cmbJenisPoliklinik.Items.Add("");
        cmbJenisPoliklinik.Items[i].Text = "";
        cmbJenisPoliklinik.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbJenisPoliklinik.Items.Add("");
            cmbJenisPoliklinik.Items[i].Text = dr["Nama"].ToString();
            cmbJenisPoliklinik.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisPoliklinikId)
                cmbJenisPoliklinik.SelectedIndex = i;
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

        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        myObj.Id = 0;
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        if (cmbJenisPoliklinik.SelectedIndex > 0)
            myObj.JenisPoliklinikId = int.Parse(cmbJenisPoliklinik.SelectedItem.Value);
        if (cmbKelompokPoliklinik.SelectedIndex > 0)
            myObj.KelompokPoliklinikId = int.Parse(cmbKelompokPoliklinik.SelectedItem.Value);
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistPoliklinik");
            return;
        }
        else
        {
            myObj.Insert();
            HttpRuntime.Cache.Remove("SIMRS_Poliklinik");
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
