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

public partial class Backoffice_Pasien_KuitansiRJ : System.Web.UI.Page
{
    private ReportDocument rd;
    private string rdName = "rdKuitansiRJ";
    private string dsName = "dsKuitansiRJ";
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
            rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/PrintKuitansiRJ.rpt");
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
        SIMRS.DataAccess.RS_RJKuitansi myObj = new SIMRS.DataAccess.RS_RJKuitansi();
        myObj.KuitansiId = int.Parse(KuitansiId);
        DataTable dt = myObj.SelectOne();
        ds.Tables.Add(dt);
        ds.Tables[0].TableName = "V_RJKuitansi";

        SIMRS.DataAccess.RS_RJKuitansiLayanan myObjLayanan = new SIMRS.DataAccess.RS_RJKuitansiLayanan();
        myObjLayanan.KuitansiId = int.Parse(KuitansiId);
        DataTable dtLayanan = myObjLayanan.SelectAllWKuitansiIdLogic();
        ds.Tables.Add(dtLayanan);
        ds.Tables[1].TableName = "V_RJKuitansiLayanan";
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
