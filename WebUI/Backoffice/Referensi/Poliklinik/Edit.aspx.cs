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

public partial class Backoffice_Referensi_Poliklinik_Edit : System.Web.UI.Page
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
            btnSave.AlternateText = Resources.GetString("","Save");
            btnCancel.ImageUrl = Request.ApplicationPath + "/images/cancel_f2.gif";
            btnCancel.AlternateText = Resources.GetString("", "Cancel");
            
            Draw();
        }

    }

    public void PopolateOrdering(string Ordering)
    {
        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        DataTable dt = myObj.SelectAll();
        cmbOrdering.Items.Clear();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            cmbOrdering.Items.Add("");
            cmbOrdering.Items[i].Text = dr["Ordering"].ToString() + ". " + dr["Nama"].ToString();
            cmbOrdering.Items[i].Value = (i + 1).ToString();
            if (dr["Ordering"].ToString() == Ordering)
            {
                cmbOrdering.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetListKelompokPoliklinik(string KelompokPoliklinikId)
    {
        SIMRS.DataAccess.RS_KelompokPoliklinik myObj = new SIMRS.DataAccess.RS_KelompokPoliklinik();
        DataTable dt = myObj.SelectAll();
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
    public void GetListJenisPoliklinik(string JenisPoliklinikId)
    {
        SIMRS.DataAccess.RS_JenisPoliklinik myObj = new SIMRS.DataAccess.RS_JenisPoliklinik();
        DataTable dt = myObj.SelectAll();
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
    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                txtKode.Text = row["Kode"].ToString();
                txtNama.Text = row["Nama"].ToString();
                GetListKelompokPoliklinik(row["KelompokPoliklinikId"].ToString());
                GetListJenisPoliklinik(row["JenisPoliklinikId"].ToString());
                txtKeterangan.Text = row["Keterangan"].ToString();
                if ((bool)row["Published"])
                    rbtYes.Checked = true;
                else
                    rbtNo.Checked = true;
                PopolateOrdering(row["Ordering"].ToString());
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.Poliklinik::Edit::Draw::Error occured.", ex);
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
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        if (cmbJenisPoliklinik.SelectedIndex > 0)
            myObj.JenisPoliklinikId = int.Parse(cmbJenisPoliklinik.SelectedItem.Value);
        if (cmbKelompokPoliklinik.SelectedIndex > 0)
            myObj.KelompokPoliklinikId = int.Parse(cmbKelompokPoliklinik.SelectedItem.Value);
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        if (cmbOrdering.Items.Count > 0)
            myObj.Ordering = int.Parse(cmbOrdering.SelectedValue);
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistPoliklinik");
            return;
        }
        else
        {
            myObj.Update();
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
