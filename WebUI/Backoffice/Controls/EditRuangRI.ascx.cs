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

public partial class Backoffice_Controls_EditRuangRI : System.Web.UI.UserControl
{
    public int NoKe = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void ModeEditForm()
    {
        pnlList.Visible = false;
        pnlEdit.Visible = true;
        pnlView.Visible = false;
        lblError.Text = "";
        lblWarning.Text = "";
    }
    private void ModePindahForm()
    {
        pnlList.Visible = false;
        pnlEdit.Visible = true;
        pnlView.Visible = true;
        lblError.Text = "";
        lblWarning.Text = "";
    }
    private void ModeListForm()
    {
        pnlList.Visible = true;
        pnlEdit.Visible = false;
        pnlView.Visible = false;
    }
    private void ModeViewForm()
    {
        lblWarning.Text = "";
        GV.EditIndex = -1;
        pnlList.Visible = false;
        pnlEdit.Visible = false;
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

    protected void GV_RowEditing(object sender, GridViewEditEventArgs e)
    {
        lblTitleEditForm.Text = "Pulang/Keluar Ruang Inap";
        GV.SelectedIndex = e.NewEditIndex;
        string key = GV.DataKeys[e.NewEditIndex].Value.ToString();
        FillFormEdit(key);
        ModeEditForm();
    }
    
    protected void GV_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        txtTempatInapId.Text = GV.DataKeys[e.NewSelectedIndex].Value.ToString();
        PindahTempatInap(txtTempatInapId.Text);
        lblTitleEditForm.Text = "Ruang Inap Baru";
        ModePindahForm();
    }
    protected void btnEditDetil_Click(object sender, EventArgs e)
    {
        FillFormEdit(txtTempatInapId.Text);
        lblTitleEditForm.Text = "Edit Data Ruang Inap";
        ModeEditForm();
    }

    protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        DeleteData(GV.DataKeys[i].Value.ToString());
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
        DeleteData(lblTempatInapId.Text);
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
    //    POLULATE DATA REFERENSI
    //===================================================================
    public void GetListKelas(string KelasId)
    {
        SIMRS.DataAccess.RS_Kelas myObj = new SIMRS.DataAccess.RS_Kelas();
        if (KelasId != "")
            myObj.Id = int.Parse(KelasId);
        DataTable dt = myObj.GetListAvaliableEdit();
        cmbKelas.Items.Clear();
        int i = 0;
        cmbKelas.Items.Add("");
        cmbKelas.Items[i].Text = "";
        cmbKelas.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelas.Items.Add("");
            cmbKelas.Items[i].Text = dr["KelasNama"].ToString();
            cmbKelas.Items[i].Value = dr["KelasId"].ToString();
            if (dr["KelasId"].ToString() == KelasId)
            {
                cmbKelas.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetListRuang(string RuangId)
    {
        int KelasId = 0;
        if (cmbKelas.SelectedIndex > 0)
            KelasId = int.Parse(cmbKelas.SelectedItem.Value);

        SIMRS.DataAccess.RS_Ruang myObj = new SIMRS.DataAccess.RS_Ruang();
        if (RuangId != "")
            myObj.Id = int.Parse(RuangId);
        DataTable dt = myObj.GetListAvaliableEditByKelasId(KelasId);
        cmbRuang.Items.Clear();
        int i = 0;
        cmbRuang.Items.Add("");
        cmbRuang.Items[i].Text = "";
        cmbRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbRuang.Items.Add("");
            cmbRuang.Items[i].Text = dr["RuangNama"].ToString();
            cmbRuang.Items[i].Value = dr["RuangId"].ToString();
            if (dr["RuangId"].ToString() == RuangId)
            {
                cmbRuang.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetListNomorRuang(string RuangRawatId)
    {
        SIMRS.DataAccess.RS_RuangRawat myObj = new SIMRS.DataAccess.RS_RuangRawat();
        if (cmbKelas.SelectedIndex > 0)
            myObj.KelasId = int.Parse(cmbKelas.SelectedItem.Value);
        if (cmbRuang.SelectedIndex > 0)
            myObj.RuangId = int.Parse(cmbRuang.SelectedItem.Value);
        if (RuangRawatId != "")
            myObj.RuangRawatId = int.Parse(RuangRawatId);
        DataTable dt = myObj.GetListAvaliableNomorRuangEdit();
        cmbNomorRuang.Items.Clear();
        int i = 0;
        cmbNomorRuang.Items.Add("");
        cmbNomorRuang.Items[i].Text = "";
        cmbNomorRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbNomorRuang.Items.Add("");
            cmbNomorRuang.Items[i].Text = dr["NomorRuang"].ToString();
            cmbNomorRuang.Items[i].Value = dr["RuangRawatId"].ToString();
            if (dr["RuangRawatId"].ToString() == RuangRawatId)
            {
                cmbNomorRuang.SelectedIndex = i;
            }
            i++;
        }
    }

    public void GetListNomorTempat(string TempatTidurId)
    {
        SIMRS.DataAccess.RS_TempatTidur myObj = new SIMRS.DataAccess.RS_TempatTidur();
        if (cmbNomorRuang.SelectedIndex > 0)
            myObj.RuangRawatId = int.Parse(cmbNomorRuang.SelectedItem.Value);
        if (TempatTidurId != "")
            myObj.TempatTidurId = int.Parse(TempatTidurId);
        DataTable dt = myObj.GetListAvaliableEditByRawatId();
        cmbNomorTempat.Items.Clear();
        int i = 0;
        cmbNomorTempat.Items.Add("");
        cmbNomorTempat.Items[i].Text = "";
        cmbNomorTempat.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbNomorTempat.Items.Add("");
            cmbNomorTempat.Items[i].Text = dr["NomorTempat"].ToString();
            cmbNomorTempat.Items[i].Value = dr["TempatTidurId"].ToString();
            if (dr["TempatTidurId"].ToString() == TempatTidurId)
            {
                cmbNomorTempat.SelectedIndex = i;
            }
            i++;
        }
    }
    
    
    //===================================================================
    public void SetDataRawatInap(string RawatInapId, string StatusRawatInap)
    {
        txtRawatInapId.Text = RawatInapId;
        txtStatusRawatInap.Text = StatusRawatInap;
    }
    public DataView GetData()
    {
        SIMRS.DataAccess.RS_TempatInap objData = new SIMRS.DataAccess.RS_TempatInap();
        objData.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        DataTable dt = objData.SelectAllWRawatInapIdLogic();
        return dt.DefaultView;
    }
    private void EmptyFormEdit()
    {
        txtTempatInapId.Text = "0";
        txtTanggalMasuk.Text = "";
        txtJamMasuk.Text = "";
        txtTanggalKeluar.Text = "";
        txtJamKeluar.Text = "";
        GetListKelas("");
        GetListRuang("");
        GetListNomorRuang("");
        GetListNomorTempat("");
        txtKeterangan.Text = "";
    }
    private void FillFormEdit(string TempatInapId)
    {
        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.TempatInapId = Int64.Parse(TempatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtTempatInapId.Text = dr["TempatInapId"].ToString();
            txtTanggalMasuk.Text = dr["TanggalMasuk"].ToString() != "" ? ((DateTime)dr["TanggalMasuk"]).ToString("dd/MM/yyyy") : "";
            txtJamMasuk.Text = dr["TanggalMasuk"].ToString() != "" ? ((DateTime)dr["TanggalMasuk"]).ToString("HH:mm") : "";
            txtTanggalKeluar.Text = dr["TanggalKeluar"].ToString() != "" ? ((DateTime)dr["TanggalKeluar"]).ToString("dd/MM/yyyy") : "";
            txtJamKeluar.Text = dr["TanggalKeluar"].ToString() != "" ? ((DateTime)dr["TanggalKeluar"]).ToString("HH:mm") : "";
            txtJamInap.Text = dr["JamInap"].ToString();
            GetListKelas(dr["KelasId"].ToString());
            GetListRuang(dr["RuangId"].ToString());
            GetListNomorRuang(dr["RuangRawatId"].ToString());
            GetListNomorTempat(dr["TempatTidurId"].ToString());
            txtKeterangan.Text = dr["Keterangan"].ToString();
        }
    }
    private void PindahTempatInap(string TempatInapId)
    {
        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.TempatInapId = Int64.Parse(TempatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            lblTempatInapId.Text = dr["TempatInapId"].ToString();
            lblTanggalMasuk.Text = dr["TanggalMasuk"].ToString() != "" ? ((DateTime)dr["TanggalMasuk"]).ToString("dd/MM/yyyy HH:mm") : "";
            lblJamMasuk.Text = dr["TanggalMasuk"].ToString() != "" ? ((DateTime)dr["TanggalMasuk"]).ToString("HH:mm") : "";
            lblTanggalKeluar.Text = dr["TanggalKeluar"].ToString() != "" ? ((DateTime)dr["TanggalKeluar"]).ToString("dd/MM/yyyy") : "";
            lblJamKeluar.Text = dr["TanggalKeluar"].ToString() != "" ? ((DateTime)dr["TanggalKeluar"]).ToString("HH:mm") : "";
            lblRuangRawat.Text = dr["KelasNama"].ToString() + " - " + dr["RuangNama"].ToString() + "-" + dr["NomorRuang"].ToString();
            lblNomorTempat.Text = dr["NomorTempat"].ToString();
            lblKeterangan.Text = dr["Keterangan"].ToString().Replace("\r\n", "<br />");

            txtTempatInapId.Text = "0";
            txtTanggalMasuk.Text = "";
            txtJamMasuk.Text = "";
            txtTanggalKeluar.Text = "";
            txtJamKeluar.Text = "";
            txtJamInap.Text = "";
            GetListKelas("");
            GetListRuang("");
            GetListNomorRuang("");
            GetListNomorTempat("");
            txtKeterangan.Text = dr["Keterangan"].ToString();
        }
    }
    private void FillFormView(string TempatInapId)
    {
        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.TempatInapId = Int64.Parse(TempatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            lblTempatInapId.Text = dr["TempatInapId"].ToString();
            lblKeterangan.Text = dr["Keterangan"].ToString().Replace("\r\n","<br />");
        }
    }
    private void SaveData()
    {
        lblError.Text = "";
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        if (!Page.IsValid)
        {
            return;
        }
        int UserId = (int)Session["SIMRS.UserId"];

        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.TempatInapId = Int64.Parse(txtTempatInapId.Text);
        if (myObj.TempatInapId > 0)
            myObj.SelectOne();
        if (cmbNomorRuang.SelectedIndex > 0)
            myObj.RuangRawatId = int.Parse(cmbNomorRuang.SelectedItem.Value);
        if (cmbNomorTempat.SelectedIndex > 0)
            myObj.TempatTidurId = int.Parse(cmbNomorTempat.SelectedItem.Value);
        DateTime TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Text);
        TanggalMasuk = TanggalMasuk.AddHours(double.Parse(txtJamMasuk.Text.Substring(0, 2)));
        TanggalMasuk = TanggalMasuk.AddMinutes(double.Parse(txtJamMasuk.Text.Substring(3, 2)));
        myObj.TanggalMasuk = TanggalMasuk;
        myObj.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        myObj.Keterangan = txtKeterangan.Text;
        
        if (myObj.TempatInapId == 0)
        {
            //Kondisi Insert Data
            myObj.TempatInapIdOld  = Int64.Parse(lblTempatInapId.Text);
            myObj.CreatedBy = UserId;
            myObj.CreatedDate = DateTime.Now;
            myObj.Pindah();
            lblWarning.Text = Resources.GetString("", "WarSuccessSave");
            Response.Redirect("RIRuangView.aspx?RawatInapId=" + txtRawatInapId.Text);
        }
        else
        {
            //Kondisi Update Data
            if (txtTanggalKeluar.Text != "")
            {
                DateTime TanggalKeluar = DateTime.Parse(txtTanggalKeluar.Text);
                if (txtJamKeluar.Text != "")
                {
                    TanggalKeluar = TanggalKeluar.AddHours(double.Parse(txtJamKeluar.Text.Substring(0, 2)));
                    TanggalKeluar = TanggalKeluar.AddMinutes(double.Parse(txtJamKeluar.Text.Substring(3, 2)));
                }
                myObj.TanggalKeluar = TanggalKeluar;
            }
            else
            {
                lblError.Text = "Tanggal Keluar Harus diisi !";
                return;
            }
            myObj.ModifiedBy = UserId;
            myObj.ModifiedDate = DateTime.Now;
            myObj.Pulang();
            lblWarning.Text = Resources.GetString("", "WarSuccessSave");
            Response.Redirect("RIRuangView.aspx?RawatInapId=" + txtRawatInapId.Text);
        }
        BindDataGrid();
        ModeListForm();
    }
    private void DeleteData(string TempatInapId)
    {
        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.TempatInapId = int.Parse(TempatInapId);
        myObj.SelectOne();
        try
        {
            myObj.Delete();
            GV.SelectedIndex = -1;
            BindDataGrid();
            lblWarning.Text = Resources.GetString("", "WarSuccessDelete");
            ModeListForm();
            Response.Redirect("RIRuangView.aspx?RawatInapId=" + txtRawatInapId.Text);
        }
        catch
        {
            lblWarning.Text = Resources.GetString("", "WarAlreadyUsed");
        }
    }
    protected void txtTanggalMasuk_TextChanged(object sender, EventArgs e)
    {
        if (MEVTanggalMasuk.IsValid)
        {
            lblTanggalKeluar.Text = txtTanggalMasuk.Text;
        }
    }
    protected void txtJamMasuk_TextChanged(object sender, EventArgs e)
    {
        if (MEVJamMasuk.IsValid)
        {
            lblJamKeluar.Text = txtJamMasuk.Text;
        }
    }
    protected void cmbKelas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListRuang("");
    }
    protected void cmbRuang_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListNomorRuang("");
    }
    protected void cmbNomorRuang_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListNomorTempat("");
    }

    public bool GetLinkDelete(string FlagTerakhir, string i)
    {
        if (FlagTerakhir == "True" && i != "1" && txtStatusRawatInap.Text == "0")
            return true;
        else
            return false;
    }
    public bool GetLinkPulang(string FlagTerakhir)
    {
        if (FlagTerakhir == "True" && txtStatusRawatInap.Text == "0")
            return true;
        else
            return false;
    }
    public bool GetLinkPindah(string FlagTerakhir)
    {
        if (FlagTerakhir == "True" && txtStatusRawatInap.Text == "0")
            return true;
        else
            return false;
    }
}
