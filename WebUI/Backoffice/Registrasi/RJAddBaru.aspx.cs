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

public partial class Backoffice_Registrasi_RJAddBaru : System.Web.UI.Page
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
            if (Session["RegistrasiRJ"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListStatus();
            GetListPoliklinik();
            GetListStatusPerkawinan();
            GetListAgama();
            GetListPendidikan();
            GetListJenisPenjamin();
            GetListHubungan();
            txtTanggalRegistrasi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            string hari = DateTime.Now.DayOfWeek.ToString();
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
            GetNomorRegistrasi();
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
    public void GetListPoliklinik()
    {
        string PoliklinikId = "";
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
            cmbPoliklinik.Items[i].Value = dr["Id"].ToString()+"|"+dr["KelompokPoliklinikId"].ToString();
            if (dr["Id"].ToString() == PoliklinikId)
                cmbPoliklinik.SelectedIndex = i;
            i++;
        }
    }
    public void GetListDokter()
    {
        string DokterId = "";
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
            //if (poli[1] != "2")//Poli UGD
            //{
                myObj.DokterId = int.Parse(txtDokterId.Text);
                myObj.JamPraktek = txtJamPraktek.Text;
            //}
            myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
            txtNomorTunggu.Text = myObj.GetNomorTunggu().ToString();
        }
        else
            txtNomorTunggu.Text = "";
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
        myPasien.Jabatan = txtJabatanPasien.Text;
        
        //myPasien.Kesatuan = txtKesatuanPasien.Text;
        myPasien.Kesatuan = cmbSatuanKerja.SelectedItem.ToString();
        
        myPasien.AlamatKesatuan = txtAlamatKesatuanPasien.Text;
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
            myReg.JenisRegistrasiId = 1;
            myReg.TanggalRegistrasi = DateTime.Parse(txtTanggalRegistrasi.Text);
            myReg.JenisPenjaminId = int.Parse(cmbJenisPenjamin.SelectedItem.Value);
            if (PenjaminId != 0)
                myReg.PenjaminId = PenjaminId;
            myReg.CreatedBy = UserId;
            myReg.CreatedDate = DateTime.Now;
            myReg.Insert();

            //Input Data Rawat Jalan
            SIMRS.DataAccess.RS_RawatJalan myRJ = new SIMRS.DataAccess.RS_RawatJalan();
            myRJ.RawatJalanId = 0;
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
            myRJ.TanggalBerobat =  DateTime.Parse(txtTanggalRegistrasi.Text);
            GetNomorTunggu();
            if (txtNomorTunggu.Text != "" )
                myRJ.NomorTunggu = int.Parse(txtNomorTunggu.Text);
            myRJ.Status = 0;//Baru daftar
            myRJ.CreatedBy = UserId;
            myRJ.CreatedDate = DateTime.Now;
            myRJ.Insert();

            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("RJView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + myRJ.RawatJalanId);
        }
    }
    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("RJList.aspx?CurrentPage=" + CurrentPage);
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
        GetListDokter();
        GetNomorTunggu();
        GetNomorRegistrasi();
    }
    protected void cmbDokter_SelectedIndexChanged(object sender, EventArgs e)
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
        GetNomorTunggu();
    }
    protected void txtTanggalRegistrasi_TextChanged(object sender, EventArgs e)
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
        GetListDokter();
        GetNomorTunggu();
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
            {
                cmbSatuanKerja.SelectedIndex = i;
            }
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
            {
                cmbSatuanKerjaPenjamin.SelectedIndex = i;
            }
            i++;

        }
    }

}
