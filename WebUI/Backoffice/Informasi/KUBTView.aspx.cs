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

public partial class Backoffice_Informasi_KUBTView : System.Web.UI.Page
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
            
            btnIdentitasPasien.Visible = true;
            btnIdentitasPasien.Attributes.Remove("onclick");
            btnIdentitasPasien.Attributes.Add("onclick", "displayPopup_scroll(2,'../Pasien/IdentitasPasien.aspx?RegistrasiId=" + HFRegistrasiId.Value + "','IdentitasPasien',600,800,(version4 ? event : null));");

            HeaderRJ1.GetData(HFRawatJalanId.Value);

            UCViewDataUmum.GetData(HFPasienId.Value);
            UCViewRegistrasiKUBT.GetData(HFRawatJalanId.Value);
            UCViewRekamMedisKUBT.GetData(HFRegistrasiId.Value);
            UCViewKasirKUBT.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCViewKasirKUBT.BindDataGrid();
            UCViewKuitansiKUBT.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCViewKuitansiKUBT.BindDataGrid();
        }
        else
        {

            btnIdentitasPasien.Visible = false;
            btnIdentitasPasien.Attributes.Remove("onclick");
            
        }
    }

    protected void btnEditDataPasien_Click(object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("KUBTEditPasien.aspx?CurrentPage=" + CurrentPage + "&PasienId=" + HFPasienId.Value + "&RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void btnEditRegistrasiKUBT_Click(object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("KUBTEditRegistrasi.aspx?CurrentPage=" + CurrentPage + "&RawatJalanId=" + HFRawatJalanId.Value);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect(Request.ApplicationPath + "/Backoffice/Registrasi/KUBTList.aspx");
    }
}
