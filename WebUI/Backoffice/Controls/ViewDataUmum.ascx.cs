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

public partial class Backoffice_Controls_ViewDataUmum : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void GetData(string PasienId)
    {
        HFPasienId.Value = PasienId;
        SIMRS.DataAccess.RS_Pasien myObj = new SIMRS.DataAccess.RS_Pasien();
        myObj.PasienId = Int64.Parse(PasienId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            lblNoRM.Text = row["NoRM"].ToString();
            lblNamaPasien.Text = row["Nama"].ToString();
            lblJenisKelamin.Text = row["JenisKelamin"].ToString();
            lblTempatLahir.Text = row["TempatLahir"].ToString() == "" ? "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" : row["TempatLahir"].ToString();
            lblTanggalLahir.Text = row["TanggalLahir"].ToString() != "" ? ((DateTime)row["TanggalLahir"]).ToString("dd MMMM yyyy") : "";
            lblAlamat.Text = row["Alamat"].ToString().Replace("\r\n", "<br />");
            lblTelepon.Text = row["Telepon"].ToString();
            lblAgama.Text = row["AgamaNama"].ToString();
            lblPendidikan.Text = row["PendidikanNama"].ToString();
            lblStatusPerkawinan.Text = row["StatusPerkawinanNama"].ToString();
            lblStatus.Text = row["StatusNama"].ToString();
            lblPangkat.Text = row["PangkatNama"].ToString();
            lblNRP.Text = row["NRP"].ToString();
            lblJabatan.Text = row["Jabatan"].ToString();
            lblKesatuan.Text = row["Kesatuan"].ToString();
            lblAlamatKesatuan.Text = row["AlamatKesatuan"].ToString().Replace("\r\n", "<br />");
            lblNoKTP.Text = row["NoKTP"].ToString();
            lblNoAskes.Text = row["NoAskes"].ToString();
            lblGolDarah.Text = row["GolDarah"].ToString();
            lblPekerjaan.Text = row["Pekerjaan"].ToString();
            lblAlamatKantor.Text = row["AlamatKantor"].ToString();
            lblTeleponKantor.Text = row["TeleponKantor"].ToString();
            lblKeterangan.Text = row["Keterangan"].ToString().Replace("\r\n","<br />");
        }
        else
        {
            EmptyForm();
        }
    }
    public void EmptyForm()
    {
        lblNamaPasien.Text = "";
        lblJenisKelamin.Text = "";
        lblTempatLahir.Text = "";
        lblTanggalLahir.Text = "";
        lblAlamat.Text = "";
        lblTelepon.Text = "";
        lblAgama.Text = "";
        lblPendidikan.Text = "";
        lblStatusPerkawinan.Text = "";
        lblStatus.Text = "";
        lblPangkat.Text = "";
        lblNRP.Text = "";
        lblJabatan.Text = "";
        lblKesatuan.Text = "";
        lblAlamatKesatuan.Text = "";
        lblNoKTP.Text = "";
        lblNoAskes.Text = "";
        lblGolDarah.Text = "";
        lblPekerjaan.Text = "";
        lblAlamatKantor.Text = "";
        lblTeleponKantor.Text = "";
        lblKeterangan.Text = "";
    }
}
