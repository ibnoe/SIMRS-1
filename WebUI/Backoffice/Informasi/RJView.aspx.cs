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

public partial class Backoffice_Informasi_RJView : System.Web.UI.Page
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
            UCViewRegistrasiRJ.GetData(HFRawatJalanId.Value);
            UCViewRekamMedisRJ.GetData(HFRegistrasiId.Value);
            UCViewKasirRJ.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCViewKasirRJ.BindDataGrid();
            UCViewKuitansiRJ.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCViewKuitansiRJ.BindDataGrid();
            
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
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Registrasi/RJEditPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + HFPasienId.Value + "&RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void btnAddRekamMedis_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/RekamMedis/RJAddRekamMedis.aspx?RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void btnEditRekamMedis_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/RekamMedis/RJEditRekamMedis.aspx?RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Informasi/RJList.aspx");
    }
}
