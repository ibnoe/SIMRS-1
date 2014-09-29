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

public partial class Backoffice_Tarif_EditRawatJalan : System.Web.UI.Page
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
            if (Session["EditTarif"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.ImageUrl = Request.ApplicationPath + "/images/save_f2.gif" ;
            btnCancel.ImageUrl = Request.ApplicationPath + "/images/cancel_f2.gif";

            Draw();
        }

    }

    public void GetListKelompokLayanan(string KelompokLayananId)
    {
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
            cmbKelompokLayanan.Items[i].Text = dr["Nama"].ToString();
            cmbKelompokLayanan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelompokLayananId)
                cmbKelompokLayanan.SelectedIndex = i;
            i++;
        }
    }
    public void GetListPoliklinik(string PoliklinikId)
    {
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
            if (dr["JenisPoliklinikId"].ToString() == "1")
            {
                cmbPoliklinik.Items.Add("");
                cmbPoliklinik.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString() + " (" + dr["KelompokPoliklinikNama"].ToString() + ")";
                cmbPoliklinik.Items[i].Value = dr["Id"].ToString();
                if (dr["Id"].ToString() == PoliklinikId)
                    cmbPoliklinik.SelectedIndex = i;
                i++;
            }
        }
    }
    public void GetListJenisLayanan(string JenisLayananId)
    {
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
            cmbJenisLayanan.Items[i].Text = dr["Nama"].ToString();
            cmbJenisLayanan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisLayananId)
                cmbJenisLayanan.SelectedIndex = i;
            i++;
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
                GetListJenisLayanan(row["JenisLayananId"].ToString());
                GetListPoliklinik(row["PoliklinikId"].ToString());
                GetListKelompokLayanan(row["KelompokLayananId"].ToString());
                txtKode.Text = row["Kode"].ToString();
                txtNama.Text = row["Nama"].ToString();
                txtKeterangan.Text = row["Keterangan"].ToString();
                if ((bool)row["Published"])
                    rbtYes.Checked = true;
                else
                    rbtNo.Checked = true;
                txtTarifId.Text = row["TarifId"].ToString();
                txtSatuan.Text = row["Satuan"].ToString();
                txtTarif.Value = row["Tarif"].ToString() != "" ? ((decimal)row["Tarif"]).ToString("N"):"";
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
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        if (cmbJenisLayanan.SelectedIndex > 0)
            myObj.JenisLayananId = int.Parse(cmbJenisLayanan.SelectedItem.Value);
        if (cmbPoliklinik.SelectedIndex > 0)
            myObj.PoliklinikId = int.Parse(cmbPoliklinik.SelectedItem.Value);
        else
            myObj.PoliklinikId = SqlInt32.Null;
        if (cmbKelompokLayanan.SelectedIndex > 0)
            myObj.KelompokLayananId = int.Parse(cmbKelompokLayanan.SelectedItem.Value);
        else
            myObj.KelompokLayananId = SqlInt32.Null;
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistLayanan");
            return;
        }
        else
        {
            if (myObj.Update())
            {
                SIMRS.DataAccess.RS_Tarif myTarif = new SIMRS.DataAccess.RS_Tarif();
                myTarif.Id = int.Parse(txtTarifId.Text);
                myTarif.SelectOne();
                myTarif.LayananId = myObj.Id;
                myTarif.Satuan = txtSatuan.Text;
                if(txtTarif.Value != "")
                    myTarif.Tarif = decimal.Parse(txtTarif.Value);
                myTarif.ModifiedBy = UserId;
                myTarif.ModifiedDate = DateTime.Now;
                myTarif.Update();
                string CurrentPage = "";
                if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                    CurrentPage = Request.QueryString["CurrentPage"].ToString();
                Response.Redirect("ListRawatJalan.aspx?CurrentPage=" + CurrentPage);
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
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("ListRawatJalan.aspx?CurrentPage=" + CurrentPage);
    }
}
