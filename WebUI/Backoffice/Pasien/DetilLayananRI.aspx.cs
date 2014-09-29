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

public partial class Backoffice_Pasien_DetilLayananRI : System.Web.UI.Page
{
    private ReportDocument rd;
    private string rdName = "rdDetilLayananRI";
    private string dsName = "dsDetilLayananRI";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RawatInapId"] != null && Request.QueryString["RawatInapId"].ToString() != "" && Request.QueryString["TempatInapId"] != null && Request.QueryString["TempatInapId"].ToString() != "")
        {
            DataSet ds = new DataSet();
            if (!Page.IsPostBack)
            {
                ds = GetData(Request.QueryString["RawatInapId"].ToString(), Request.QueryString["TempatInapId"].ToString());
            }
            else
            {
                if (Session[dsName] == null)
                {
                    ds = GetData(Request.QueryString["RawatInapId"].ToString(), Request.QueryString["TempatInapId"].ToString());
                }
                else
                {
                    ds = (DataSet)Session[dsName];
                }
            }
            rd = new ReportDocument();
            rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/PrintDetilTagihanRI.rpt");
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
    private DataSet GetData(string RawatInapId, string TempatInapId)
    {
        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = int.Parse(RawatInapId);
        DataTable dtRawatInap = myObj.SelectOne();
        ds.Tables.Add(dtRawatInap);
        ds.Tables[0].TableName = "V_RawatInap";

        SIMRS.DataAccess.RS_RILayanan myObjLayanan = new SIMRS.DataAccess.RS_RILayanan();
        myObjLayanan.RawatInapId = int.Parse(RawatInapId);
        myObjLayanan.TempatInapId = int.Parse(TempatInapId);
        DataTable dt = myObjLayanan.SelectAllWRawatInapIdAndTempatInapId();
        ds.Tables.Add(dt);
        ds.Tables[1].TableName = "V_RILayanan";

        
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
