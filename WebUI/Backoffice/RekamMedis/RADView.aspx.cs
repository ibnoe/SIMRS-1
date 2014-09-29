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

public partial class Backoffice_RekamMedis_RADView : System.Web.UI.Page
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
            
            btnIkhtisarKunjungan.Visible = true;
            btnIkhtisarKunjungan.Attributes.Remove("onclick");
            btnIkhtisarKunjungan.Attributes.Add("onclick", "displayPopup_scroll(2,'../Pasien/IkhtisarKunjungan.aspx?RawatJalanId=" + RawatJalanId + "','IdentitasPasien',600,800,(version4 ? event : null));");
            btnLembarKonsultasi.Visible = true;
            btnLembarKonsultasi.Attributes.Remove("onclick");
            btnLembarKonsultasi.Attributes.Add("onclick", "displayPopup_scroll(2,'../Pasien/LembarKonsultasi.aspx?RawatJalanId=" + RawatJalanId + "','IdentitasPasien',600,800,(version4 ? event : null));");

            btnPrintRM.Visible = true;
            btnPrintRM.Attributes.Remove("onclick");
            btnPrintRM.Attributes.Add("onclick", "displayPopup_scroll(2,'../Pasien/RM_RAD.aspx?RegistrasiId=" + HFRegistrasiId.Value + "','RekamMedis',600,800,(version4 ? event : null));");

            SIMRS.DataAccess.RS_RM myRM = new SIMRS.DataAccess.RS_RM();
            myRM.RegistrasiId = int.Parse(HFRegistrasiId.Value);
            DataTable dtRM = myRM.SelectOne();
            if (dtRM.Rows.Count > 0 )
            {
                btnAddRekamMedis.Visible = false;
                btnEditRekamMedis.Visible = true;
            }
            else
            {
                btnAddRekamMedis.Visible = true;
                btnEditRekamMedis.Visible = false;
            }

            HeaderRJ1.GetData(HFRawatJalanId.Value);

            UCViewDataUmum.GetData(HFPasienId.Value);
            UCViewRegistrasiRAD.GetData(HFRawatJalanId.Value);
            UCViewRekamMedisRAD.GetData(HFRegistrasiId.Value);
            UCViewKasirRAD.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCViewKasirRAD.BindDataGrid();
            UCViewKuitansiRAD.SetDataRawatJalan(row["RawatJalanId"].ToString(), row["PoliklinikId"].ToString());
            UCViewKuitansiRAD.BindDataGrid();
            
        }
        else
        {
            btnIkhtisarKunjungan.Visible = false;
            btnIkhtisarKunjungan.Attributes.Remove("onclick");
            btnLembarKonsultasi.Visible = false;
            btnLembarKonsultasi.Attributes.Remove("onclick");

            btnPrintRM.Visible = false;
            btnPrintRM.Attributes.Remove("onclick");
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
        Response.Redirect(Request.ApplicationPath + "/Backoffice/RekamMedis/RADList.aspx");
    }
}
