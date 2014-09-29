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

public partial class Backoffice_RekamMedis_RIList : System.Web.UI.Page
{
    public int NoKe = 0;
    protected string dsReportSessionName = "dsListRegistrasiRI";

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    #region Panel Search
    public void GetResultSearch()
    {
        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        int KelasId = 0;
        int RuangId = 0;
        string NomorRuang = "";
        if (txtNoRMSearch.Text != "")
            myObj.NoRM = txtNoRMSearch.Text;
        if (txtNamaSearch.Text != "")
            myObj.Nama = txtNamaSearch.Text;
        if (txtNRP.Text != "")
            myObj.NRP = txtNRP.Text;
        //myObj.Status = 0;
        DataTable dt = myObj.SelectAllForRekamMedis(KelasId, RuangId, NomorRuang);
        if (dt.Rows.Count == 1)
        {
            pnlGridView.Visible = false;
            GridViewPasien.SelectedIndex = -1;
            // Re-binds the grid 
            GridViewPasien.DataSource = null;
            GridViewPasien.DataBind();
            //=======
            pnlDataPasien.Visible = true;
            Response.Redirect("RIView.aspx?RawatInapId=" + dt.Rows[0]["RawatInapId"].ToString());
            //UCViewRekamMedisRI.GetData(dt.Rows[0]["RawatInapId"].ToString());
        }
        else
        {
            pnlGridView.Visible = true;
            DataView dv = dt.DefaultView;
            GridViewPasien.SelectedIndex = -1;
            // Re-binds the grid 
            GridViewPasien.DataSource = dv;
            GridViewPasien.DataBind();
            //========
            pnlDataPasien.Visible = false;
            //Response.Redirect("RIView.aspx?RawatInapId=" + RawatInapId);
            //UCViewRekamMedisRI.GetData("0");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetResultSearch();
    }
    protected void GridViewPasien_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 RawatInapId = (Int64)GridViewPasien.SelectedValue;
        pnlGridView.Visible = false;
        GridViewPasien.SelectedIndex = -1;
        // Re-binds the grid 
        GridViewPasien.DataSource = null;
        GridViewPasien.DataBind();
        //=======
        pnlDataPasien.Visible = true;
        Response.Redirect("RIView.aspx?RawatInapId=" + RawatInapId);
        //UCViewRekamMedisRI.GetData(RawatInapId.ToString());
    }
    protected void GridViewPasien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
    }
    #endregion
}
