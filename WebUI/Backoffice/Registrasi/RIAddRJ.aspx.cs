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

public partial class Backoffice_RawatInap_RIAddRJ : System.Web.UI.Page
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
            txtTanggalRegistrasi.Text = DateTime.Now.ToString("dd/MM/yyyy");
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
            {
                divSearch.Visible = false;
                divDataPasien.Visible = true;
                txtRawatJalanId.Text = Request.QueryString["RawatJalanId"].ToString();
                UpdateDataPasien(Int64.Parse(txtRawatJalanId.Text));
            }
            else
            {
                divSearch.Visible = true;
                divDataPasien.Visible = true;
            }
            txtTanggalMasuk.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtJamMasuk.Text = DateTime.Now.ToString("HH:mm");
            GetNomorRegistrasi();
            GetListKelas();
        }
    }
    #region "Function List"
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
        if(cmbNomorRuang.SelectedIndex > 0)
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
        if (txtTanggalMasuk.Text.IndexOf("_") == -1)
        {
            SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
            myObj.TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
            txtNoRegistrasi.Text = myObj.GetNomorRegistrasi();
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
    #endregion

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

        int PenjaminId = 0;
        if (lblPenjaminId.Text != "0")
        {
            //Input Data Penjamin
            SIMRS.DataAccess.RS_Penjamin myPenj = new SIMRS.DataAccess.RS_Penjamin();
            myPenj.PenjaminId = int.Parse(lblPenjaminId.Text);
            myPenj.SelectOne();
            myPenj.PenjaminId = 0;
            myPenj.CreatedBy = UserId;
            myPenj.CreatedDate = DateTime.Now;
            myPenj.ModifiedBy = SqlInt32.Null;
            myPenj.ModifiedDate = SqlDateTime.Null;
            myPenj.Insert();
            PenjaminId = (int)myPenj.PenjaminId;
        }
        //Input Data Registrasi
        SIMRS.DataAccess.RS_Registrasi myReg = new SIMRS.DataAccess.RS_Registrasi();
        myReg.RegistrasiId = 0;
        myReg.PasienId = Int64.Parse(txtPasienId.Text);
        GetNomorRegistrasi();
        myReg.NoRegistrasi = txtNoRegistrasi.Text;
        myReg.JenisRegistrasiId = 2;//Rawat Inap
        DateTime TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
        TanggalMasuk = TanggalMasuk.AddHours(double.Parse(txtJamMasuk.Text.Substring(0, 2)));
        TanggalMasuk = TanggalMasuk.AddMinutes(double.Parse(txtJamMasuk.Text.Substring(3, 2)));
        myReg.TanggalRegistrasi = TanggalMasuk;
        myReg.JenisPenjaminId = int.Parse(lblJenisPenjaminId.Text);
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
        myRI.AsalPasien = 1; //Dari Rawat Jalan
        myRI.DariPoliklinikId = int.Parse(lblDariPoliklinikId.Text);
        if (lblDariDokterId.Text != "")
            myRI.DariDokterId = int.Parse(lblDariDokterId.Text);
        if(cmbDokter.SelectedIndex > 0)
            myRI.DokterId = int.Parse(cmbDokter.SelectedItem.Value);
        myRI.DiagnosaMasuk = txtDiagnosaMasuk.Text;
        //if (txtDeposit.Text != "")
        //    myRI.Deposit = decimal.Parse(txtDeposit.Text);
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
        Response.Redirect(Request.ApplicationPath+"/Backoffice/Registrasi/RIList.aspx?CurrentPage=" + CurrentPage);
    }
    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Registrasi/RIList.aspx?CurrentPage=" + CurrentPage);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetListPasien();
        EmptyDataPasien();
    }
    public DataView GetResultSearch()
    {
        DataSet ds = new DataSet();
        DataTable myData = new DataTable();
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.JenisPoliklinikId = 1;//RawatJalan
        if (txtTanggalRegistrasi.Text != "")
            myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        if (txtNoRMSearch.Text != "")
            myObj.NoRM = txtNoRMSearch.Text;
        if (txtNamaSearch.Text != "")
            myObj.Nama = txtNamaSearch.Text;
        if (txtNRPSearch.Text != "")
            myObj.NRP = txtNRPSearch.Text;
        myData = myObj.SelectAllFilterForRawatInap();
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
        Int64 RawatJalanId = (Int64)GridViewPasien.SelectedValue;
        UpdateDataPasien(RawatJalanId);
    }
    public void UpdateDataPasien(Int64 RawatJalanId)
    {
        if (RawatJalanId == 0)
        {
            EmptyDataPasien();
        }
        else
        {
            SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
            myObj.RawatJalanId = RawatJalanId;
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtRawatJalanId.Text = RawatJalanId.ToString();
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
                lblTanggalLahir.Text = row["TanggalLahir"].ToString() != "" ? ((DateTime)row["TanggalLahir"]).ToString("dd MMMM yyyy") : "";
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

                //Data Registrasi
                lblNoRegistrasi.Text = row["NoRegistrasi"].ToString();
                lblNoRegistrasiHeader.Text = lblNoRegistrasi.Text;
                lblTanggalBerobat.Text = row["TanggalBerobat"].ToString() != "" ? ((DateTime)row["TanggalBerobat"]).ToString("dd MMMM yyyy") : "";
                lblPoliklinik.Text = row["PoliklinikNama"].ToString();
                lblDokter.Text = row["DokterNama"].ToString();
                lblNoTunggu.Text = row["NomorTunggu"].ToString();
                lblJenisPenjaminNama.Text = row["JenisPenjaminNama"].ToString();
                lblJenisPenjaminId.Text = row["JenisPenjaminId"].ToString();
                lblPenjaminId.Text = row["PenjaminId"].ToString() != "" ? row["PenjaminId"].ToString() : "0";
                
                if (lblJenisPenjaminId.Text == "2")
                {
                    tblPenjaminKeluargaView.Visible = true;
                    tblPenjaminPerusahaanView.Visible = false;

                    //Data Keluarga Penjamin
                    lblNamaPenjamin.Text = row["NamaPenjamin"].ToString();
                    lblHubunganNama.Text = row["HubunganNama"].ToString();
                    lblStatusPenjaminNama.Text = row["StatusNamaPenjamin"].ToString();
                    lblPangkatPenjaminNama.Text = row["PangkatNamaPenjamin"].ToString();
                    lblNoKTPPenjamin.Text = row["NoKTPPenjamin"].ToString();
                    lblGolDarahPenjamin.Text = row["GolDarahPenjamin"].ToString();
                    lblNRPPenjamin.Text = row["NRPPenjamin"].ToString();
                    lblKesatuanPenjamin.Text = row["KesatuanPenjamin"].ToString();
                    lblAlamatPenjamin.Text = row["AlamatPenjamin"].ToString();
                    lblTeleponPenjamin.Text = row["TeleponPenjamin"].ToString();
                    lblKeteranganPenjamin.Text = row["KeteranganPenjamin"].ToString();
                }
                else if (lblJenisPenjaminId.Text == "3" || lblJenisPenjaminId.Text == "4")
                {
                    tblPenjaminKeluargaView.Visible = false;
                    tblPenjaminPerusahaanView.Visible = true;
                    lblNamaPerusahan.Text = row["NamaPenjamin"].ToString();
                    lblNamaKontak.Text = row["NamaKontakPenjamin"].ToString();
                    lblAlamatPerusahaan.Text = row["AlamatPenjamin"].ToString();
                    lblTeleponPerusahaan.Text = row["TeleponPenjamin"].ToString();
                    lblFaxPerusahaan.Text = row["FaxPenjamin"].ToString();
                    lblKeteranganPerusahaan.Text = row["KeteranganPenjamin"].ToString();
                }
                else
                {
                    tblPenjaminKeluargaView.Visible = false;
                    tblPenjaminPerusahaanView.Visible = false;
                }

                //Data Registrasi Rawat Jalan
                txtTanggalMasuk.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtJamMasuk.Text = DateTime.Now.ToString("HH:mm");
                GetNomorRegistrasi();
                lblDariPoliklinik.Text = row["PoliklinikNama"].ToString();
                lblDariPoliklinikId.Text = row["PoliklinikId"].ToString();
                lblDariDokter.Text = row["DokterNama"].ToString();
                lblDariDokterId.Text = row["DokterId"].ToString();
                GetListDokter(lblDariDokterId.Text);
            }
            else
            {
                EmptyDataPasien();
            }
        }
    }
    public void EmptyDataPasien()
    {
        txtRawatJalanId.Text = "";
        txtPasienId.Text = "";
        lblNoRMHeader.Text = "";
        lblNoRM.Text = "";
        lblNamaPasienHeader.Text = "";
        lblNamaPasien.Text = "";
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

        //Data Registrasi
        lblNoRegistrasi.Text = "";
        lblNoRegistrasiHeader.Text = "";
        lblTanggalBerobat.Text = "";
        lblPoliklinik.Text = "";
        lblDokter.Text = "";
        lblNoTunggu.Text = "";
        lblJenisPenjaminNama.Text = "";
        
        //Data Keluarga Penjamin
        lblPenjaminId.Text = "";
        lblJenisPenjaminId.Text = "";
        lblNamaPenjamin.Text = "";
        lblHubunganNama.Text = "";
        lblStatusPenjaminNama.Text = "";
        lblPangkatPenjaminNama.Text = "";
        lblNoKTPPenjamin.Text = "";
        lblGolDarahPenjamin.Text = "";
        lblNRPPenjamin.Text = "";
        lblKesatuanPenjamin.Text = "";
        lblAlamatPenjamin.Text = "";
        lblTeleponPenjamin.Text = "";
        lblKeteranganPenjamin.Text = "";
        //Data Perusahaan Penjamin
        lblNamaPerusahan.Text = "";
        lblNamaKontak.Text = "";
        lblAlamatPerusahaan.Text = "";
        lblTeleponPerusahaan.Text = "";
        lblFaxPerusahaan.Text = "";
        lblKeteranganPerusahaan.Text = "";

        // Data Registrasi Rawat Jalan 
        txtNoRegistrasi.Text = "";
        txtTanggalMasuk.Text = "";
        txtJamMasuk.Text = "";
        lblDariPoliklinik.Text = "";
        lblDariPoliklinikId.Text = "";
        lblDariDokter.Text = "";
        lblDariDokterId.Text = "";
        GetListDokter("");

        tblPenjaminKeluargaView.Visible = false;
        tblPenjaminPerusahaanView.Visible = false;
    }

    protected void GridViewPasien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPasien.SelectedIndex = -1;
        GridViewPasien.PageIndex = e.NewPageIndex;
        GridViewPasien.DataSource = GetResultSearch();
        GridViewPasien.DataBind();
        UpdateDataPasien(0);
    }
    protected void txtNamaSearch_TextChanged(object sender, EventArgs e)
    {
        GetListPasien();
        EmptyDataPasien();
    }
    protected void txtNRPSearch_TextChanged(object sender, EventArgs e)
    {
        GetListPasien();
        EmptyDataPasien();
    }
    protected void txtNoRMSearch_TextChanged(object sender, EventArgs e)
    {
        GetListPasien();
        EmptyDataPasien();
    }
    //protected void txtDeposit_TextChanged(object sender, EventArgs e)
    //{
    //    if (REVDeposit.IsValid && txtDeposit.Text != "")
    //    {
    //        if (txtDeposit.Text != "0")
    //            txtDeposit.Text = (decimal.Parse(txtDeposit.Text)).ToString("#,###.###.###.###");
    //    }
    //}
    protected void txtTanggalMasuk_TextChanged(object sender, EventArgs e)
    {
        GetNomorRegistrasi();
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
}
