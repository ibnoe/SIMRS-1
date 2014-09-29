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

public partial class Backoffice_Controls_EditRegistrasiRI : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
    public void Draw(string RawatInapId)
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = Int64.Parse(RawatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            HFRegistrasiId.Value = row["RegistrasiId"].ToString();
            HFRawatInapId.Value = row["RawatInapId"].ToString();
            HFPasienId.Value = row["PasienId"].ToString();
            HFStatusRawatInap.Value = row["StatusRawatInap"].ToString();
            HFTempatInapId.Value = row["TempatInapId"].ToString();
            HFPenjaminId.Value = row["PenjaminId"].ToString() == "" ? "0" : row["PenjaminId"].ToString();

            lblNoRM.Text = row["NoRM"].ToString();
            lblNamaPasien.Text = row["Nama"].ToString();
            //Data Registrasi
            lblNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            txtNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            txtTanggalMasuk.Text = row["TanggalMasuk"].ToString() != "" ? ((DateTime)row["TanggalMasuk"]).ToString("dd/MM/yyyy") : "";
            txtJamMasuk.Text = row["TanggalMasuk"].ToString() != "" ? ((DateTime)row["TanggalMasuk"]).ToString("HH:mm") : "";
            //GetListKelas(row["KelasId"].ToString());
            //GetListRuang(row["RuangId"].ToString());
            //GetListNomorRuang(row["RuangRawatId"].ToString());
            //GetListNomorTempat(row["TempatTidurId"].ToString());
            lblAsalPasien.Text = row["AsalPasien"].ToString();
            if (lblAsalPasien.Text == "1")
            {
                lblAsalPasienNama.Text = "Rawat Jalan";
                trRujukan.Visible = false;
                trDariPoliklinik.Visible = true;
                trDariDokter.Visible = true;
            }
            else
            {
                lblAsalPasienNama.Text = "Rujukan";
                trRujukan.Visible = true;
                trDariPoliklinik.Visible = false;
                trDariDokter.Visible = false;
            }
            txtDariRujukan.Text = row["DariRujukan"].ToString();
            lblDariPoliklinik.Text = row["DariPoliklinikNama"].ToString();
            lblDariPoliklinikId.Text = row["DariPoliklinikId"].ToString();
            lblDariDokter.Text = row["DariDokterNama"].ToString();
            lblDariDokterId.Text = row["DariDokterId"].ToString();
            GetListDokter(row["DokterId"].ToString());
            txtDiagnosaMasuk.Text = row["DiagnosaMasuk"].ToString();
            //txtDeposit.Text = row["Deposit"].ToString() != "" ? ((decimal)row["Deposit"]).ToString("#,###.###.###.###") : "";
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

    //public void GetListKelas(string KelasId)
    //{
    //    SIMRS.DataAccess.RS_Kelas myObj = new SIMRS.DataAccess.RS_Kelas();
    //    if (KelasId != "")
    //        myObj.Id = int.Parse(KelasId);
    //    DataTable dt = myObj.GetListAvaliableEdit();
    //    cmbKelas.Items.Clear();
    //    int i = 0;
    //    cmbKelas.Items.Add("");
    //    cmbKelas.Items[i].Text = "";
    //    cmbKelas.Items[i].Value = "";
    //    i++;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        cmbKelas.Items.Add("");
    //        cmbKelas.Items[i].Text = dr["KelasNama"].ToString();
    //        cmbKelas.Items[i].Value = dr["KelasId"].ToString();
    //        if (dr["KelasId"].ToString() == KelasId)
    //        {
    //            cmbKelas.SelectedIndex = i;
    //        }
    //        i++;
    //    }
    //}
    //public void GetListRuang(string RuangId)
    //{
    //    int KelasId = 0;
    //    if (cmbKelas.SelectedIndex > 0)
    //        KelasId = int.Parse(cmbKelas.SelectedItem.Value);

    //    SIMRS.DataAccess.RS_Ruang myObj = new SIMRS.DataAccess.RS_Ruang();
    //    if (RuangId != "")
    //        myObj.Id = int.Parse(RuangId);
    //    DataTable dt = myObj.GetListAvaliableEditByKelasId(KelasId);
    //    cmbRuang.Items.Clear();
    //    int i = 0;
    //    cmbRuang.Items.Add("");
    //    cmbRuang.Items[i].Text = "";
    //    cmbRuang.Items[i].Value = "";
    //    i++;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        cmbRuang.Items.Add("");
    //        cmbRuang.Items[i].Text = dr["RuangNama"].ToString();
    //        cmbRuang.Items[i].Value = dr["RuangId"].ToString();
    //        if (dr["RuangId"].ToString() == RuangId)
    //        {
    //            cmbRuang.SelectedIndex = i;
    //        }
    //        i++;
    //    }
    //}
    //public void GetListNomorRuang(string RuangRawatId)
    //{
    //    SIMRS.DataAccess.RS_RuangRawat myObj = new SIMRS.DataAccess.RS_RuangRawat();
    //    if (cmbKelas.SelectedIndex > 0)
    //        myObj.KelasId = int.Parse(cmbKelas.SelectedItem.Value);
    //    if (cmbRuang.SelectedIndex > 0)
    //        myObj.RuangId = int.Parse(cmbRuang.SelectedItem.Value);
    //    if (RuangRawatId != "")
    //        myObj.RuangRawatId = int.Parse(RuangRawatId);
    //    DataTable dt = myObj.GetListAvaliableNomorRuangEdit();
    //    cmbNomorRuang.Items.Clear();
    //    int i = 0;
    //    cmbNomorRuang.Items.Add("");
    //    cmbNomorRuang.Items[i].Text = "";
    //    cmbNomorRuang.Items[i].Value = "";
    //    i++;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        cmbNomorRuang.Items.Add("");
    //        cmbNomorRuang.Items[i].Text = dr["NomorRuang"].ToString();
    //        cmbNomorRuang.Items[i].Value = dr["RuangRawatId"].ToString();
    //        if (dr["RuangRawatId"].ToString() == RuangRawatId)
    //        {
    //            cmbNomorRuang.SelectedIndex = i;
    //        }
    //        i++;
    //    }
    //}
    //public void GetListNomorTempat(string TempatTidurId)
    //{
    //    SIMRS.DataAccess.RS_TempatTidur myObj = new SIMRS.DataAccess.RS_TempatTidur();
    //    if (cmbNomorRuang.SelectedIndex > 0)
    //        myObj.RuangRawatId = int.Parse(cmbNomorRuang.SelectedItem.Value);
    //    if (TempatTidurId != "")
    //        myObj.TempatTidurId = int.Parse(TempatTidurId);
    //    DataTable dt = myObj.GetListAvaliableEditByRawatId();
    //    cmbNomorTempat.Items.Clear();
    //    int i = 0;
    //    cmbNomorTempat.Items.Add("");
    //    cmbNomorTempat.Items[i].Text = "";
    //    cmbNomorTempat.Items[i].Value = "";
    //    i++;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        cmbNomorTempat.Items.Add("");
    //        cmbNomorTempat.Items[i].Text = dr["NomorTempat"].ToString();
    //        cmbNomorTempat.Items[i].Value = dr["TempatTidurId"].ToString();
    //        if (dr["TempatTidurId"].ToString() == TempatTidurId)
    //        {
    //            cmbNomorTempat.SelectedIndex = i;
    //        }
    //        i++;
    //    }
    //}
    
    public void GetNomorRegistrasi()
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
        txtNoRegistrasi.Text = myObj.GetNomorRegistrasi();
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
        myReg.NoRegistrasi = txtNoRegistrasi.Text;
        //myReg.JenisRegistrasiId = 2;//RawatInap
        DateTime TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
        TanggalMasuk = TanggalMasuk.AddHours(double.Parse(txtJamMasuk.Text.Substring(0, 2)));
        TanggalMasuk = TanggalMasuk.AddMinutes(double.Parse(txtJamMasuk.Text.Substring(3, 2)));
        myReg.TanggalRegistrasi = TanggalMasuk;
        myReg.JenisPenjaminId = int.Parse(cmbJenisPenjamin.SelectedItem.Value);
        if (cmbJenisPenjamin.SelectedIndex > 0)
            myReg.PenjaminId = Int64.Parse(HFPenjaminId.Value);
        else
            myReg.PenjaminId = SqlInt64.Null;
        myReg.ModifiedBy = UserId;
        myReg.ModifiedDate = DateTime.Now;
        result = myReg.Update();

        //Update Data Rawat Inap
        SIMRS.DataAccess.RS_RawatInap myRI = new SIMRS.DataAccess.RS_RawatInap();
        myRI.RawatInapId = Int64.Parse(HFRawatInapId.Value);
        myRI.SelectOne();
        myRI.RegistrasiId = myReg.RegistrasiId;
        myRI.RegistrasiId = myReg.RegistrasiId;

        myRI.TanggalMasuk = myReg.TanggalRegistrasi;
        myRI.AsalPasien = int.Parse(lblAsalPasien.Text);
        if (lblAsalPasien.Text == "1")
        {
            myRI.DariPoliklinikId = int.Parse(lblDariPoliklinikId.Text);
            if (lblDariDokterId.Text !="")
                myRI.DariDokterId = int.Parse(lblDariDokterId.Text);
            else
                myRI.DariDokterId = SqlInt32.Null;
        }
        else
        {
            myRI.DariRujukan = txtDariRujukan.Text;
        }
        if (cmbDokter.SelectedIndex > 0)
            myRI.DokterId = int.Parse(cmbDokter.SelectedItem.Value);
        else
            myRI.DokterId = SqlInt32.Null;
        myRI.DiagnosaMasuk = txtDiagnosaMasuk.Text;
        //if (txtDeposit.Text != "")
        //    myRI.Deposit = decimal.Parse(txtDeposit.Text);

        myRI.ModifiedBy = UserId;
        myRI.ModifiedDate = DateTime.Now;
        result = myRI.Update();

        //Update Data Tempat Inap
        //SIMRS.DataAccess.RS_TempatInap myTempat = new SIMRS.DataAccess.RS_TempatInap();
        //myTempat.TempatInapId = Int64.Parse(HFTempatInapId.Value);
        //myTempat.SelectOne();
        //myTempat.RawatInapId = myRI.RawatInapId;
        //myTempat.RuangRawatId = int.Parse(cmbNomorRuang.SelectedItem.Value);
        //if (cmbNomorTempat.SelectedIndex > 0)
        //    myTempat.TempatTidurId = int.Parse(cmbNomorTempat.SelectedItem.Value);
        //else
        //    myTempat.TempatTidurId = SqlInt32.Null;
        //myTempat.TanggalMasuk = myReg.TanggalRegistrasi;
        //myTempat.ModifiedBy = UserId;
        //myTempat.ModifiedDate = DateTime.Now;
        //myTempat.Update();

        return result;
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("RIView.aspx?CurrentPage=" + CurrentPage + "&RawatInapId=" + HFRawatInapId.Value);
    }
    public void OnCancel()
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("RIView.aspx?CurrentPage=" + CurrentPage + "&RawatInapId=" + HFRawatInapId.Value);
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
    protected void txtTanggalMasuk_TextChanged(object sender, EventArgs e)
    {
        GetNomorRegistrasi();
    }

    //protected void txtDeposit_TextChanged(object sender, EventArgs e)
    //{
    //    if (REVDeposit.IsValid && txtDeposit.Text != "")
    //    {
    //        if (txtDeposit.Text != "0")
    //            txtDeposit.Text = (decimal.Parse(txtDeposit.Text)).ToString("#,###.###.###.###");
    //    }
    //}
    protected void cmbStatusPenjamin_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListPangkatPenjamin("");
    }

    //protected void cmbRuangRawat_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetListNomorTempat("");
    //}
   
    //protected void cmbKelas_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetListRuang("");
    //}
    //protected void cmbRuang_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetListNomorRuang("");
    //}
    //protected void cmbNomorRuang_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    GetListNomorTempat("");
    //}

    public void GetListSatuanKerjaPenjamin(string KesatuanPenjamin)
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
            cmbSatuanKerjaPenjamin.Items[i].Text = dr["NamaSatker"].ToString();
            cmbSatuanKerjaPenjamin.Items[i].Value = dr["IdSatuanKerja"].ToString();
            if (dr["NamaSatker"].ToString() == KesatuanPenjamin)
            {
                cmbSatuanKerjaPenjamin.SelectedIndex = i;
            }
            i++;

        }
    }

}
