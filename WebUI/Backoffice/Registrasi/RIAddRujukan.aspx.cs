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

public partial class Backoffice_Registrasi_RIAddRujukan : System.Web.UI.Page
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
            if (Session["RegistrasiRI"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListStatus();
            GetListStatusPerkawinan();
            GetListAgama();
            GetListPendidikan();
            GetListJenisPenjamin();
            GetListHubungan();
            GetListKelas();
            txtTanggalMasuk.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtJamMasuk.Text = DateTime.Now.ToString("HH:mm");
            GetNomorRegistrasi();
            GetListDokter("");
            GetListSatuanKerja();
            GetListSatuanKerjaPenjamin();
        }
    }

    public void GetListStatus()
    {
        string StatusId = "";
        SIMRS.DataAccess.RS_Status myObj = new SIMRS.DataAccess.RS_Status();
        DataTable dt = myObj.GetList();
        cmbStatusPasien.Items.Clear();
        int i = 0;
        cmbStatusPasien.Items.Add("");
        cmbStatusPasien.Items[i].Text = "";
        cmbStatusPasien.Items[i].Value = "";
        cmbStatusPenjamin.Items.Add("");
        cmbStatusPenjamin.Items[i].Text = "";
        cmbStatusPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbStatusPasien.Items.Add("");
            cmbStatusPasien.Items[i].Text = dr["Nama"].ToString();
            cmbStatusPasien.Items[i].Value = dr["Id"].ToString();
            cmbStatusPenjamin.Items.Add("");
            cmbStatusPenjamin.Items[i].Text = dr["Nama"].ToString();
            cmbStatusPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == StatusId)
            {
                cmbStatusPasien.SelectedIndex = i;
                cmbStatusPenjamin.SelectedIndex = i;
            }
            i++;

        }
    }

    public void GetListPangkatPasien()
    {
        string PangkatId = "";
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
    public void GetListPangkatPenjamin()
    {
        string PangkatId = "";
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
    public void GetListKelas()
    {
        string KelasId = "";
        if (Request.QueryString["KelasId"] != null)
            KelasId = Request.QueryString["KelasId"].ToString();

        SIMRS.DataAccess.RS_Kelas myObj = new SIMRS.DataAccess.RS_Kelas();
        DataTable dt = myObj.GetListAvaliable();
        cmbKelas.Items.Clear();
        int i = 0;
        cmbKelas.Items.Add("");
        cmbKelas.Items[i].Text = "";
        cmbKelas.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelas.Items.Add("");
            cmbKelas.Items[i].Text = dr["KelasNama"].ToString();
            cmbKelas.Items[i].Value = dr["KelasId"].ToString();
            if (dr["KelasId"].ToString() == KelasId)
            {
                cmbKelas.SelectedIndex = i;
            }
            i++;
        }
        GetListRuang();
    }
    public void GetListRuang()
    {
        string RuangId = "";
        if (Request.QueryString["RuangId"] != null)
            RuangId = Request.QueryString["RuangId"].ToString();
        int KelasId = 0;
        if (cmbKelas.SelectedIndex > 0)
            KelasId = int.Parse(cmbKelas.SelectedItem.Value);

        SIMRS.DataAccess.RS_Ruang myObj = new SIMRS.DataAccess.RS_Ruang();
        DataTable dt = myObj.GetListAvaliableByKelasId(KelasId);
        cmbRuang.Items.Clear();
        int i = 0;
        cmbRuang.Items.Add("");
        cmbRuang.Items[i].Text = "";
        cmbRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbRuang.Items.Add("");
            cmbRuang.Items[i].Text = dr["RuangNama"].ToString();
            cmbRuang.Items[i].Value = dr["RuangId"].ToString();
            if (dr["RuangId"].ToString() == RuangId)
            {
                cmbRuang.SelectedIndex = i;
            }
            i++;
        }
        GetListNomorRuang();
    }
    public void GetListNomorRuang()
    {
        string RuangRawatId = "";
        if (Request.QueryString["RuangRawatId"] != null)
            RuangRawatId = Request.QueryString["RuangRawatId"].ToString();

        SIMRS.DataAccess.RS_RuangRawat myObj = new SIMRS.DataAccess.RS_RuangRawat();
        if (cmbKelas.SelectedIndex > 0)
            myObj.KelasId = int.Parse(cmbKelas.SelectedItem.Value);
        if (cmbRuang.SelectedIndex > 0)
            myObj.RuangId = int.Parse(cmbRuang.SelectedItem.Value);
        DataTable dt = myObj.GetListAvaliableNomorRuang();
        cmbNomorRuang.Items.Clear();
        int i = 0;
        cmbNomorRuang.Items.Add("");
        cmbNomorRuang.Items[i].Text = "";
        cmbNomorRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbNomorRuang.Items.Add("");
            cmbNomorRuang.Items[i].Text = dr["NomorRuang"].ToString();
            cmbNomorRuang.Items[i].Value = dr["RuangRawatId"].ToString();
            if (dr["RuangRawatId"].ToString() == RuangRawatId)
            {
                cmbNomorRuang.SelectedIndex = i;
            }
            i++;
        }
        GetListNomorTempat();
    }
    public void GetListNomorTempat()
    {
        string TempatTidurId = "";
        if (Request.QueryString["TempatTidurId"] != null)
            TempatTidurId = Request.QueryString["TempatTidurId"].ToString();

        SIMRS.DataAccess.RS_TempatTidur myObj = new SIMRS.DataAccess.RS_TempatTidur();
        if (cmbNomorRuang.SelectedIndex > 0)
            myObj.RuangRawatId = int.Parse(cmbNomorRuang.SelectedItem.Value);
        DataTable dt = myObj.GetListAvaliableByRawatId();
        cmbNomorTempat.Items.Clear();
        int i = 0;
        cmbNomorTempat.Items.Add("");
        cmbNomorTempat.Items[i].Text = "";
        cmbNomorTempat.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbNomorTempat.Items.Add("");
            cmbNomorTempat.Items[i].Text = dr["NomorTempat"].ToString();
            cmbNomorTempat.Items[i].Value = dr["TempatTidurId"].ToString();
            if (dr["TempatTidurId"].ToString() == TempatTidurId)
            {
                cmbNomorTempat.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetNomorRegistrasi()
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
        txtNoRegistrasi.Text = myObj.GetNomorRegistrasi();
    }
    public void GetListStatusPerkawinan()
    {
        string StatusPerkawinanId = "";
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
    public void GetListAgama()
    {
        string AgamaId = "";
        BkNet.DataAccess.Agama myObj = new BkNet.DataAccess.Agama();
        DataTable dt = myObj.GetList();
        cmbAgama.Items.Clear();
        int i = 0;
        cmbAgama.Items.Add("");
        cmbAgama.Items[i].Text = "";
        cmbAgama.Items[i].Value = "";
        cmbAgamaPenjamin.Items.Add("");
        cmbAgamaPenjamin.Items[i].Text = "";
        cmbAgamaPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbAgama.Items.Add("");
            cmbAgama.Items[i].Text = dr["Nama"].ToString();
            cmbAgama.Items[i].Value = dr["Id"].ToString();
            cmbAgamaPenjamin.Items.Add("");
            cmbAgamaPenjamin.Items[i].Text = dr["Nama"].ToString();
            cmbAgamaPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == AgamaId)
                cmbAgama.SelectedIndex = i;
            i++;
        }
    }
    public void GetListPendidikan()
    {
        string PendidikanId = "";
        BkNet.DataAccess.Pendidikan myObj = new BkNet.DataAccess.Pendidikan();
        DataTable dt = myObj.GetList();
        cmbPendidikan.Items.Clear();
        int i = 0;
        cmbPendidikan.Items.Add("");
        cmbPendidikan.Items[i].Text = "";
        cmbPendidikan.Items[i].Value = "";
        cmbPendidikanPenjamin.Items.Add("");
        cmbPendidikanPenjamin.Items[i].Text = "";
        cmbPendidikanPenjamin.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPendidikan.Items.Add("");
            cmbPendidikan.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbPendidikan.Items[i].Value = dr["Id"].ToString();
            cmbPendidikanPenjamin.Items.Add("");
            cmbPendidikanPenjamin.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbPendidikanPenjamin.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PendidikanId)
                cmbPendidikan.SelectedIndex = i;
            i++;
        }
    }
    public void GetListJenisPenjamin()
    {
        string JenisPenjaminId = "";
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
    public void GetListHubungan()
    {
        string HubunganId = "";
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
    public void GetListDokter(string DokterId)
    {
        SIMRS.DataAccess.RS_Dokter myObj = new SIMRS.DataAccess.RS_Dokter();
        DataTable dt = myObj.GetList();
        cmbDokter.Items.Clear();
        int i = 0;
        cmbDokter.Items.Add("");
        cmbDokter.Items[i].Text = "";
        cmbDokter.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbDokter.Items.Add("");
            cmbDokter.Items[i].Text = dr["Nama"].ToString() + " [" + dr["SpesialisNama"].ToString() + "]";
            cmbDokter.Items[i].Value = dr["DokterId"].ToString();
            if (dr["DokterId"].ToString() == DokterId)
                cmbDokter.SelectedIndex = i;
            i++;
        }
    }
    public void OnSave(Object sender, EventArgs e)
    {
        lblError.Text = "";
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        int UserId = (int)Session["SIMRS.UserId"];
        if (!Page.IsValid)
        {
            return;
        }
        string noRM1 = txtNoRM.Text.Replace("_","");
        string noRM2 = noRM1.Replace(".","");
        if (noRM2 == "")
        {
            lblError.Text = "Nomor Rekam Medis Harus diisi";
            return;
        }
        else if (noRM2.Length < 5)
        {
            lblError.Text = "Nomor Rekam Medis Harus diisi dengan benar";
            return;
        }
        //if(noRM1.Substring(noRM1.LastIndexOf(".")) == "")

        SIMRS.DataAccess.RS_Pasien myPasien = new SIMRS.DataAccess.RS_Pasien();
        //txtNoRM.Text = txtNoRM1.Text + "." + txtNoRM2.Text + "." + txtNoRM3.Text;
        myPasien.PasienId = 0;
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
        
        //myPasien.Kesatuan = txtKesatuanPasien.Text;
        myPasien.Kesatuan = cmbSatuanKerja.SelectedItem.ToString();
        
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
        myPasien.CreatedBy = UserId;
        myPasien.CreatedDate = DateTime.Now;

        if (myPasien.IsExist())
        {
            lblError.Text = myPasien.ErrorMessage.ToString();
            return;
        }
        else
        {
            myPasien.Insert();
            int PenjaminId = 0;
            if (cmbJenisPenjamin.SelectedIndex > 0)
            {
                //Input Data Penjamin
                SIMRS.DataAccess.RS_Penjamin myPenj = new SIMRS.DataAccess.RS_Penjamin();
                myPenj.PenjaminId = 0;
                if (cmbJenisPenjamin.SelectedIndex == 1)
                {
                    myPenj.Nama = txtNamaPenjamin.Text;
                    if (cmbHubungan.SelectedIndex > 0)
                        myPenj.HubunganId = int.Parse(cmbHubungan.SelectedItem.Value);
                    myPenj.Umur = txtUmurPenjamin.Text;
                    myPenj.Alamat = txtAlamatPenjamin.Text;
                    myPenj.Telepon = txtTeleponPenjamin.Text;
                    if (cmbAgamaPenjamin.SelectedIndex > 0)
                        myPenj.AgamaId = int.Parse(cmbAgamaPenjamin.SelectedItem.Value);
                    if (cmbPendidikanPenjamin.SelectedIndex > 0)
                        myPenj.PendidikanId = int.Parse(cmbPendidikanPenjamin.SelectedItem.Value);
                    if (cmbPangkatPenjamin.SelectedIndex > 0)
                        myPenj.PangkatId = int.Parse(cmbPangkatPenjamin.SelectedItem.Value);
                    myPenj.NoKTP = txtNoKTPPenjamin.Text;
                    myPenj.GolDarah = txtGolDarahPenjamin.Text;
                    myPenj.NRP = txtNRPPenjamin.Text;
                    
                    //myPenj.Kesatuan = txtKesatuanPenjamin.Text;
                    myPenj.Kesatuan = cmbSatuanKerjaPenjamin.SelectedItem.ToString();
                    
                    myPenj.AlamatKesatuan = txtAlamatKesatuanPenjamin.Text;
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
                myPenj.CreatedBy = UserId;
                myPenj.CreatedDate = DateTime.Now;
                myPenj.Insert();
                PenjaminId = (int)myPenj.PenjaminId;
            }
            //Input Data Registrasi
            SIMRS.DataAccess.RS_Registrasi myReg = new SIMRS.DataAccess.RS_Registrasi();
            myReg.RegistrasiId = 0;
            myReg.PasienId = myPasien.PasienId;
            GetNomorRegistrasi();
            myReg.NoRegistrasi = txtNoRegistrasi.Text;
            myReg.JenisRegistrasiId = 2;//Rawat Inap
            DateTime TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
            TanggalMasuk = TanggalMasuk.AddHours(double.Parse(txtJamMasuk.Text.Substring(0, 2)));
            TanggalMasuk = TanggalMasuk.AddMinutes(double.Parse(txtJamMasuk.Text.Substring(3, 2)));
            myReg.TanggalRegistrasi = TanggalMasuk;
            myReg.JenisPenjaminId = int.Parse(cmbJenisPenjamin.SelectedItem.Value);
            if (PenjaminId != 0)
                myReg.PenjaminId = PenjaminId;
            myReg.CreatedBy = UserId;
            myReg.CreatedDate = DateTime.Now;
            myReg.Insert();

            //Input Data Rawat Inap
            SIMRS.DataAccess.RS_RawatInap myRI = new SIMRS.DataAccess.RS_RawatInap();
            myRI.RawatInapId = 0;
            myRI.RegistrasiId = myReg.RegistrasiId;
            myRI.TanggalMasuk = myReg.TanggalRegistrasi;
            myRI.AsalPasien = 2; //Dari Rujukan
            myRI.DariRujukan = txtDariRujukan.Text;
            if (cmbDokter.SelectedIndex > 0)
                myRI.DokterId = int.Parse(cmbDokter.SelectedItem.Value);
        
            
            myRI.DiagnosaMasuk = txtDiagnosaMasuk.Text;
            if (txtDeposit.Text != "")
                myRI.Deposit = decimal.Parse(txtDeposit.Text);
            myRI.Status = 0;//Baru daftar
            myRI.CreatedBy = UserId;
            myRI.CreatedDate = DateTime.Now;
            myRI.Insert();

            //Input Data Tempat Inap
            SIMRS.DataAccess.RS_TempatInap myTempat = new SIMRS.DataAccess.RS_TempatInap();
            myTempat.TempatInapId = 0;
            myTempat.RawatInapId = myRI.RawatInapId;
            myTempat.RuangRawatId = int.Parse(cmbNomorRuang.SelectedItem.Value);
            if (cmbNomorTempat.SelectedIndex > 0)
                myTempat.TempatTidurId = int.Parse(cmbNomorTempat.SelectedItem.Value);
            myTempat.TanggalMasuk = myReg.TanggalRegistrasi;
            myTempat.CreatedBy = UserId;
            myTempat.CreatedDate = DateTime.Now;
            myTempat.Insert();

            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("RIView.aspx?CurrentPage=" + CurrentPage + "&RawatInapId=" + myRI.RawatInapId);
        }
    }
    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("RIList.aspx?CurrentPage=" + CurrentPage);
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

    protected void txtDeposit_TextChanged(object sender, EventArgs e)
    {
        if (REVDeposit.IsValid && txtDeposit.Text != "")
        {
            if (txtDeposit.Text != "0")
                txtDeposit.Text = (decimal.Parse(txtDeposit.Text)).ToString("#,###.###.###.###");
        }
    }
    protected void txtTanggalMasuk_TextChanged(object sender, EventArgs e)
    {
        GetNomorRegistrasi();
    }
    protected void cmbStatusPasien_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPangkatPasien();
    }
    protected void cmbStatusPenjamin_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPangkatPenjamin();
    }
    protected void cmbKelas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListRuang();
    }
    protected void cmbRuang_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListNomorRuang();
    }
    protected void cmbNomorRuang_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListNomorTempat();
    }
    protected void btnCek_Click(object sender, EventArgs e)
    {
        SIMRS.DataAccess.RS_Pasien myPasien = new SIMRS.DataAccess.RS_Pasien();
        myPasien.NoRM = txtNoRM.Text.Replace("_", "");
        if (myPasien.IsExistRM())
        {
            lblCek.Text = "No.RM sudah terpakai";
            return;
        }
        else
        {
            lblCek.Text = "No.RM belum terpakai";
            return;
        }
    }

    public void GetListSatuanKerja()
    {
        string SatuanKerjaId = "";
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
            if (dr["IdSatuanKerja"].ToString() == SatuanKerjaId)
                cmbSatuanKerja.SelectedIndex = i;
            i++;
        }
    }

    public void GetListSatuanKerjaPenjamin()
    {
        string SatuanKerjaId = "";
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
            cmbSatuanKerjaPenjamin.Items[i].Text = dr["NamaSatker"].ToString();
            cmbSatuanKerjaPenjamin.Items[i].Value = dr["IdSatuanKerja"].ToString();
            if (dr["IdSatuanKerja"].ToString() == SatuanKerjaId)
                cmbSatuanKerjaPenjamin.SelectedIndex = i;
            i++;
        }
    }

}
