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

public partial class Backoffice_Registrasi_RJAddLama : System.Web.UI.Page
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

            GetListPoliklinik();
            
            
            GetListHubungan();
            
            GetListStatus();
            GetListAgama();
            GetListPendidikan();
            
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
            GetListSatuanKerjaPenjamin();

            GetListJenisPenjamin();
        }
    }
    //=========
    public void GetListStatus()
    {
        string StatusId = "";
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
    
    public void GetListAgama()
    {
        string AgamaId = "";
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
    public void GetListPendidikan()
    {
        string PendidikanId = "";
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
    //==========

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
            cmbPoliklinik.Items[i].Value = dr["Id"].ToString() + "|" + dr["KelompokPoliklinikId"].ToString();
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
        lblNoRegistrasi.Text = txtNoRegistrasi.Text;
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
        if (txtPasienId.Text == "")
        {
            lblError.Text = "Data Pasien Belum dipilih !";
            return;
        }


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
                if (cmbStatusPenjamin.SelectedIndex > 0)
                    myPenj.StatusId = int.Parse(cmbStatusPenjamin.SelectedItem.Value);
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
        myReg.PasienId = Int64.Parse(txtPasienId.Text);
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
        myRJ.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        GetNomorTunggu();
        if (txtNomorTunggu.Text != "")
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

            if (txtPenjaminId.Text != "")
            {
                SIMRS.DataAccess.RS_Penjamin myRJ = new SIMRS.DataAccess.RS_Penjamin();
                myRJ.PenjaminId = Int64.Parse(txtPenjaminId.Text);
                DataTable dt = myRJ.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtNamaPenjamin.Text = row["Nama"].ToString();
                    cmbHubungan.SelectedValue = row["HubunganId"].ToString();
                    txtUmurPenjamin.Text = row["Umur"].ToString();
                    txtAlamatPenjamin.Text = row["Alamat"].ToString();
                    txtTeleponPenjamin.Text = row["Telepon"].ToString();
                    cmbAgamaPenjamin.SelectedValue = row["AgamaId"].ToString();
                    cmbPendidikanPenjamin.SelectedValue = row["PendidikanId"].ToString();
                    cmbStatusPenjamin.SelectedValue = row["StatusId"].ToString();
                    cmbPangkatPenjamin.SelectedValue = row["PangkatId"].ToString();
                    txtNoKTPPenjamin.Text = row["NoKTP"].ToString();
                    txtGolDarahPenjamin.Text = row["GolDarah"].ToString();
                    txtNRPPenjamin.Text = row["NRP"].ToString();
                    //cmbSatuanKerjaPenjamin.Text = row["Kesatuan"].ToString();
                    txtAlamatKesatuanPenjamin.Text = row["AlamatKesatuan"].ToString();
                    txtKeteranganPenjamin.Text = row["Keterangan"].ToString();

                }
                else
                {
                    EmptyFormPejamin();
                }
            }
        }

        else if (cmbJenisPenjamin.SelectedIndex == 2 || cmbJenisPenjamin.SelectedIndex == 3)
        {
            tblPenjaminKeluarga.Visible = false;
            tblPenjaminPerusahaan.Visible = true;

            if (txtPenjaminId.Text != "")
            {
                SIMRS.DataAccess.RS_Penjamin myRJ = new SIMRS.DataAccess.RS_Penjamin();
                myRJ.PenjaminId = Int64.Parse(txtPenjaminId.Text);
                DataTable dt = myRJ.SelectOne();
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtNamaPerusahaan.Text = row["Nama"].ToString();
                    txtNamaKontak.Text = row["NamaKontak"].ToString();
                    txtAlamatPerusahaan.Text = row["Alamat"].ToString();
                    txtTeleponPerusahaan.Text = row["Telepon"].ToString();
                    txtFAXPerusahaan.Text = row["Fax"].ToString();
                    txtKeteranganPerusahaan.Text = row["Keterangan"].ToString();
                }
                else
                {
                    EmptyFormPejamin();
                }
            }

        }
        else
        {
            tblPenjaminKeluarga.Visible = false;
            tblPenjaminPerusahaan.Visible = false;
        }
    }

    public void EmptyFormPejamin()
    {
        txtNamaPenjamin.Text = "";
        cmbHubungan.SelectedValue = "";
        txtUmurPenjamin.Text = "";
        txtAlamatPenjamin.Text = "";
        txtTeleponPenjamin.Text = "";
        cmbAgamaPenjamin.SelectedIndex = 0;
        cmbPendidikanPenjamin.SelectedIndex = 0;
        cmbStatusPenjamin.SelectedIndex = 0;
        //cmbPangkatPenjamin.SelectedIndex = 0;
        txtNoKTPPenjamin.Text = "";
        txtGolDarahPenjamin.Text = "";
        txtNRPPenjamin.Text = "";
        cmbSatuanKerjaPenjamin.SelectedIndex = 0;
        txtAlamatKesatuanPenjamin.Text = "";
        txtKeteranganPenjamin.Text = "";

        txtNamaPerusahaan.Text = "";
        txtNamaKontak.Text = "";
        txtAlamatPerusahaan.Text = "";
        txtTeleponPerusahaan.Text = "";
        txtFAXPerusahaan.Text = "";
        txtKeteranganPerusahaan.Text = "";
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
        DateTime tanggal = DateTime.Parse(txtTanggalRegistrasi.Text);
        string hari = tanggal.DayOfWeek.ToString();
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetListPasien();
        EmptyFormPasien();
    }
    public DataView GetResultSearch()
    {
        DataSet ds = new DataSet();
        DataTable myData = new DataTable();
        SIMRS.DataAccess.RS_Pasien myObj = new SIMRS.DataAccess.RS_Pasien();
        if (txtNoRMSearch.Text != "")
            myObj.NoRM = txtNoRMSearch.Text;
        if (txtNamaSearch.Text != "")
            myObj.Nama = txtNamaSearch.Text;
        if (txtNRP.Text != "")
            myObj.NRP = txtNRP.Text;
        myData = myObj.SelectAllFilter();
        DataView dv = myData.DefaultView;
        return dv;
    }
    public void GetListPasien()
    {
        GridViewPasien.SelectedIndex = -1;
        // Re-binds the grid 
        GridViewPasien.DataSource = GetResultSearch();
        GridViewPasien.DataBind();
    }
    protected void GridViewPasien_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 PaseinId = (Int64)GridViewPasien.SelectedValue;
        UpdateFormPasien(PaseinId);
        EmptyFormPejamin();
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

    public void UpdateFormPasien(Int64 PaseinId)
    {
        SIMRS.DataAccess.RS_Pasien myObj = new SIMRS.DataAccess.RS_Pasien();
        myObj.PasienId = PaseinId;
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtPasienId.Text = row["PasienId"].ToString();
            lblNoRMHeader.Text = row["NoRM"].ToString();
            lblNoRM.Text = row["NoRM"].ToString();
            lblNamaPasienHeader.Text = row["Nama"].ToString();
            lblNamaPasien.Text = row["Nama"].ToString();
            lblStatus.Text = row["StatusNama"].ToString();
            lblPangkat.Text = row["PangkatNama"].ToString();
            lblNoAskes.Text = row["NoAskes"].ToString();
            lblNoKTP.Text = row["NoKTP"].ToString();
            lblGolDarah.Text = row["GolDarah"].ToString();
            lblNRP.Text = row["NRP"].ToString();
            lblKesatuan.Text = row["Kesatuan"].ToString();
            lblTempatLahir.Text = row["TempatLahir"].ToString() == "" ? "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" : row["TempatLahir"].ToString();
            lblTanggalLahir.Text = row["TanggalLahir"].ToString() != "" ? ((DateTime)row["TanggalLahir"]).ToString("dd MMMM yyyy"):"";
            lblAlamat.Text = row["Alamat"].ToString();
            lblTelepon.Text = row["Telepon"].ToString();
            lblJenisKelamin.Text = row["JenisKelamin"].ToString();
            lblStatusPerkawinan.Text = row["StatusPerkawinanNama"].ToString();
            lblAgama.Text = row["AgamaNama"].ToString();
            lblPendidikan.Text = row["PendidikanNama"].ToString();
            lblPekerjaan.Text = row["Pekerjaan"].ToString();
            lblAlamatKantor.Text = row["AlamatKantor"].ToString();
            lblTeleponKantor.Text = row["TeleponKantor"].ToString();
            lblKeterangan.Text = row["Keterangan"].ToString();
        }
        else
        {
            EmptyFormPasien();
        }

        SIMRS.DataAccess.RS_Registrasi myReg = new SIMRS.DataAccess.RS_Registrasi();
        myReg.PasienId = Int64.Parse(txtPasienId.Text);
        DataTable dTbl = myReg.SelectOne_ByPasienId();
        if (dTbl.Rows.Count > 0)
        {
            DataRow rs = dTbl.Rows[0];
            txtPenjaminId.Text = rs["PenjaminId"].ToString();
        }
    }
    public void EmptyFormPasien()
    {
        txtPasienId.Text = "";
        lblNoRMHeader.Text = "";
        lblNoRM.Text = "";
        lblNamaPasien.Text = "";
        lblNamaPasienHeader.Text = "";
        lblStatus.Text = "";
        lblPangkat.Text = "";
        lblNoAskes.Text = "";
        lblNoKTP.Text = "";
        lblGolDarah.Text = "";
        lblNRP.Text = "";
        lblKesatuan.Text = "";
        lblTempatLahir.Text = "";
        lblTanggalLahir.Text = "";
        lblAlamat.Text = "";
        lblTelepon.Text = "";
        lblJenisKelamin.Text = "";
        lblStatusPerkawinan.Text = "";
        lblAgama.Text = "";
        lblPendidikan.Text = "";
        lblPekerjaan.Text = "";
        lblAlamatKantor.Text = "";
        lblTeleponKantor.Text = "";
        lblKeterangan.Text = "";
    }
    protected void GridViewPasien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPasien.SelectedIndex = -1;
        GridViewPasien.PageIndex = e.NewPageIndex;
        GridViewPasien.DataSource = GetResultSearch();
        GridViewPasien.DataBind();
        EmptyFormPasien();
    }
    protected void cmbStatusPenjamin_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPangkatPenjamin();
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
