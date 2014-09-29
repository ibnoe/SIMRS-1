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

public partial class Backoffice_Controls_ViewRegistrasiLAB : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void GetData(string RawatJalanId)
    {
        HFRawatJalanId.Value = RawatJalanId;
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.RawatJalanId = Int64.Parse(RawatJalanId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            //Data Registrasi
            lblNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            lblTanggalBerobat.Text = row["TanggalBerobat"].ToString() != "" ? ((DateTime)row["TanggalBerobat"]).ToString("dd MMMM yyyy") : "";
            lblPoliklinik.Text = row["PoliklinikNama"].ToString();
            lblNoTunggu.Text = row["NomorTunggu"].ToString();
            lblKeterangan.Text = row["Keterangan"].ToString();
            lblJenisPenjaminNama.Text = row["JenisPenjaminNama"].ToString();
            string JenisPenjaminId = row["JenisPenjaminId"].ToString();

            if (JenisPenjaminId == "2")
            {
                tblPenjaminKeluargaView.Visible = true;
                tblPenjaminPerusahaanView.Visible = false;

                //Data Keluarga Penjamin
                lblNamaPenjamin.Text = row["NamaPenjamin"].ToString();
                lblHubunganNama.Text = row["HubunganNama"].ToString();
                lblUmur.Text = row["UmurPenjamin"].ToString();
                lblAlamatPenjamin.Text = row["AlamatPenjamin"].ToString();
                lblTeleponPenjamin.Text = row["TeleponPenjamin"].ToString();
                lblAgamaPenjamin.Text = row["AgamaNamaPenjamin"].ToString();
                lblPendidikanPenjamin.Text = row["PendidikanNamaPenjamin"].ToString();
                lblStatusPenjaminNama.Text = row["StatusNamaPenjamin"].ToString();
                lblPangkatPenjaminNama.Text = row["PangkatNamaPenjamin"].ToString();
                lblNRPPenjamin.Text = row["NRPPenjamin"].ToString();
                lblJabatan.Text = row["JabatanPenjamin"].ToString();
                lblKesatuanPenjamin.Text = row["KesatuanPenjamin"].ToString();
                lblAlamatKesatuan.Text = row["AlamatKesatuanPenjamin"].ToString();
                lblNoKTPPenjamin.Text = row["NoKTPPenjamin"].ToString();
                lblGolDarahPenjamin.Text = row["GolDarahPenjamin"].ToString();
                lblKeteranganPenjamin.Text = row["KeteranganPenjamin"].ToString();
            }
            else if (JenisPenjaminId == "3" || JenisPenjaminId == "4")
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
        }
        else
        {
            EmptyData();
        }
    }
    public void EmptyData()
    {
        //Data Registrasi
        lblNoRegistrasi.Text = "";
        lblTanggalBerobat.Text = "";
        lblPoliklinik.Text = "";
        lblNoTunggu.Text = "";
        lblJenisPenjaminNama.Text = "";

        //Data Keluarga Penjamin
        lblNamaPenjamin.Text = "";
        lblHubunganNama.Text = "";
        lblUmur.Text = "";
        lblAlamatPenjamin.Text = "";
        lblTeleponPenjamin.Text = "";
        lblAgamaPenjamin.Text = "";
        lblPendidikanPenjamin.Text = "";
        lblStatusPenjaminNama.Text = "";
        lblPangkatPenjaminNama.Text = "";
        lblNRPPenjamin.Text = "";
        lblJabatan.Text = "";
        lblKesatuanPenjamin.Text = "";
        lblAlamatKesatuan.Text = "";
        lblNoKTPPenjamin.Text = "";
        lblGolDarahPenjamin.Text = "";
        lblKeteranganPenjamin.Text = "";
        //Data Perusahaan Penjamin
        lblNamaPerusahan.Text = "";
        lblNamaKontak.Text = "";
        lblAlamatPerusahaan.Text = "";
        lblTeleponPerusahaan.Text = "";
        lblFaxPerusahaan.Text = "";
        lblKeteranganPerusahaan.Text = "";

        tblPenjaminKeluargaView.Visible = false;
        tblPenjaminPerusahaanView.Visible = false;
    }
}
