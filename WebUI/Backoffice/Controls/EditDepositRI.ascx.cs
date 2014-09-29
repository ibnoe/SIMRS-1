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

public partial class Backoffice_Controls_EditDepositRI : System.Web.UI.UserControl
{
    public int NoKe = 0;
    public decimal TotalDeposit = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void ModeEditForm()
    {
        pnlList.Visible = false;
        pnlEdit.Visible = true;
        pnlView.Visible = false;
        btnAdd.Visible = false;
        lblError.Text = "";
        lblWarning.Text = "";
    }
    private void ModeListForm()
    {
        pnlList.Visible = true;
        pnlEdit.Visible = false;
        pnlView.Visible = false;
        btnAdd.Visible = true;
    }
    private void ModeViewForm()
    {
        lblWarning.Text = "";
        GV.EditIndex = -1;
        pnlList.Visible = false;
        pnlEdit.Visible = false;
        pnlView.Visible = true;
        btnAdd.Visible = false;
    }

    protected void GV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GV.SelectedIndex = e.NewSelectedIndex;
        FillFormView(GV.DataKeys[e.NewSelectedIndex].Value.ToString());
        ModeViewForm();
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

    protected void GV_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblTitleEditForm.Text = "EDIT DEPOSIT";
        GV.SelectedIndex = e.NewEditIndex;
        string key = GV.DataKeys[e.NewEditIndex].Value.ToString();
        FillFormEdit(key);
        ModeEditForm();
    }

    protected void btnEditDetil_Click(object sender, EventArgs e)
    {
        FillFormEdit(txtKuitansiId.Text);
        lblTitleEditForm.Text = "EDIT DEPOSIT";
        ModeEditForm();
    }

    protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        DeleteData(GV.DataKeys[i].Value.ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblTitleEditForm.Text = "TAMBAH DEPOSIT";
        ModeEditForm();
        EmptyFormEdit();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        ModeListForm();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        ModeListForm();
    }
    protected void btnDeleteDetil_Click(object sender, EventArgs e)
    {
        DeleteData(lblKuitansiId.Text);
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
            //bool statusbayar = true;
            //bool statusBelumBayar = false;
            foreach (DataRow dr in dv.Table.Rows)
            {
                //statusBelumBayar = dr["StatusBayar"].ToString() == "0" ? true : false;
                //if (statusBelumBayar)
                //    statusbayar = false;
                TotalDeposit += (decimal)dr["JumlahBiaya"];
            }
            //if (!statusbayar && Session["KasirRI"] != null)
            //{
            //    btnKuitansi.Visible = true;
            //    btnKuitansi.Attributes.Remove("onclick");
            //    btnKuitansi.Attributes.Add("onclick", "displayPopup_scroll(2,'PrintKuitansiDepositRI.aspx?KuitansiId=" + txtRawatInapId.Text + "','Pasien',600,800,(version4 ? event : null));");
            //}
            //else {
            //    btnKuitansi.Visible = false;
            //}
            
        }
        else
        {
            //btnKuitansi.Visible = false;
            GV.PageIndex = 0;
        }
        NoKe = GV.PageSize * GV.PageIndex;
        GV.DataSource = dv;
        GV.DataBind();
        ModeListForm();
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
    private void GetNomorKuitansi()
    {
        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        txtNoKuitansi.Text = myObj.GetNomorKuitansi();
    }
    private void EmptyFormEdit()
    {
        txtKuitansiId.Text = "0";
        GetNomorKuitansi();
        txtTanggalBayar.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtDiterimaDari.Text = txtNamaPasien.Text;
        txtJumlahBiaya.Text = "";
        txtJumlahBiayaText.Text = "";
        txtUntukpembayaran.Text = "Uang Muka Rawat Inap Nama Pasien "+txtNamaPasien.Text;
        txtKeterangan.Text = "";
    }
    private void FillFormEdit(string KuitansiId)
    {
        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        myObj.KuitansiId = Int64.Parse(KuitansiId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtKuitansiId.Text = dr["KuitansiId"].ToString();
            txtNoKuitansi.Text = dr["NomorKuitansi"].ToString();
            txtTanggalBayar.Text = dr["TanggalBayar"].ToString() != "" ? ((DateTime)dr["TanggalBayar"]).ToString("dd/MM/yyyy") : "";
            txtDiterimaDari.Text = dr["DiterimaDari"].ToString();
            txtJumlahBiaya.Text = dr["JumlahBiaya"].ToString() != "" ? ((Decimal)dr["JumlahBiaya"]).ToString("#,###.###.###.###") : "";
            txtJumlahBiayaText.Text = dr["JumlahBiayaText"].ToString();
            txtUntukpembayaran.Text = dr["Untukpembayaran"].ToString();
            txtKeterangan.Text = dr["Keterangan"].ToString();
        }
    }
    private void FillFormView(string KuitansiId)
    {
        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        myObj.KuitansiId = Int64.Parse(KuitansiId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            lblKuitansiId.Text = dr["KuitansiId"].ToString();
            //lblTanggalTransaksi.Text = dr["TanggalTransaksi"].ToString() != "" ? ((DateTime)dr["TanggalTransaksi"]).ToString("dd/MM/yyyy HH:mm") : "";
            //lblDeposit.Text = dr["Deposit"].ToString() != "" ? ((Decimal)dr["Deposit"]).ToString("#,###.###.###.###") : "";
            //lblKeterangan.Text = dr["Keterangan"].ToString().Replace("\r\n","<br />");

            //lblKuitansiId.Text = dr["KuitansiId"].ToString();
            //lblNoKuitansi.Text = dr["NoKuitansi"].ToString();
            //lblTanggalBayar.Text = dr["TanggalBayar"].ToString() != "" ? ((DateTime)dr["TanggalBayar"]).ToString("dd/MM/yyyy") : "";
            //lblDiterimaDari.Text = dr["DiterimaDari"].ToString();
            //lblJumlahBiaya.Text = dr["JumlahBiaya"].ToString() != "" ? ((Decimal)dr["JumlahBiaya"]).ToString("#,###.###.###.###") : "";
            //lblJumlahBiayaText.Text = dr["JumlahBiayaText"].ToString().Replace("\r\n", "<br />");
            //lblUntukpembayaran.Text = dr["Untukpembayaran"].ToString().Replace("\r\n", "<br />");
            //lblKeterangan.Text = dr["Keterangan"].ToString().Replace("\r\n","<br />");
        }
    }
    private void SaveData()
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
        if (myObj.KuitansiId > 0)
            myObj.SelectOne();
        myObj.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        myObj.JenisKuitansiId = 1 ;//Deposit
        myObj.NomorKuitansi = txtNoKuitansi.Text;
        myObj.DiterimaDari = txtDiterimaDari.Text;
        if (txtTanggalBayar.Text != "")
        {
            myObj.TanggalBayar = DateTime.Parse(txtTanggalBayar.Text);
        }
        myObj.JumlahBiaya = decimal.Parse(txtJumlahBiaya.Text);
        myObj.JumlahBiayaText = txtJumlahBiayaText.Text;
        myObj.UntukPembayaran = txtUntukpembayaran.Text;
        myObj.Keterangan = txtKeterangan.Text;
        
        if (myObj.KuitansiId == 0)
        {
            //Kondisi Insert Data
            myObj.CreatedBy = UserId;
            myObj.CreatedDate = DateTime.Now;
            myObj.Insert();
            lblWarning.Text = Resources.GetString("", "WarSuccessSave");
        }
        else
        {
            //Kondisi Update Data
            myObj.ModifiedBy = UserId;
            myObj.ModifiedDate = DateTime.Now;
            myObj.Update();
            lblWarning.Text = Resources.GetString("", "WarSuccessSave");
        }
        BindDataGrid();
        ModeListForm();
    }
    private void DeleteData(string KuitansiId)
    {
        SIMRS.DataAccess.RS_RIKuitansi myObj = new SIMRS.DataAccess.RS_RIKuitansi();
        myObj.KuitansiId = int.Parse(KuitansiId);
        try
        {
            myObj.Delete();
            GV.SelectedIndex = -1;
            BindDataGrid();
            lblWarning.Text = Resources.GetString("", "WarSuccessDelete");
            ModeListForm();
        }
        catch
        {
            lblWarning.Text = Resources.GetString("", "WarAlreadyUsed");
        }
        
    }
    protected void txtJumlahBiaya_TextChanged(object sender, EventArgs e)
    {
        if (REVJumlahBiaya.IsValid && txtJumlahBiaya.Text != "")
        {
            if (txtJumlahBiaya.Text != "0")
            {
                txtJumlahBiaya.Text = (decimal.Parse(txtJumlahBiaya.Text)).ToString("#,###.###.###.###");
                string jumlahBiaya = (decimal.Parse(txtJumlahBiaya.Text)).ToString("#");
                txtJumlahBiayaText.Text = Resources.Number2Word(long.Parse(jumlahBiaya)) + " Rupiah";
            }
            else
            {
                txtJumlahBiayaText.Text = "";
            }
            
        }
        else
        {
            txtJumlahBiayaText.Text = "";
        }
    }
    public string getlinkPrint(string KuitansiId)
    {
        return "displayPopup_scroll(2,'../Pasien/KuitansiRI.aspx?KuitansiId=" + KuitansiId + "','kuitansi',600,800,(version4 ? event : null));";
        //return "displayPopup_scroll(2,'PrintKuitansiDepositRI.aspx?KuitansiId=" + kuitansiId + "','Pasien',600,800,(version4 ? event : null));";
    }
}
