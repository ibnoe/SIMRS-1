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

public partial class Backoffice_Kasir_EdiKuitansiRI : System.Web.UI.Page
{
    public int NoKe = 0;
    public decimal TotalTagihan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["KuitansiId"] != null && Request["KuitansiId"].ToString() != "")
            {
                txtKuitansiId.Text = Request["KuitansiId"].ToString();
                BindDataRI();
                BindDataGrid();
            }
        }
    }
    private void BindDataRI()
    {
        SIMRS.DataAccess.RS_RIKuitansi objData = new SIMRS.DataAccess.RS_RIKuitansi();
        objData.KuitansiId = Int64.Parse(txtKuitansiId.Text);
        DataTable dt = objData.SelectOne();
        if(dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtNoRM.Text = dr["NoRM"].ToString();
            txtNoRegistrasi.Text = dr["NoRegistrasi"].ToString();
            txtDiterimaDari.Text = dr["DiterimaDari"].ToString();
            txtTanggalBayar.Text = ((DateTime)dr["TanggalBayar"]).ToString("dd/MM/yyyy");
            txtNoKuitansi.Text = dr["NomorKuitansi"].ToString();
        }
         
    }
    private void GetNomorKuitansi()
    {
        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        txtNoKuitansi.Text = myObj.GetNomorKuitansi();
    }
    public void BindDataGrid()
    {
        DataView dv = GetDataTagihan();
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
            foreach (DataRow dr in dv.Table.Rows)
            {
                TotalTagihan += (decimal)dr["JumlahTagihan"];
            }
            txtJumlahBiaya.Text = TotalTagihan.ToString();
            txtJumlahBiayaText.Text = Resources.Number2Word(long.Parse(TotalTagihan.ToString("#")));
        }
        else
        {
            GV.PageIndex = 0;
        }
        NoKe = GV.PageSize * GV.PageIndex;
        GV.DataSource = dv;
        GV.DataBind();
    }
    public DataView GetDataTagihan()
    {
        SIMRS.DataAccess.RS_RIKuitansiLayanan objData = new SIMRS.DataAccess.RS_RIKuitansiLayanan();
        objData.KuitansiId = Int64.Parse(txtKuitansiId.Text);
        DataTable dt = objData.SelectAllWKuitansiIdLogic();
        return dt.DefaultView;
    }
    protected void cbxAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAll = (CheckBox)GV.HeaderRow.FindControl("cbxAll");
        bool ceck = cbAll.Checked;
        for (int i = 0; i < GV.Rows.Count; i++)
        {
            ((CheckBox)GV.Rows[i].FindControl("cbxRILayananId")).Checked = ceck;
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        if (!Page.IsValid)
        {
            return;
        }
        int UserId = (int)Session["SIMRS.UserId"];

        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        myObj.KuitansiId = Int64.Parse(txtKuitansiId.Text);
        myObj.SelectOne();
        myObj.NomorKuitansi = txtNoKuitansi.Text;
        myObj.DiterimaDari = txtDiterimaDari.Text;
        if (txtTanggalBayar.Text != "")
            myObj.TanggalBayar = DateTime.Parse(txtTanggalBayar.Text);

        myObj.JumlahBiaya = decimal.Parse(txtJumlahBiaya.Text);
        myObj.JumlahBiayaText = txtJumlahBiayaText.Text;
        
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;
        if (myObj.Update())
        {
            //if (GV.Rows.Count > 0)
            //{
            //    SIMRS.DataAccess.RS_RIKuitansiLayanan obj = new SIMRS.DataAccess.RS_RIKuitansiLayanan();
            //    obj.KuitansiId = myObj.KuitansiId;
            //    for (int i = 0; i < GV.Rows.Count; i++)
            //    {
            //        if (((CheckBox)GV.Rows[i].FindControl("cbxRILayananId")).Checked)
            //        {
            //            obj.RILayananId = Int64.Parse(GV.DataKeys[i].Value.ToString());
            //            obj.Insert();
            //        }
            //    }
            //}
            //myObj.UpdateStatusBayar();
            Response.Redirect("../Pasien/KuitansiRI.aspx?KuitansiId=" + myObj.KuitansiId.ToString());
        }
    }
}
