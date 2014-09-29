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

public partial class Backoffice_Pasien_IdentitasPasien : System.Web.UI.Page
{
    private ReportDocument rd;
    private string rdName = "rdIdentitasPasien";
    private string dsName = "dsIdentitasPasien";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RegistrasiId"] != null && Request.QueryString["RegistrasiId"].ToString() != "")
        {
            DataSet ds = new DataSet();
            if (!Page.IsPostBack)
            {
                ds = GetData(Request.QueryString["RegistrasiId"].ToString());
            }
            else
            {
                if (Session[dsName] == null)
                {
                    ds = GetData(Request.QueryString["RegistrasiId"].ToString());
                }
                else
                {
                    ds = (DataSet)Session[dsName];
                }
            }
            rd = new ReportDocument();
            rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/IdentitasPasien.rpt");
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
    private DataSet GetData(string RegistrasiId)
    {
        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_Registrasi myObj = new SIMRS.DataAccess.RS_Registrasi();
        myObj.RegistrasiId = int.Parse(RegistrasiId);
        DataTable dt = myObj.SelectOne();
        ds.Tables.Add(dt);
        ds.Tables[0].TableName = "V_Registrasi";
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
