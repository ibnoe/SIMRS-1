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

public partial class Backoffice_Registrasi_HemoAddRI : System.Web.UI.Page
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
            if (Session["RegistrasiHemo"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListJenisPenjamin();
            GetListHubungan();
            
            GetListStatus();
            GetListPangkat();
            GetListAgama();
            GetListPendidikan();
            
            txtTanggalRegistrasi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            GetNomorRegistrasi();
            GetNomorTunggu();
            GetListKelompokPemeriksaan();
            GetListSatuanKerjaPenjamin();
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
    public void GetListPangkat()
    {
        string PangkatId = "";
        SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
        DataTable dt = myObj.GetList();
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

    public void GetNomorTunggu()
    {
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.PoliklinikId = 39;//Hemo
        myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        txtNomorTunggu.Text = myObj.GetNomorTunggu().ToString();
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
        myObj.PoliklinikId = 39;//Hemo
        myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        txtNoRegistrasi.Text = myObj.GetNomorRegistrasi();
        lblNoRegistrasi.Text = txtNoRegistrasi.Text;
    }

    public void GetListKelompokPemeriksaan()
    {
        SIMRS.DataAccess.RS_KelompokPemeriksaan myObj = new SIMRS.DataAccess.RS_KelompokPemeriksaan();
        myObj.JenisPemeriksaanId = 3;//Hemo
        DataTable dt = myObj.GetListByJenisPemeriksaanId();
        cmbKelompokPemeriksaan.Items.Clear();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelompokPemeriksaan.Items.Add("");
            cmbKelompokPemeriksaan.Items[i].Text = dr["Nama"].ToString();
            cmbKelompokPemeriksaan.Items[i].Value = dr["Id"].ToString();
            i++;
        }
        cmbKelompokPemeriksaan.SelectedIndex = 0;
        GetListPemeriksaan();
    }
    public DataSet GetDataPemeriksaan()
    {
        DataSet ds = new DataSet();
        if (Session["dsLayananHemo"] != null)
            ds = (DataSet)Session["dsLayananHemo"];
        else
        {
            SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
            myObj.PoliklinikId = 39;// Hemo
            DataTable myData = myObj.SelectAllWPoliklinikIdLogic();
            ds.Tables.Add(myData);
            Session.Add("dsLayananHemo", ds);
        }
        return ds;
    }

    public void GetListPemeriksaan()
    {
        DataSet ds = new DataSet();
        ds = GetDataPemeriksaan();
        lstRefPemeriksaan.DataTextField = "Nama";
        lstRefPemeriksaan.DataValueField = "Id";

        DataView dv = ds.Tables[0].DefaultView;
        dv.RowFilter = " KelompokPemeriksaanId = " + cmbKelompokPemeriksaan.SelectedItem.Value;
        lstRefPemeriksaan.DataSource = dv;
        lstRefPemeriksaan.DataBind();
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
        //myReg.NoUrut = txtNoUrut.Text;
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
        myRJ.AsalPasienId = Int64.Parse(txtRegistrasiId.Text);
        myRJ.PoliklinikId = 39;//Hemo
        myRJ.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        GetNomorTunggu();
        if (txtNomorTunggu.Text != "")
            myRJ.NomorTunggu = int.Parse(txtNomorTunggu.Text);
        myRJ.Status = 0;//Baru daftar
        myRJ.Keterangan = txtKeterangan.Text;
        myRJ.CreatedBy = UserId;
        myRJ.CreatedDate = DateTime.Now;
        myRJ.Insert();

        ////Input Data Layanan
        SIMRS.DataAccess.RS_RJLayanan myLayanan = new SIMRS.DataAccess.RS_RJLayanan();
        SIMRS.DataAccess.RS_Layanan myTarif = new SIMRS.DataAccess.RS_Layanan();
        if (lstPemeriksaan.Items.Count > 0)
        {
            string[] kellay;
            string[] Namakellay;
            DataTable dt;
            for (int i = 0; i < lstPemeriksaan.Items.Count; i++)
            {
                myLayanan.RJLayananId = 0;
                myLayanan.RawatJalanId = myRJ.RawatJalanId;
                myLayanan.JenisLayananId = 3;
                kellay = lstPemeriksaan.Items[i].Value.Split('|');
                Namakellay = lstPemeriksaan.Items[i].Text.Split(':');
                myLayanan.KelompokLayananId = 2;
                myLayanan.LayananId = int.Parse(kellay[1]);
                myLayanan.NamaLayanan = Namakellay[1];

                myTarif.Id = int.Parse(kellay[1]);
                dt = myTarif.GetTarifRIByLayananId(int.Parse(txtKelasId.Text));
                if (dt.Rows.Count > 0)
                    myLayanan.Tarif = dt.Rows[0]["Tarif"].ToString() != "" ? (Decimal)dt.Rows[0]["Tarif"] : 0;
                else
                    myLayanan.Tarif = 0;

                myLayanan.JumlahSatuan = double.Parse("1");
                myLayanan.Discount = 0;
                myLayanan.BiayaTambahan = 0;
                myLayanan.JumlahTagihan = myLayanan.Tarif;
                myLayanan.Keterangan = "";
                myLayanan.CreatedBy = UserId;
                myLayanan.CreatedDate = DateTime.Now;
                myLayanan.Insert();
            }
        }
        //=================
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("HemoView.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + myRJ.RawatJalanId);
    }
    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("HemoList.aspx?CurrentPage=" + CurrentPage);
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
    protected void txtTanggalRegistrasi_TextChanged(object sender, EventArgs e)
    {
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
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        if (txtNoRMSearch.Text != "")
            myObj.NoRM = txtNoRMSearch.Text;
        if (txtNamaSearch.Text != "")
            myObj.Nama = txtNamaSearch.Text;
        if (txtNRPSearch.Text != "")
            myObj.NRP = txtNRPSearch.Text;
        myData = myObj.SelectAllFilterLast(0,0,"");
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
    public void UpdateFormPasien(Int64 RawatInapId)
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = RawatInapId;
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtPasienId.Text = row["PasienId"].ToString();
            txtRawatInapId.Text = row["RawatInapId"].ToString();
            txtRegistrasiId.Text = row["RegistrasiId"].ToString();
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
            //lblKeterangan.Text = row["Keterangan"].ToString();
            if (row["KelasNama"].ToString() != "")
                txtKeterangan.Text = "Pasien Rawa Inap Kelas: " + row["KelasNama"].ToString();
            if (row["RuangNama"].ToString() != "")
                txtKeterangan.Text += " Ruangan: " + row["RuangNama"].ToString();
            if (row["NomorRuang"].ToString() != "")
                txtKeterangan.Text += " Nomor Kamar: " + row["NomorRuang"].ToString();
            if (row["KelasId"].ToString() != "")
                txtKelasId.Text = row["KelasId"].ToString();
            else
                txtKelasId.Text = "0";
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
        txtRawatInapId.Text = "";
        txtRegistrasiId.Text = "";
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
        txtKeterangan.Text = "";
        txtKelasId.Text = "0";
    }
    protected void GridViewPasien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPasien.SelectedIndex = -1;
        GridViewPasien.PageIndex = e.NewPageIndex;
        GridViewPasien.DataSource = GetResultSearch();
        GridViewPasien.DataBind();
        EmptyFormPasien();
    }

    protected void cmbKelompokPemeriksaan_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPemeriksaan();
    }
    protected void btnAddPemeriksaan_Click(object sender, EventArgs e)
    {
        if (lstRefPemeriksaan.SelectedIndex != -1)
        {
            int i = lstPemeriksaan.Items.Count;
            bool exist = false;
            string selectValue = cmbKelompokPemeriksaan.SelectedItem.Value + "|" + lstRefPemeriksaan.SelectedItem.Value;
            for (int j = 0; j < i; j++)
            {
                if (lstPemeriksaan.Items[j].Value == selectValue)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                ListItem newItem = new ListItem();
                newItem.Text = cmbKelompokPemeriksaan.SelectedItem.Text + ": " + lstRefPemeriksaan.SelectedItem.Text;
                newItem.Value = cmbKelompokPemeriksaan.SelectedItem.Value + "|" + lstRefPemeriksaan.SelectedItem.Value;
                lstPemeriksaan.Items.Add(newItem);
            }
        }
    }
    protected void btnRemovePemeriksaan_Click(object sender, EventArgs e)
    {
        if (lstPemeriksaan.SelectedIndex != -1)
        {
            lstPemeriksaan.Items.RemoveAt(lstPemeriksaan.SelectedIndex);
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

}
