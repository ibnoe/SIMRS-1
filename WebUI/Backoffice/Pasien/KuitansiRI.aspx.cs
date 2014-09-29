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
using CrystalDecisions.CrystalReports.Engine;

public partial class Backoffice_Pasien_KuitansiRI : System.Web.UI.Page
{
    private ReportDocument rd;
    private string rdName = "rdKuitansiRI";
    private string dsName = "dsKuitansiRI";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["KuitansiId"] != null && Request.QueryString["KuitansiId"].ToString() != "")
        {
            DataSet ds = new DataSet();
            if (!Page.IsPostBack)
            {
                ds = GetData(Request.QueryString["KuitansiId"].ToString());
            }
            else
            {
                if (Session[dsName] == null)
                {
                    ds = GetData(Request.QueryString["KuitansiId"].ToString());
                }
                else
                {
                    ds = (DataSet)Session[dsName];
                }
            }
            rd = new ReportDocument();
            string JenisKuitansiId = "0";
            if (ds.Tables[0].Rows.Count > 0)
            {
                JenisKuitansiId = ds.Tables[0].Rows[0]["JenisKuitansiId"].ToString();
            }
            if (JenisKuitansiId == "0")
                rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/PrintKuitansiRI.rpt");
            else
                rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/PrintKuitansiDepositRI.rpt");
            rd.SetDataSource(ds);
            Session.Add(rdName, rd);
            if (ConfigurationManager.AppSettings["Main.PrintMode"].ToString() == "ActiveX")
                CRVPasien.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
            else
                CRVPasien.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
            CRVPasien.ReportSource = rd;
            CRVPasien.DataBind();
        }

    }
    private DataSet GetData(string KuitansiId)
    {
        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        myObj.KuitansiId = int.Parse(KuitansiId);
        DataTable dt = myObj.SelectOne();
        ds.Tables.Add(dt);
        ds.Tables[0].TableName = "V_RIKuitansi";

        if (dt.Rows.Count > 0)
        {
            if (dt.Rows[0]["JenisKuitansiId"].ToString() != "1")
            {
                SIMRS.DataAccess.RS_RIKuitansiLayanan myObjLayanan = new SIMRS.DataAccess.RS_RIKuitansiLayanan();
                myObjLayanan.KuitansiId = int.Parse(KuitansiId);
                DataTable dtRuang = myObjLayanan.GetDetilRuangRawat();
                ds.Tables.Add(dtRuang);
                ds.Tables[1].TableName = "V_RIBiayaRuangRawat";

                DataTable dtNonRuang = myObjLayanan.GetDetilNonRuangRawat();
                ds.Tables.Add(dtNonRuang);
                ds.Tables[2].TableName = "V_RIBiayaNonRuangRawat";
            }
        }
        
        Session.Add(dsName, ds);
        return ds;
    }
    public void Page_Unload(object sender, EventArgs e)
    {
        if (Session[rdName] != null)
        {
            rd = (ReportDocument)Session[rdName];
            rd.Close();
            rd.Dispose();
        }
    }
}
