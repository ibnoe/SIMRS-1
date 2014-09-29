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

public partial class Backoffice_Controls_HeaderRJ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void GetData(string RawatJalanId)
    {
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.RawatJalanId = Int64.Parse(RawatJalanId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            lblNoRMHeader.Text = row["NoRM"].ToString();
            lblNamaPasienHeader.Text = row["Nama"].ToString();
            lblUmurPasienHeader.Text = row["Umur"].ToString()!="" ? " / "+ row["Umur"].ToString():"";
            lblStatusPasienHeader.Text = row["StatusNama"].ToString();
            lblPangkatPasienHeader.Text = row["PangkatNama"].ToString();
            
            lblPoliklinikHeader.Text = row["PoliklinikNama"].ToString();
            lblDokterHeader.Text = row["DokterNama"].ToString();
            lblTanggalBerobatHeader.Text = ((DateTime)row["TanggalBerobat"]).ToString("dd MMMM yyyy");
            lblJamPraktekHeader.Text = row["JamPraktek"].ToString();
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
