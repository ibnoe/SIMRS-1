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

public partial class Backoffice_Controls_KuitansiRJSum : System.Web.UI.UserControl
{
    private ReportDocument rd;
    private string rdName = "rdKuitansiRJSum";
    private string dsName = "dsKuitansiRJSum";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["RawatJalanId"] != null && Request.QueryString["RawatJalanId"].ToString() != "")
            {
                DataSet ds = new DataSet();
                if (!Page.IsPostBack)
                {
                    ds = GetData(Request.QueryString["RawatJalanId"].ToString());
                }
                else
                {
                    if (Session[dsName] == null)
                    {
                        ds = GetData(Request.QueryString["RawatJalanId"].ToString());
                    }
                    else
                    {
                        ds = (DataSet)Session[dsName];
                    }
                }
                rd = new ReportDocument();
                rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/KuitansiRJSum.rpt");
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
    }
    private DataSet GetData(string RawatJalanId)
    {
        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_RJLayanan myObj = new SIMRS.DataAccess.RS_RJLayanan();
        myObj.RawatJalanId = int.Parse(RawatJalanId);
        DataTable dt = myObj.SelectAllWRawatJalanIdLogic();
        ds.Tables.Add(dt);
        ds.Tables[0].TableName = "V_RJLayanan";
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
