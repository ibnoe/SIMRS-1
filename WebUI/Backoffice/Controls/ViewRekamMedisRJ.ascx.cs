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

public partial class Backoffice_Controls_ViewRekamMedisRJ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void GetData(string RegistrasiId)
    {
        SIMRS.DataAccess.RS_RM myObj = new SIMRS.DataAccess.RS_RM();
        myObj.RegistrasiId = Int64.Parse(RegistrasiId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            lblTanggalPeriksa.Text = ((DateTime)row["TanggalPeriksa"]).ToString("dd MMMM yyyy");
            lblJamPeriksa.Text = row["JamPeriksa"].ToString();
            lblKeluhanUtama.Text = row["KeluhanUtama"].ToString().Replace("\r\n", "<br />");
            lblDiagnosa.Text = row["Diagnosa"].ToString().Replace("\r\n", "<br />");
            lblTindakanMedis.Text = row["TindakanMedis"].ToString().Replace("\r\n", "<br />");
            lblObat.Text = row["Obat"].ToString().Replace("\r\n", "<br />");
            lblKeteranganLain.Text = row["Keterangan"].ToString().Replace("\r\n", "<br />");
            SIMRS.DataAccess.RS_RMJenisPenyakit myPenyakit = new SIMRS.DataAccess.RS_RMJenisPenyakit();
            myPenyakit.RegistrasiId = Int64.Parse(RegistrasiId);
            DataTable dtPenyakit = myPenyakit.SelectAllWRegistrasiIdLogic();
            if (dtPenyakit.Rows.Count > 0)
            {
                foreach (DataRow dr in dtPenyakit.Rows)
                {
                    lblJenisPenyakit.Text += lblJenisPenyakit.Text != "" ? "<br />" + dr["JenisPenyakitNama"].ToString() : dr["JenisPenyakitNama"].ToString();
                }
            }
        }
        else
        {
            EmptyForm(); 
        }
    }
    private void EmptyForm()
    {
        lblTanggalPeriksa.Text = "";
        lblJamPeriksa.Text = "";
        lblKeluhanUtama.Text = "";
        lblDiagnosa.Text = "";
        lblTindakanMedis.Text = "";
        lblObat.Text = "";
        lblKeteranganLain.Text = "";
        lblJenisPenyakit.Text = "";
    }

}
