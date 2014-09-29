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

public partial class Backoffice_Controls_HeaderRI : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void GetData(string RawatInapId)
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = Int64.Parse(RawatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            lblNoRMHeader.Text = row["NoRM"].ToString();
            lblNamaPasienHeader.Text = row["Nama"].ToString();
            lblUmurPasienHeader.Text = row["Umur"].ToString() != "" ? " / " + row["Umur"].ToString() : "";
            lblStatusPasienHeader.Text = row["StatusNama"].ToString();
            lblPangkatPasienHeader.Text = row["PangkatNama"].ToString();

            lblRuangRawatHeader.Text = row["KelasNama"].ToString() + " - " + row["RuangNama"].ToString() + " - " + row["NomorRuang"].ToString();
            lblDokterHeader.Text = row["DokterNama"].ToString();
            lblTanggalMasukHeader.Text = ((DateTime)row["TanggalMasuk"]).ToString("dd MMMM yyyy HH:mm");
            lblTanggalKeluarHeader.Text = row["TanggalKeluarInap"].ToString() != "" ? ((DateTime)row["TanggalKeluarInap"]).ToString("dd MMMM yyyy HH:mm") : "";
            //lblJamMasukHeader.Text = ((DateTime)row["TanggalMasuk"]).ToString("HH:mm");
            //=======
            lblJenisPenanggungNamaHeader.Text = row["JenisPenjaminNama"].ToString();
            lblNamaPenanggungHeader.Text = row["NamaPenjamin"].ToString();
            lblStatusPenenaggungHeader.Text = row["StatusNamaPenjamin"].ToString();
            lblPangkatPenanggungHeader.Text = row["PangkatNamaPenjamin"].ToString();
            
        }
        else
        {

        }
    }
}
