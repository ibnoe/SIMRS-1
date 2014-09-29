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
using System.Data.SqlTypes;

public partial class Backoffice_Controls_EditRegistrasiRJ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void Draw(string RawatJalanId)
    {
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.RawatJalanId = Int64.Parse(RawatJalanId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            HFRegistrasiId.Value = row["RegistrasiId"].ToString();
            HFRawatJalanId.Value = row["RawatJalanId"].ToString();
            HFPasienId.Value = row["PasienId"].ToString();
            HFStatusRawatJalan.Value = row["StatusRawatJalan"].ToString();
            HFPenjaminId.Value = row["PenjaminId"].ToString() == "" ? "0" : row["PenjaminId"].ToString();

            lblNoRM.Text = row["NoRM"].ToString();
            lblNamaPasien.Text = row["Nama"].ToString();
            //Data Registrasi
            lblNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            txtNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            txtTanggalRegistrasi.Text = row["TanggalBerobat"].ToString() != "" ? ((DateTime)row["TanggalBerobat"]).ToString("dd/MM/yyyy") : "";
            UpdateHari();
            GetListPoliklinik(row["PoliklinikId"].ToString());
            if (cmbPoliklinik.SelectedIndex > 0)
            {
                string[] poli = cmbPoliklinik.SelectedItem.Value.Split('|');
                if (poli[1] == "2")
                {
                    RVDokter.Visible = false;
                }
                else
                {
                    RVDokter.Visible = true;
                }
            }
            GetListDokter(row["DokterId"].ToString());
            UpdateJamPraktek();
            txtNomorTunggu.Text = row["NomorTunggu"].ToString();
            GetListJenisPenjamin(row["JenisPenjaminId"].ToString());
            string JenisPenjaminId = row["JenisPenjaminId"].ToString();

            GetListHubungan(row["HubunganId"].ToString());
            GetListAgama(row["AgamaIdPenjamin"].ToString());
            GetListPendidikan(row["PendidikanIdPenjamin"].ToString());
            GetListStatus(row["StatusIdPenjamin"].ToString());
            GetListPangkatPenjamin(row["PangkatIdPenjamin"].ToString());
            if (JenisPenjaminId == "2")
            {
                tblPenjaminKeluarga.Visible = true;
                tblPenjaminPerusahaan.Visible = false;

                //Data Keluarga Penjamin
                txtNamaPenjamin.Text = row["NamaPenjamin"].ToString();
                txtUmurPenjamin.Text = row["UmurPenjamin"].ToString();
                txtAlamatPenjamin.Text = row["AlamatPenjamin"].ToString();
                txtTeleponPenjamin.Text = row["TeleponPenjamin"].ToString();
                txtNRPPenjamin.Text = row["NRPPenjamin"].ToString();
                txtJabatanPenjamin.Text = row["JabatanPenjamin"].ToString();
                
                //txtKesatuanPenjamin.Text = row["KesatuanPenjamin"].ToString();
                GetListSatuanKerjaPenjamin(row["KesatuanPenjamin"].ToString());
                
                txtAlamatKesatuanPenjamin.Text = row["AlamatKesatuan"].ToString();
                txtNoKTPPenjamin.Text = row["NoKTPPenjamin"].ToString();
                txtGolDarahPenjamin.Text = row["GolDarahPenjamin"].ToString();
                txtKeteranganPenjamin.Text = row["KeteranganPenjamin"].ToString();
            }
            else if (JenisPenjaminId == "3" || JenisPenjaminId == "4")
            {
                tblPenjaminKeluarga.Visible = false;
                tblPenjaminPerusahaan.Visible = true;
                txtNamaPerusahaan.Text = row["NamaPenjamin"].ToString();
                txtNamaKontak.Text = row["NamaKontakPenjamin"].ToString();
                txtAlamatPerusahaan.Text = row["AlamatPenjamin"].ToString();
                txtTeleponPerusahaan.Text = row["TeleponPenjamin"].ToString();
                txtFAXPerusahaan.Text = row["FaxPenjamin"].ToString();
                txtKeteranganPerusahaan.Text = row["KeteranganPenjamin"].ToString();
            }
            else
            {
                tblPenjaminKeluarga.Visible = false;
                tblPenjaminPerusahaan.Visible = false;
            }
        }
    }
    private void UpdateHari()
    {
        string hari = DateTime.Parse(txtTanggalRegistrasi.Text).DayOfWeek.ToString();
        switch (hari)
        {
            case "Monday":
                txtHari.Text = "1";
                break;
            case "Tuesday":
                txtHari.Text = "2";
                break;
            case "Wednesday":
                txtHari.Text = "3";
                break;
            case "Thursday":
                txtHari.Text = "4";
                break;
            case "Friday":
                txtHari.Text = "5";
                break;
            case "Saturday":
                txtHari.Text = "6";
                break;
            case "Sunday":
                txtHari.Text = "7";
                break;
        }
    }
    public void GetListStatus(string StatusId)
    {
        SIMRS.DataAccess.RS_Status myObj = new SIMRS.DataAccess.RS_Status();
        DataTable dt = myObj.GetList();
        cmbStatusPenjamin.Items.Clear();
        int i = 0;
        cmbStatusPenjamin.Items.Add("");
        cmbStatusPenjamin.Items[i].Text = "";
        cmbStatusPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbStatusPenjamin.Items.Add("");
            cmbStatusPenjamin.Items[i].Text = dr["Nama"].ToString();
            cmbStatusPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == StatusId)
            {
                cmbStatusPenjamin.SelectedIndex = i;
            }
            i++;

        }
    }
    public void GetListPangkatPenjamin(string PangkatId)
    {
        SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
        if (cmbStatusPenjamin.SelectedIndex > 0)
            myObj.StatusId = int.Parse(cmbStatusPenjamin.SelectedItem.Value);
        DataTable dt = myObj.GetListByStatusId();
        cmbPangkatPenjamin.Items.Clear();
        int i = 0;
        cmbPangkatPenjamin.Items.Add("");
        cmbPangkatPenjamin.Items[i].Text = "";
        cmbPangkatPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPangkatPenjamin.Items.Add("");
            cmbPangkatPenjamin.Items[i].Text = dr["Nama"].ToString();
            cmbPangkatPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PangkatId)
            {
                cmbPangkatPenjamin.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetListPoliklinik(string PoliklinikId)
    {
        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        DataTable dt = myObj.GetListRJ();
        cmbPoliklinik.Items.Clear();
        int i = 0;
        cmbPoliklinik.Items.Add("");
        cmbPoliklinik.Items[i].Text = "";
        cmbPoliklinik.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPoliklinik.Items.Add("");
            cmbPoliklinik.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbPoliklinik.Items[i].Value = dr["Id"].ToString() + "|" + dr["KelompokPoliklinikId"].ToString();
            if (dr["Id"].ToString() == PoliklinikId)
                cmbPoliklinik.SelectedIndex = i;
            i++;
        }
    }
    public void GetListDokter(string DokterId )
    {
        SIMRS.DataAccess.RS_JadwalDokter myObj = new SIMRS.DataAccess.RS_JadwalDokter();
        if (cmbPoliklinik.SelectedIndex > 0)
        {
            string[] poli = cmbPoliklinik.SelectedItem.Value.Split('|');
            myObj.PoliklinikId = int.Parse(poli[0]);
        } 
        myObj.HariId = int.Parse(txtHari.Text);
        DataTable dt = myObj.GetListDokterByPoliklinikIdAndHariId();
        cmbDokter.Items.Clear();
        int i = 0;
        cmbDokter.Items.Add("");
        cmbDokter.Items[i].Text = "";
        cmbDokter.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbDokter.Items.Add("");
            cmbDokter.Items[i].Text = dr["DokterNama"].ToString() + " [" + dr["JamPraktek"].ToString() + "]";
            cmbDokter.Items[i].Value = dr["DokterId"].ToString() + "|" + dr["JamPraktek"].ToString();
            if (dr["DokterId"].ToString() == DokterId)
                cmbDokter.SelectedIndex = i;
            i++;
        }
    }
    public void GetNomorTunggu()
    {
        if (cmbPoliklinik.SelectedIndex > 0 && cmbDokter.SelectedIndex > 0)
        {
            SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
            string[] poli = cmbPoliklinik.SelectedItem.Value.Split('|');
            myObj.PoliklinikId = int.Parse(poli[0]);
            if (poli[1] != "2")//Poli UGD
            {
                myObj.DokterId = int.Parse(txtDokterId.Text);
                myObj.JamPraktek = txtJamPraktek.Text;
            }
            myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
            txtNomorTunggu.Text = myObj.GetNomorTunggu().ToString();
        }
        else
            txtNomorTunggu.Text = "";
    }
    public void GetListAgama(string AgamaId)
    {
        BkNet.DataAccess.Agama myObj = new BkNet.DataAccess.Agama();
        DataTable dt = myObj.GetList();
        cmbAgamaPenjamin.Items.Clear();
        int i = 0;
        cmbAgamaPenjamin.Items.Add("");
        cmbAgamaPenjamin.Items[i].Text = "";
        cmbAgamaPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbAgamaPenjamin.Items.Add("");
            cmbAgamaPenjamin.Items[i].Text = dr["Nama"].ToString();
            cmbAgamaPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == AgamaId)
                cmbAgamaPenjamin.SelectedIndex = i;
            i++;
        }
    }
    public void GetListPendidikan(string PendidikanId)
    {
        BkNet.DataAccess.Pendidikan myObj = new BkNet.DataAccess.Pendidikan();
        DataTable dt = myObj.GetList();
        cmbPendidikanPenjamin.Items.Clear();
        int i = 0;
        cmbPendidikanPenjamin.Items.Add("");
        cmbPendidikanPenjamin.Items[i].Text = "";
        cmbPendidikanPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPendidikanPenjamin.Items.Add("");
            cmbPendidikanPenjamin.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbPendidikanPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PendidikanId)
                cmbPendidikanPenjamin.SelectedIndex = i;
            i++;
        }
    }
    public void GetListJenisPenjamin(string JenisPenjaminId)
    {
        SIMRS.DataAccess.RS_JenisPenjamin myObj = new SIMRS.DataAccess.RS_JenisPenjamin();
        DataTable dt = myObj.GetList();
        cmbJenisPenjamin.Items.Clear();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            cmbJenisPenjamin.Items.Add("");
            cmbJenisPenjamin.Items[i].Text = dr["Nama"].ToString();
            cmbJenisPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisPenjaminId)
                cmbJenisPenjamin.SelectedIndex = i;
            i++;
        }
    }
    public void GetListHubungan(string HubunganId)
    {
        SIMRS.DataAccess.RS_Hubungan myObj = new SIMRS.DataAccess.RS_Hubungan();
        DataTable dt = myObj.GetList();
        cmbHubungan.Items.Clear();
        int i = 0;
        cmbHubungan.Items.Add("");
        cmbHubungan.Items[i].Text = "";
        cmbHubungan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbHubungan.Items.Add("");
            cmbHubungan.Items[i].Text = dr["Nama"].ToString();
            cmbHubungan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == HubunganId)
                cmbHubungan.SelectedIndex = i;
            i++;
        }
    }
    public void GetNomorRegistrasi()
    {
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        if (cmbPoliklinik.SelectedIndex > 0)
        {
            string[] poli = cmbPoliklinik.SelectedItem.Value.Split('|');
            myObj.PoliklinikId = int.Parse(poli[0]);
        }
        myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        txtNoRegistrasi.Text = myObj.GetNomorRegistrasi();
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
        
        
        SIMRS.DataAccess.RS_Penjamin myPenj = new SIMRS.DataAccess.RS_Penjamin();
        myPenj.PenjaminId = Int64.Parse(HFPenjaminId.Value);
        myPenj.SelectOne();
        if (cmbJenisPenjamin.SelectedIndex > 0)
        {
            //Input Data Penjamin
            if (cmbJenisPenjamin.SelectedIndex == 1)
            {
                if (cmbHubungan.SelectedIndex > 0)
                    myPenj.HubunganId = int.Parse(cmbHubungan.SelectedItem.Value);
                myPenj.Nama = txtNamaPenjamin.Text;
                myPenj.Umur = txtUmurPenjamin.Text;
                myPenj.Alamat = txtAlamatPenjamin.Text;
                myPenj.Telepon = txtTeleponPenjamin.Text;
                if (cmbAgamaPenjamin.SelectedIndex > 0)
                    myPenj.AgamaId = int.Parse(cmbAgamaPenjamin.SelectedItem.Value);
                if (cmbPendidikanPenjamin.SelectedIndex > 0)
                    myPenj.PendidikanId = int.Parse(cmbPendidikanPenjamin.SelectedItem.Value);
                if (cmbStatusPenjamin.SelectedIndex > 0)
                    myPenj.StatusId = int.Parse(cmbStatusPenjamin.SelectedItem.Value);
                if (cmbPangkatPenjamin.SelectedIndex > 0)
                    myPenj.PangkatId = int.Parse(cmbPangkatPenjamin.SelectedItem.Value);
                myPenj.NRP = txtNRPPenjamin.Text;
                myPenj.Jabatan = txtJabatanPenjamin.Text;
                
                //myPenj.Kesatuan = txtKesatuanPenjamin.Text;
                myPenj.Kesatuan = cmbSatuanKerjaPenjamin.SelectedItem.ToString();
                
                myPenj.AlamatKesatuan = txtAlamatKesatuanPenjamin.Text;
                myPenj.NoKTP = txtNoKTPPenjamin.Text;
                myPenj.GolDarah = txtGolDarahPenjamin.Text;
                myPenj.Keterangan = txtKeteranganPenjamin.Text;
            }
            else
            {
                myPenj.Nama = txtNamaPerusahaan.Text;
                myPenj.NamaKontak = txtNamaKontak.Text;
                myPenj.Alamat = txtAlamatPerusahaan.Text;
                myPenj.Telepon = txtTeleponPerusahaan.Text;
                myPenj.Fax = txtFAXPerusahaan.Text;
            }
            if (HFPenjaminId.Value == "0")
            {
                myPenj.CreatedBy = UserId;
                myPenj.CreatedDate = DateTime.Now;
                result = myPenj.Insert();
            }
            else
            {
                myPenj.ModifiedBy = UserId;
                myPenj.ModifiedDate = DateTime.Now;
                result = myPenj.Update();
            }
            HFPenjaminId.Value = myPenj.PenjaminId.ToString();
        }
        else
        {
            if (HFPenjaminId.Value != "0")
                myPenj.Delete();
            HFPenjaminId.Value = "0";
        }
        //Input Data Registrasi
        SIMRS.DataAccess.RS_Registrasi myReg = new SIMRS.DataAccess.RS_Registrasi();
        myReg.RegistrasiId = Int64.Parse(HFRegistrasiId.Value);
        myReg.SelectOne();
        //GetNomorRegistrasi();
        myReg.NoRegistrasi = txtNoRegistrasi.Text;
        myReg.JenisRegistrasiId = 1;
        myReg.TanggalRegistrasi = DateTime.Parse(txtTanggalRegistrasi.Text);
        myReg.JenisPenjaminId = int.Parse(cmbJenisPenjamin.SelectedItem.Value);
        if (cmbJenisPenjamin.SelectedIndex > 0)
            myReg.PenjaminId = Int64.Parse(HFPenjaminId.Value);
        else
            myReg.PenjaminId = SqlInt64.Null;
        myReg.ModifiedBy = UserId;
        myReg.ModifiedDate = DateTime.Now;
        result = myReg.Update();

        //Update Data Rawat Jalan
        SIMRS.DataAccess.RS_RawatJalan myRJ = new SIMRS.DataAccess.RS_RawatJalan();
        myRJ.RawatJalanId = Int64.Parse(HFRawatJalanId.Value);
        myRJ.SelectOne();
        myRJ.RegistrasiId = myReg.RegistrasiId;
        if (cmbPoliklinik.SelectedIndex > 0)
        {
            string[] poli = cmbPoliklinik.SelectedItem.Value.Split('|');
            myRJ.PoliklinikId = int.Parse(poli[0]);
        }
        if (cmbDokter.SelectedIndex > 0)
        {
            myRJ.DokterId = int.Parse(txtDokterId.Text);
            myRJ.JamPraktek = txtJamPraktek.Text;
        }
        myRJ.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        //GetNomorTunggu();
        if (txtNomorTunggu.Text != "")
            myRJ.NomorTunggu = int.Parse(txtNomorTunggu.Text);
        myRJ.Status = 0;//Baru daftar
        myRJ.ModifiedBy = UserId;
        myRJ.ModifiedDate = DateTime.Now;
        result = myRJ.Update();

        return result;
        //string CurrentPage = "";
        //if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
        //    CurrentPage = Request.QueryString["CurrentPage"].ToString();
        //Response.Redirect("RJView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + myRJ.RawatJalanId);
    }
    public void OnCancel()
    {
        //string CurrentPage = "";
        //if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
        //    CurrentPage = Request.QueryString["CurrentPage"].ToString();
        //Response.Redirect("RJList.aspx?CurrentPage=" + CurrentPage);
    }
    protected void cmbJenisPenjamin_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbJenisPenjamin.SelectedIndex == 1)
        {
            tblPenjaminKeluarga.Visible = true;
            tblPenjaminPerusahaan.Visible = false;
        }
        else if (cmbJenisPenjamin.SelectedIndex == 2 || cmbJenisPenjamin.SelectedIndex == 3)
        {
            tblPenjaminKeluarga.Visible = false;
            tblPenjaminPerusahaan.Visible = true;
        }
        else
        {
            tblPenjaminKeluarga.Visible = false;
            tblPenjaminPerusahaan.Visible = false;
        }
    }
    protected void cmbPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbPoliklinik.SelectedIndex > 0)
        {

            string[] poli = cmbPoliklinik.SelectedItem.Value.Split('|');
            if (poli[1] == "2")
            {
                RVDokter.Visible = false;
            }
            else
            {
                RVDokter.Visible = true;
            }
        
        }
        GetListDokter("");
        GetNomorTunggu();
        GetNomorRegistrasi();
    }
    protected void cmbDokter_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateJamPraktek();
        GetNomorTunggu();
    }
    private void UpdateJamPraktek()
    {
        if (cmbDokter.Items.Count > 1 && cmbDokter.SelectedIndex > 0)
        {
            string[] jadwaldokter = cmbDokter.SelectedItem.Value.Split('|');
            txtDokterId.Text = jadwaldokter[0];
            if (jadwaldokter.Length > 1)
                txtJamPraktek.Text = jadwaldokter[1];
        }
        else
        {
            txtDokterId.Text = "";
            txtJamPraktek.Text = "";
        }
    }
    protected void txtTanggalRegistrasi_TextChanged(object sender, EventArgs e)
    {
        UpdateHari();
        GetListDokter("");
        GetNomorTunggu();
        GetNomorRegistrasi();
    }
    protected void cmbStatusPenjamin_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPangkatPenjamin("");
    }

    public void GetListSatuanKerjaPenjamin(string Kesatuan)
    {
        SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
        DataTable dt = myObj.GetList();
        cmbSatuanKerjaPenjamin.Items.Clear();
        int i = 0;
        cmbSatuanKerjaPenjamin.Items.Add("");
        cmbSatuanKerjaPenjamin.Items[i].Text = "";
        cmbSatuanKerjaPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbSatuanKerjaPenjamin.Items.Add("");
            cmbSatuanKerjaPenjamin.Items[i].Text = dr["NamaSatKer"].ToString();
            cmbSatuanKerjaPenjamin.Items[i].Value = dr["IdSatuanKerja"].ToString();
            if (dr["NamaSatKer"].ToString() == Kesatuan)
            {
                cmbSatuanKerjaPenjamin.SelectedIndex = i;
            }
            i++;

        }
    }
}
