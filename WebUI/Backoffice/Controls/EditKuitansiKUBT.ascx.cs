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

public partial class Backoffice_Controls_EditKuitansiKUBT : System.Web.UI.UserControl
{
    public int NoKe = 0;
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
            //btnKuitansi.Visible = true;
            //btnKuitansi.Attributes.Remove("onclick");
            //btnKuitansi.Attributes.Add("onclick", "displayPopup_scroll(2,'PrintKuitansiRJ.aspx?RawatJalanId=" + txtRawatJalanId.Text + "','Pasien',600,800,(version4 ? event : null));");

        }
        else
        {
            //btnKuitansi.Visible = false;
            GV.PageIndex = 0;
        }
        NoKe = GV.PageSize * GV.PageIndex;
        GV.DataSource = dv;
        GV.DataBind();
    }

    //===================================================================
    public void SetDataRawatJalan(string RawatJalanId, string PolilinikId)
    {
        txtRawatJalanId.Text = RawatJalanId;
        txtPolilinikId.Text = PolilinikId;
    }
    public DataView GetData()
    {
        SIMRS.DataAccess.RS_RJKuitansi objData = new SIMRS.DataAccess.RS_RJKuitansi();
        objData.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        DataTable dt = objData.SelectAllWRawatJalanIdLogic();
        return dt.DefaultView;
    }

    public string GetlinkDetil(string KuitansiId)
    {
        string result = "<a href=\"javascript:void(0)\" class=\"button\" visible=\"False\" ";
        result += "onclick=\"displayPopup_scroll(2,'../Pasien/KuitansiRJ.aspx?KuitansiId=" + KuitansiId + "','kuitansi',600,800,(version4 ? event : null));\" >Detil</a>";
        return result;
    }
    public string GetlinkEdit(string KuitansiId)
    {
        string result = "<a href=\"javascript:void(0)\" class=\"button\" visible=\"False\" ";
        result += "onclick=\"displayPopup_scroll(2,'EditKuitansiRJ.aspx?KuitansiId=" + KuitansiId + "','kuitansi',600,800,(version4 ? event : null));\" >Edit</a>";
        return result;
    }
}
