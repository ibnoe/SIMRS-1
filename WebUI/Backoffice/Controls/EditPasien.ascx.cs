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

public partial class Backoffice_Controls_EditPasien : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void GetListStatus(string StatusId)
    {
        SIMRS.DataAccess.RS_Status myObj = new SIMRS.DataAccess.RS_Status();
        DataTable dt = myObj.GetList();
        cmbStatusPasien.Items.Clear();
        int i = 0;
        cmbStatusPasien.Items.Add("");
        cmbStatusPasien.Items[i].Text = "";
        cmbStatusPasien.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbStatusPasien.Items.Add("");
            cmbStatusPasien.Items[i].Text = dr["Nama"].ToString();
            cmbStatusPasien.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == StatusId)
            {
                cmbStatusPasien.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetListPangkatPasien(string PangkatId)
    {
        SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
        if (cmbStatusPasien.SelectedIndex > 0)
            myObj.StatusId = int.Parse(cmbStatusPasien.SelectedItem.Value);
        DataTable dt = myObj.GetListByStatusId();
        cmbPangkatPasien.Items.Clear();
        int i = 0;
        cmbPangkatPasien.Items.Add("");
        cmbPangkatPasien.Items[i].Text = "";
        cmbPangkatPasien.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPangkatPasien.Items.Add("");
            cmbPangkatPasien.Items[i].Text = dr["Nama"].ToString();
            cmbPangkatPasien.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PangkatId)
            {
                cmbPangkatPasien.SelectedIndex = i;
            }
            i++;
        }
    }
    private void GetListStatusPerkawinan(string StatusPerkawinanId)
    {
        BkNet.DataAccess.StatusPerkawinan myObj = new BkNet.DataAccess.StatusPerkawinan();
        DataTable dt = myObj.GetList();
        cmbStatusPerkawinan.Items.Clear();
        int i = 0;
        cmbStatusPerkawinan.Items.Add("");
        cmbStatusPerkawinan.Items[i].Text = "";
        cmbStatusPerkawinan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbStatusPerkawinan.Items.Add("");
            cmbStatusPerkawinan.Items[i].Text = dr["Nama"].ToString();
            cmbStatusPerkawinan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == StatusPerkawinanId)
                cmbStatusPerkawinan.SelectedIndex = i;
            i++;
        }
    }
    private void GetListAgama(string AgamaId)
    {
        BkNet.DataAccess.Agama myObj = new BkNet.DataAccess.Agama();
        DataTable dt = myObj.GetList();
        cmbAgama.Items.Clear();
        int i = 0;
        cmbAgama.Items.Add("");
        cmbAgama.Items[i].Text = "";
        cmbAgama.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbAgama.Items.Add("");
            cmbAgama.Items[i].Text = dr["Nama"].ToString();
            cmbAgama.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == AgamaId)
                cmbAgama.SelectedIndex = i;
            i++;
        }
    }
    private void GetListPendidikan(string PendidikanId)
    {
        BkNet.DataAccess.Pendidikan myObj = new BkNet.DataAccess.Pendidikan();
        DataTable dt = myObj.GetList();
        cmbPendidikan.Items.Clear();
        int i = 0;
        cmbPendidikan.Items.Add("");
        cmbPendidikan.Items[i].Text = "";
        cmbPendidikan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPendidikan.Items.Add("");
            cmbPendidikan.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbPendidikan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PendidikanId)
                cmbPendidikan.SelectedIndex = i;
            i++;
        }
    }

    public void Draw(string PasienId)
    {
        HFPasienId.Value = PasienId;
        SIMRS.DataAccess.RS_Pasien myObj = new SIMRS.DataAccess.RS_Pasien();
        myObj.PasienId = int.Parse(PasienId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            HFPasienId.Value = dr["PasienId"].ToString();
            txtNoRM.Text = dr["NoRM"].ToString();
            txtNama.Text = dr["Nama"].ToString();
            GetListStatus(dr["StatusId"].ToString());
            GetListPangkatPasien(dr["PangkatId"].ToString());
            txtNoASKES.Text = dr["NoAskes"].ToString();
            txtNoKTP.Text = dr["NoKTP"].ToString();
            txtGolDarah.Text = dr["GolDarah"].ToString();
            txtNrpPasien.Text = dr["NRP"].ToString();
            txtJabatan.Text = dr["Jabatan"].ToString();
            
            //txtKesatuanPasien.Text = dr["Kesatuan"].ToString();
            GetListSatuanKerja(dr["Kesatuan"].ToString());
            
            txtAlamatKesatuan.Text = dr["AlamatKesatuan"].ToString();
            txtTempatLahir.Text = dr["TempatLahir"].ToString() == "" ? "" : dr["TempatLahir"].ToString();
            txtTanggalLahir.Text = dr["TanggalLahir"].ToString() != "" ? ((DateTime)dr["TanggalLahir"]).ToString("dd/MM/yyyy") : "";
            txtAlamatPasien.Text = dr["Alamat"].ToString();
            txtTeleponPasien.Text = dr["Telepon"].ToString();
            cmbJenisKelamin.SelectedIndex = dr["JenisKelamin"].ToString() == "L" ? 1 : 2;
            GetListStatusPerkawinan(dr["StatusPerkawinanId"].ToString());
            GetListAgama(dr["AgamaId"].ToString());
            GetListPendidikan(dr["PendidikanId"].ToString());
            txtPekerjaan.Text = dr["Pekerjaan"].ToString();
            txtAlamatKantorPasien.Text = dr["AlamatKantor"].ToString();
            txtTeleponKantorPasien.Text = dr["TeleponKantor"].ToString();
            txtKeteranganPasien.Text = dr["Keterangan"].ToString();
        }
    }
    
    public bool OnSave()
    {
        bool result = false;
        lblError.Text = "";
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        int UserId = (int)Session["SIMRS.UserId"];
        if (!Page.IsValid)
        {
            return false;
        }
        string noRM1 = txtNoRM.Text.Replace("_", "");
        string noRM2 = noRM1.Replace(".", "");
        if (noRM2 == "")
        {
            lblError.Text = "Nomor Rekam Medis Harus diisi";
            return false;
        }
        else if (noRM2.Length < 5)
        {
            lblError.Text = "Nomor Rekam Medis Harus diisi dengan benar";
            return false;
        }
        
        SIMRS.DataAccess.RS_Pasien myPasien = new SIMRS.DataAccess.RS_Pasien();
        myPasien.PasienId = Int64.Parse(HFPasienId.Value);
        myPasien.SelectOne();
        myPasien.NoRM = txtNoRM.Text.Replace("_", "");
        myPasien.Nama = txtNama.Text;
        if (cmbStatusPasien.SelectedIndex > 0)
            myPasien.StatusId = int.Parse(cmbStatusPasien.SelectedItem.Value);
        if (cmbPangkatPasien.SelectedIndex > 0)
            myPasien.PangkatId = int.Parse(cmbPangkatPasien.SelectedItem.Value);
        myPasien.NoAskes = txtNoASKES.Text;
        myPasien.NoKTP = txtNoKTP.Text;
        myPasien.GolDarah = txtGolDarah.Text;
        myPasien.NRP = txtNrpPasien.Text;
        myPasien.Jabatan = txtJabatan.Text;
        
        //myPasien.Kesatuan = txtKesatuanPasien.Text;
        myPasien.Kesatuan = cmbSatuanKerja.SelectedItem.ToString();
        
        myPasien.AlamatKesatuan = txtAlamatKesatuan.Text;
        myPasien.TempatLahir = txtTempatLahir.Text;
        if (txtTanggalLahir.Text != "")
            myPasien.TanggalLahir = DateTime.Parse(txtTanggalLahir.Text);
        myPasien.Alamat = txtAlamatPasien.Text;
        myPasien.Telepon = txtTeleponPasien.Text;
        if (cmbJenisKelamin.SelectedIndex > 0)
            myPasien.JenisKelamin = cmbJenisKelamin.SelectedItem.Value;
        if (cmbStatusPerkawinan.SelectedIndex > 0)
            myPasien.StatusPerkawinanId = int.Parse(cmbStatusPerkawinan.SelectedItem.Value);
        if (cmbAgama.SelectedIndex > 0)
            myPasien.AgamaId = int.Parse(cmbAgama.SelectedItem.Value);
        if (cmbPendidikan.SelectedIndex > 0)
            myPasien.PendidikanId = int.Parse(cmbPendidikan.SelectedItem.Value);
        myPasien.Pekerjaan = txtPekerjaan.Text;
        myPasien.AlamatKantor = txtAlamatKantorPasien.Text;
        myPasien.TeleponKantor = txtTeleponKantorPasien.Text;
        myPasien.Keterangan = txtKeteranganPasien.Text;
        myPasien.ModifiedBy = UserId;
        myPasien.ModifiedDate = DateTime.Now;

        if (myPasien.IsExist())
        {
            lblError.Text = myPasien.ErrorMessage.ToString();
            return false;
        }
        else
        {
            result = myPasien.Update();
            //string CurrentPage = "";
            //if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            //    CurrentPage = Request.QueryString["CurrentPage"].ToString();
            //string RawatJalanId = "";
            //if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
            //    RawatJalanId = Request.QueryString["RawatJalanId"].ToString();
            //string PasienId = "";
            //if (Request.QueryString["PasienId"] != null && Request.QueryString["PasienId"].ToString() != "")
            //    PasienId = Request.QueryString["PasienId"].ToString();
            //if (RawatJalanId != "")
            //    Response.Redirect("ViewDataRJ.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + RawatJalanId);
            //else
            //    Response.Redirect("ViewPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + PasienId);
        }
        return result;
    }
    public void OnCancel()
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        string RawatJalanId = "";
        if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
            RawatJalanId = Request.QueryString["RawatJalanId"].ToString();
        string PasienId = "";
        if (Request.QueryString["PasienId"] != null && Request.QueryString["PasienId"].ToString() != "")
            PasienId = Request.QueryString["PasienId"].ToString();
        if (RawatJalanId != "")
            Response.Redirect("ViewDataRJ.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + RawatJalanId);
        else
            Response.Redirect("ViewPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + PasienId);
    }

    protected void cmbStatusPasien_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPangkatPasien("");
    }

    private void GetListSatuanKerja(string Kesatuan)
    {
        SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
        DataTable dt = myObj.GetList();
        cmbSatuanKerja.Items.Clear();
        int i = 0;
        cmbSatuanKerja.Items.Add("");
        cmbSatuanKerja.Items[i].Text = "";
        cmbSatuanKerja.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbSatuanKerja.Items.Add("");
            cmbSatuanKerja.Items[i].Text = dr["NamaSatker"].ToString();
            cmbSatuanKerja.Items[i].Value = dr["IdSatuanKerja"].ToString();
            if (dr["NamaSatker"].ToString() == Kesatuan)
            {
                cmbSatuanKerja.SelectedIndex = i;
            }
            i++;
        }
    }
}
