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

public partial class Backoffice_Controls_ViewDepositRI : System.Web.UI.UserControl
{
    public int NoKe = 0;
    public decimal TotalDeposit = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
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
            TotalDeposit = 0;
            foreach (DataRow dr in dv.Table.Rows)
            {
                TotalDeposit += (decimal)dr["JumlahBiaya"];
            }
        }
        else
        {
            GV.PageIndex = 0;
        }
        NoKe = GV.PageSize * GV.PageIndex;
        GV.DataSource = dv;
        GV.DataBind();
    }

    //===================================================================
    public void SetDataRawatInap(string RawatInapId, string KelasId, string NamaPasien)
    {
        txtRawatInapId.Text = RawatInapId;
        txtNamaPasien.Text = NamaPasien;
        txtKelasId.Text = KelasId;
    }
    public DataView GetData()
    {
        SIMRS.DataAccess.RS_RIKuitansi objData = new SIMRS.DataAccess.RS_RIKuitansi();
        objData.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        DataTable dt = objData.SelectAllDepositWRawatInapIdLogic();
        return dt.DefaultView;
    }

}
