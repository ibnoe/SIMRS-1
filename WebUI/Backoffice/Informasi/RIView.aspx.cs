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

public partial class Backoffice_Informasi_RIView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["RawatInapId"] != null && Request["RawatInapId"].ToString() != "")
            {
                GetDataPasien(Request["RawatInapId"].ToString());
            }
        }
    }
    public void GetDataPasien(string RawatInapId)
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = Int64.Parse(RawatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            HFRawatInapId.Value = row["RawatInapId"].ToString();
            HFPasienId.Value = row["PasienId"].ToString();
            HFStatusRawatInap.Value = row["StatusRawatInap"].ToString();
            HFRegistrasiId.Value = row["RegistrasiId"].ToString();

            HeaderRI1.GetData(HFRawatInapId.Value);

            UCViewDataUmum.GetData(HFPasienId.Value);
            UCViewRegistrasiRI.GetData(HFRawatInapId.Value);
            UCViewRekamMedisRI.GetData(HFRegistrasiId.Value);
            UCViewRuangRI.SetDataRawatInap(HFRawatInapId.Value);
            UCViewRuangRI.BindDataGrid();
            UCViewKasirRI.SetDataRawatInap(row["RawatInapId"].ToString(), row["KelasId"].ToString());
            UCViewKasirRI.BindDataGrid();
            UCViewDepositRI.SetDataRawatInap(row["RawatInapId"].ToString(), row["KelasId"].ToString(), row["Nama"].ToString());
            UCViewDepositRI.BindDataGrid();
            UCViewKuitansiRI.SetDataRawatInap(row["RawatInapId"].ToString(), row["KelasId"].ToString());
            UCViewKuitansiRI.BindDataGrid();
            
        }
        else
        {
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Informasi/RIList.aspx");
    }
}
