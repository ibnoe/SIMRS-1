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

public partial class Backoffice_Referensi_Dokter_Add : System.Web.UI.Page
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
            if (Session["DokterManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListSpesialis();
        }
    }
    public void GetListSpesialis()
    {
        string SpesialisId = "";
        if (Request.QueryString["SpesialisId"] != null)
            SpesialisId = Request.QueryString["SpesialisId"].ToString();

        SIMRS.DataAccess.RS_Spesialis myObj = new SIMRS.DataAccess.RS_Spesialis();
        DataTable dt = myObj.GetList();
        cmbSpesialis.Items.Clear();
        int i = 0;
        cmbSpesialis.Items.Add("");
        cmbSpesialis.Items[i].Text = "";
        cmbSpesialis.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbSpesialis.Items.Add("");
            cmbSpesialis.Items[i].Text = dr["Nama"].ToString();
            cmbSpesialis.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == SpesialisId)
            {
                cmbSpesialis.SelectedIndex = i;
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

        SIMRS.DataAccess.RS_Dokter myObj = new SIMRS.DataAccess.RS_Dokter();
        myObj.DokterId = 0;
        if (cmbSpesialis.SelectedIndex > 0)
            myObj.SpesialisId = int.Parse(cmbSpesialis.SelectedItem.Value);
        myObj.NRP = txtNRP.Text;
        myObj.Nama = txtNama.Text;
        myObj.TempatLahir = txtTempatLahir.Text;
        if (txtTanggalLahir.Text != "")
            myObj.TanggalLahir = DateTime.Parse(txtTanggalLahir.Text);
        myObj.JenisKelamin = cmbJenisKelamin.SelectedItem.Value;
        myObj.Alamat = txtAlamat.Text;
        myObj.Telepon = txtTelepon.Text;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistDokter");
            return;
        }
        else
        {
            myObj.Insert();
            HttpRuntime.Cache.Remove("SIMRS_Dokter");
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
