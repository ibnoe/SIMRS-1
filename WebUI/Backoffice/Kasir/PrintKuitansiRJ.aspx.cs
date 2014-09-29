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

public partial class Backoffice_Kasir_PrintKuitansiRJ : System.Web.UI.Page
{
    public int NoKe = 0;
    public decimal TotalTagihan = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["RawatJalanId"] != null && Request["RawatJalanId"].ToString() != "")
            {
                txtRawatJalanId.Text = Request["RawatJalanId"].ToString();
                
                txtUserName.Text = Session["SIMRS.UserName"].ToString();
                txtUserId.Text = Session["SIMRS.UserId"].ToString();
                
                BindDataRJ();
                GetNomorKuitansi();
                BindDataGrid();
            }
        }
    }
    private void BindDataRJ()
    {
        SIMRS.DataAccess.RS_RawatJalan objData = new SIMRS.DataAccess.RS_RawatJalan();
        objData.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        DataTable dt = objData.SelectOne();
        if(dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtNoRM.Text = dr["NoRM"].ToString();
            txtNoRegistrasi.Text = dr["NoRegistrasi"].ToString();
            txtDiterimaDari.Text = dr["Nama"].ToString();
            txtPoliklinikId.Text = dr["PoliklinikId"].ToString();
            txtTanggalBayar.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
         
    }
    private void GetNomorKuitansi()
    {
        SIMRS.DataAccess.RS_RJKuitansi myObj = new SIMRS.DataAccess.RS_RJKuitansi();
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
            txtJumlahBiaya.Text = TotalTagihan.ToString("N");
            txtJumlahBiayaText.Text = Resources.Number2Word(long.Parse(TotalTagihan.ToString("#"))) + " Rupiah";
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
        SIMRS.DataAccess.RS_RJLayanan objData = new SIMRS.DataAccess.RS_RJLayanan();
        objData.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        DataTable dt = objData.GetDataTagihanByRawatJalanId();
        return dt.DefaultView;
    }
    protected void cbxAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox cbAll = (CheckBox)GV.HeaderRow.FindControl("cbxAll");
        bool ceck = cbAll.Checked;
        for (int i = 0; i < GV.Rows.Count; i++)
        {
            ((CheckBox)GV.Rows[i].FindControl("cbxRJLayananId")).Checked = ceck;
        }
        HitungTotalTagihan();
    }

    protected void cbxRJLayananId_CheckedChanged(object sender, EventArgs e)
    {
        HitungTotalTagihan();
    }
    private void HitungTotalTagihan()
    {
        decimal total = 0;
        for (int i = 0; i < GV.Rows.Count; i++)
        {
            if (((CheckBox)GV.Rows[i].FindControl("cbxRJLayananId")).Checked == true)
            {
                total += decimal.Parse(((Label)GV.Rows[i].FindControl("lblgJumlahTagihan")).Text);
            }
        }
        txtJumlahBiaya.Text = total.ToString("N");
        txtJumlahBiayaText.Text = Resources.Number2Word(long.Parse(total.ToString())) + " Rupiah";
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
        bool check = false;
        for (int i = 0; i < GV.Rows.Count; i++)
        {
            if (((CheckBox)GV.Rows[i].FindControl("cbxRJLayananId")).Checked == true)
            {
                check = true;
                break;
            } 
        }
        if (check == false)
        {
            lblError.Text = "Pilih Item Layanan yang akan dibayar !";
            return;
        }

        int UserId = (int)Session["SIMRS.UserId"];

        SIMRS.DataAccess.RS_RJKuitansi myObj = new SIMRS.DataAccess.RS_RJKuitansi();
        myObj.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        myObj.NomorKuitansi = txtNoKuitansi.Text;
        myObj.DiterimaDari = txtDiterimaDari.Text;
        if (txtTanggalBayar.Text != "")
            myObj.TanggalBayar = DateTime.Parse(txtTanggalBayar.Text);

        myObj.JumlahBiaya = decimal.Parse(txtJumlahBiaya.Text);
        myObj.JumlahBiayaText = txtJumlahBiayaText.Text;
        
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        myObj.UserId = Int32.Parse(txtUserId.Text);

        if (myObj.Insert())
        {
            if (GV.Rows.Count > 0)
            {
                SIMRS.DataAccess.RS_RJKuitansiLayanan obj = new SIMRS.DataAccess.RS_RJKuitansiLayanan();
                obj.KuitansiId = myObj.KuitansiId;
                for (int i = 0; i < GV.Rows.Count; i++)
                {
                    if (((CheckBox)GV.Rows[i].FindControl("cbxRJLayananId")).Checked)
                    {
                        obj.RJLayananId = Int64.Parse(GV.DataKeys[i].Value.ToString());
                        obj.Insert();
                    }
                }
            }
            myObj.UpdateStatusBayar();
            Response.Redirect("../Pasien/KuitansiRJ.aspx?KuitansiId=" + myObj.KuitansiId.ToString());
        }
    }
}
