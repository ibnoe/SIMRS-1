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

public partial class Backoffice_Kasir_LABList : System.Web.UI.Page
{
    public int NoKe = 0;
    protected string dsReportSessionName = "dsListRegistrasiLAB";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtTanggalRegistrasi.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }

    #region Panel Search
    public void GetResultSearch()
    {
        DataSet ds = new DataSet();
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.PoliklinikId = 42;//LAB
        if (txtTanggalRegistrasi.Text != "")
            myObj.TanggalBerobat = DateTime.Parse(txtTanggalRegistrasi.Text);
        if (txtNoRMSearch.Text != "")
            myObj.NoRM = txtNoRMSearch.Text;
        if (txtNamaSearch.Text != "")
            myObj.Nama = txtNamaSearch.Text;
        if (txtNRP.Text != "")
            myObj.NRP = txtNRP.Text;
        //myObj.Status = 0;
        DataTable dt = myObj.SelectAllFilter();
        if (dt.Rows.Count == 1)
        {
            pnlGridView.Visible = false;
            GridViewPasien.SelectedIndex = -1;
            // Re-binds the grid 
            GridViewPasien.DataSource = null;
            GridViewPasien.DataBind();
            //=======
            pnlDataPasien.Visible = true;
            Response.Redirect("LABView.aspx?RawatJalanId=" + dt.Rows[0]["RawatJalanId"].ToString());
            //UCViewRekamMedisLAB.GetData(dt.Rows[0]["RawatJalanId"].ToString());
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
            //Response.Redirect("LABView.aspx?RawatJalanId=" + RawatJalanId);
            //UCViewRekamMedisLAB.GetData("0");
        }
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        GetResultSearch();
    }
    protected void GridViewPasien_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 RawatJalanId = (Int64)GridViewPasien.SelectedValue;
        pnlGridView.Visible = false;
        GridViewPasien.SelectedIndex = -1;
        // Re-binds the grid 
        GridViewPasien.DataSource = null;
        GridViewPasien.DataBind();
        //=======
        pnlDataPasien.Visible = true;
        Response.Redirect("LABView.aspx?RawatJalanId=" + RawatJalanId);
        //UCViewRekamMedisLAB.GetData(RawatJalanId.ToString());
    }
    protected void GridViewPasien_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewPasien.PageIndex = e.NewPageIndex;
        GridViewPasien.SelectedIndex = -1;
        GetResultSearch();
    }
    #endregion
}
