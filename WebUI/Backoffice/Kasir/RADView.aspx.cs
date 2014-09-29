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

public partial class Backoffice_Kasir_RADView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["RawatJalanId"] != null && Request["RawatJalanId"].ToString() != "")
            {
                GetDataPasien(Request["RawatJalanId"].ToString());
            }
        }
    }
    public void GetDataPasien(string RawatJalanId)
    {
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.RawatJalanId = Int64.Parse(RawatJalanId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            HFRawatJalanId.Value = row["RawatJalanId"].ToString();
            HFPasienId.Value = row["PasienId"].ToString();
            HFStatusRawatJalan.Value = row["StatusRawatJalan"].ToString();
            HFRegistrasiId.Value = row["RegistrasiId"].ToString();

            HeaderRJ1.GetData(HFRawatJalanId.Value);

            UCViewDataUmum.GetData(HFPasienId.Value);
            UCViewRegistrasiRAD.GetData(HFRawatJalanId.Value);
            UCViewRekamMedisRAD.GetData(HFRegistrasiId.Value);
            string KelasId = "0";
            if (row["AsalPasienId"].ToString() != "")
            {
                int AsalPasienId = 0;
                AsalPasienId = int.Parse(row["AsalPasienId"].ToString());
                SIMRS.DataAccess.RS_Registrasi myReg = new SIMRS.DataAccess.RS_Registrasi();
                myReg.RegistrasiId = AsalPasienId;
                DataTable dtReg = myReg.SelectAsalPasien();
                if (dtReg.Rows.Count > 0)
                {
                    DataRow drReg = dtReg.Rows[0];
                    if (drReg["JenisRegistrasiId"].ToString() == "2")
                    {
                        KelasId = drReg["KelasId"].ToString();
                    }
                }
            }
            UCEditKasirRAD.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString(), KelasId);
            UCEditKasirRAD.BindDataGrid();
            UCEditKuitansiRAD.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCEditKuitansiRAD.BindDataGrid();
            
        }
        else
        {
        }
    }

    protected void btnEditDataPasien_Click(object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Registrasi/RADEditPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + HFPasienId.Value + "&RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void btnAddRekamMedis_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/RekamMedis/RADAddRekamMedis.aspx?RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void btnEditRekamMedis_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/RekamMedis/RADEditRekamMedis.aspx?RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Kasir/RADList.aspx");
    }
}
