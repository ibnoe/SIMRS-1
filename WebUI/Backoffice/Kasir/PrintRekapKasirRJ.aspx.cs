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

public partial class Backoffice_Pasien_PrintRekapKasirRJ : System.Web.UI.Page
{
    private ReportDocument rd;
    private string rdName = "rdPrintRekapKasirRJ";
    private string dsName = "dsPrintRekapKasirRJ";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetQueryString();
            if (txtTanggalMulai.Text == "" || txtTanggalSelesai.Text == "" || txtModeRekap.Text == "")
            {
                Response.Redirect(Request.ApplicationPath + "/error.aspx");
            }
        }
        DataSet ds = new DataSet();
        if (!Page.IsPostBack)
        {
            ds = GetData();
        }
        else
        {
            if (Session[dsName] == null)
            {
                ds = GetData();
            }
            else
            {
                ds = (DataSet)Session[dsName];
            }
        }
        rd = new ReportDocument();
        if(txtModeRekap.Text == "1")
            rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/RekapRJA.rpt");
        else if (txtModeRekap.Text == "2")
            rd.Load(ConfigurationManager.AppSettings["Main.Path"].ToString() + "Backoffice/Report/RekapRJB.rpt");
        rd.SetDataSource(ds);
        //==============
        string TitlePeriode = txtTanggalMulai.Text;
        if (txtTanggalSelesai.Text != txtTanggalMulai.Text)
        {
            TitlePeriode += " s/d " + txtTanggalSelesai.Text; 
        }
        string NamaPoliklinik = "";
        if (txtModeRekap.Text == "2")
        {
            if (txtPoliklinikId.Text != "")
            {
                SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
                myObj.Id = int.Parse(txtPoliklinikId.Text);
                myObj.SelectOne();
                NamaPoliklinik = myObj.Nama.ToString();
            }
            else
            {
                NamaPoliklinik = "Semua Poliklinik";
            }
        }        
        //string Poliklinik = txtPoliklinikId.Text;
        
        ReportObjects crReportObjects;
        CrystalDecisions.CrystalReports.Engine.TextObject reportObject;
        crReportObjects = rd.ReportDefinition.ReportObjects;
        foreach (ReportObject crReportObject in crReportObjects)
        {
            reportObject = (rd.ReportDefinition.ReportObjects[crReportObject.Name] as CrystalDecisions.CrystalReports.Engine.TextObject);
            if (crReportObject.Name == "txtTanggal")
            {
                reportObject.Text = TitlePeriode;
            }
            if (txtModeRekap.Text == "2")
            {
                if (crReportObject.Name == "txtPoliklinik")
                {
                    reportObject.Text = NamaPoliklinik;
                }
            }
        }
        //==============
        Session.Add(rdName, rd);
        if (ConfigurationManager.AppSettings["Main.PrintMode"].ToString() == "ActiveX")
            CRVPasien.PrintMode = CrystalDecisions.Web.PrintMode.ActiveX;
        else
            CRVPasien.PrintMode = CrystalDecisions.Web.PrintMode.Pdf;
        CRVPasien.ReportSource = rd;
        CRVPasien.DataBind();
        

    }
    private void GetQueryString()
    {
        string TanggalMulai = "";
        if (Request.QueryString["TanggalMulai"] != null && Request.QueryString["TanggalMulai"].ToString() != "")
        {
            TanggalMulai = Request.QueryString["TanggalMulai"].ToString();
            TanggalMulai = TanggalMulai.Substring(0, 2) + "/" + TanggalMulai.Substring(2, 2) + "/" + TanggalMulai.Substring(4, 4);
        }
        txtTanggalMulai.Text = TanggalMulai;
        
        string TanggalSelesai = "";
        if (Request.QueryString["TanggalSelesai"] != null && Request.QueryString["TanggalSelesai"].ToString() != "")
        {
            TanggalSelesai = Request.QueryString["TanggalSelesai"].ToString();
            TanggalSelesai = TanggalSelesai.Substring(0, 2) + "/" + TanggalSelesai.Substring(2, 2) + "/" + TanggalSelesai.Substring(4, 4);
        }
        txtTanggalSelesai.Text = TanggalSelesai;
        
        string ModeRekap = "";
        if (Request.QueryString["ModeRekap"] != null && Request.QueryString["ModeRekap"].ToString() != "")
        {
            ModeRekap = Request.QueryString["ModeRekap"].ToString();
            string PoliklinikId = "";
            if (Request.QueryString["PoliklinikId"] != null && Request.QueryString["PoliklinikId"].ToString() != "")
            {
                PoliklinikId = Request.QueryString["PoliklinikId"].ToString();
            }
            txtPoliklinikId.Text = PoliklinikId;
        }
        txtModeRekap.Text = ModeRekap;

        string UserId = "";
        if (Request.QueryString["UserId"] != null && Request.QueryString["UserId"].ToString() != "")
        {
            UserId = Request.QueryString["UserId"].ToString();
        }
        txtUserId.Text = UserId;
        if (UserId == "")
            txtUserId.Text = "0";
    }

    private DataSet GetData()
    {
        DateTime TanggalMulai = DateTime.Parse(txtTanggalMulai.Text);
        DateTime TanggalSelesai = DateTime.Parse(txtTanggalSelesai.Text);
        int ModeRekap = int.Parse(txtModeRekap.Text);
        int PoliklinikId = txtPoliklinikId.Text != "" ? int.Parse(txtPoliklinikId.Text) : 0;
        int UserId = int.Parse(txtUserId.Text);

        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_RJKuitansi myObj = new SIMRS.DataAccess.RS_RJKuitansi();
        DataTable dt = myObj.ReportRekapKasirRJ(TanggalMulai, TanggalSelesai, ModeRekap, PoliklinikId,UserId);
        ds.Tables.Add(dt);
        ds.Tables[0].TableName = "V_RJKuitansi";
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
