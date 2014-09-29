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
using System.Data.SqlTypes;

public partial class Backoffice_Controls_ViewKasirLAB : System.Web.UI.UserControl
{
    public int NoKe = 0;
    public decimal TotalTagihan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void ModeEditForm()
    {
        pnlList.Visible = false;
        pnlView.Visible = false;
        lblWarning.Text = "";
    }
    private void ModeListForm()
    {
        pnlList.Visible = true;
        pnlView.Visible = false;
    }
    private void ModeViewForm()
    {
        lblWarning.Text = "";
        GV.EditIndex = -1;
        pnlList.Visible = false;
        pnlView.Visible = true;
    }

    protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GV.PageIndex = e.NewPageIndex;
        GV.SelectedIndex = -1;
        BindDataGrid();
    }

    protected void GV_Sorting(object sender, GridViewSortEventArgs e)
    {
        String strSortBy = GV.Attributes["SortField"];
        String strSortAscending = GV.Attributes["SortAscending"];

        // Sets the new sorting field
        GV.Attributes["SortField"] = e.SortExpression;

        // Sets the order (defaults to ascending). If you click on the
        // sorted column, the order reverts.
        GV.Attributes["SortAscending"] = "yes";
        if (e.SortExpression == strSortBy)
            GV.Attributes["SortAscending"] = (strSortAscending == "yes" ? "no" : "yes");

        // Refreshes the view
        GV.SelectedIndex = -1;
        BindDataGrid();
    }

    public void BindDataGrid()
    {
        DataView dv = GetData();
        dv.Sort = GV.Attributes["SortField"];
        if (GV.Attributes["SortAscending"] == "no")
            dv.Sort += " DESC";
        if (dv.Count > 0)
        {
            int intRowCount = dv.Count;
            int intPageSaze = GV.PageSize;
            int intPageCount = intRowCount / intPageSaze;
            if (intRowCount - (intPageCount * intPageSaze) > 0)
                intPageCount = intPageCount + 1;
            if (GV.PageIndex >= intPageCount)
                GV.PageIndex = intPageCount - 1;
            TotalTagihan = 0;
            bool statusBelumBayar = false;
            foreach (DataRow dr in dv.Table.Rows)
            {
                statusBelumBayar = dr["StatusBayar"].ToString() == "0" ? true : false;
                TotalTagihan += (decimal)dr["JumlahTagihan"];
            }
            
        }
        else
        {
            GV.PageIndex = 0;
        }
        NoKe = GV.PageSize * GV.PageIndex;
        GV.DataSource = dv;
        GV.DataBind();
        ModeListForm();
    }

    //===================================================================
    public void SetDataRawatJalan(string RawatJalanId, string PolilinikId)
    {
        txtRawatJalanId.Text = RawatJalanId;
        txtPolilinikId.Text = PolilinikId;
    }
    public DataView GetData()
    {
        SIMRS.DataAccess.RS_RJLayanan objData = new SIMRS.DataAccess.RS_RJLayanan();
        objData.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        DataTable dt = objData.SelectAllWRawatJalanIdLogic();
        return dt.DefaultView;
    }
}
