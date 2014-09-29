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

public partial class Backoffice_Controls_EditKasirRI : System.Web.UI.UserControl
{
    public int NoKe = 0;
    public decimal TotalTagihan = 0;
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
        lblTitleEditForm.Text = Resources.GetString("RS", "TitleKasirEditRI");
        GV.SelectedIndex = e.NewEditIndex;
        string key = GV.DataKeys[e.NewEditIndex].Value.ToString();
        FillFormEdit(key);
        ModeEditForm();
    }

    protected void btnEditDetil_Click(object sender, EventArgs e)
    {
        FillFormEdit(txtRILayananId.Text);
        lblTitleEditForm.Text = Resources.GetString("RS", "TitleKasirEditRI");
        ModeEditForm();
    }

    protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        DeleteData(GV.DataKeys[i].Value.ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblTitleEditForm.Text = Resources.GetString("RS", "TitleKasirAddRI");
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
        DeleteData(lblRILayananId.Text);
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
            bool statusbayar = true;
            bool statusBelumBayar = false;
            foreach (DataRow dr in dv.Table.Rows)
            {
                statusBelumBayar = dr["StatusBayar"].ToString() == "0" ? true : false;
                if (statusBelumBayar)
                    statusbayar = false;
                TotalTagihan += (decimal)dr["JumlahTagihan"];
            }
            if (!statusbayar && Session["KasirRI"] != null)
            {
                btnKuitansi.Visible = true;
                btnKuitansi.Attributes.Remove("onclick");
                btnKuitansi.Attributes.Add("onclick", "displayPopup_scroll(2,'PrintKuitansiRI.aspx?RawatInapId=" + txtRawatInapId.Text + "','Pasien',600,800,(version4 ? event : null));");
            }
            else {
                btnKuitansi.Visible = false;
            }
            btnRincian.Visible = true;
            btnRincian.Attributes.Remove("onclick");
            btnRincian.Attributes.Add("onclick", "displayPopup_scroll(2,'../Pasien/dlgDetilLayananRI.aspx?RawatInapId=" + txtRawatInapId.Text + "','Pasien',600,800,(version4 ? event : null));");
            //btnPenagihan
            btnPenagihan.Visible = true;
            btnPenagihan.Attributes.Remove("onclick");
            btnPenagihan.Attributes.Add("onclick", "displayPopup_scroll(2,'../Pasien/PenagihanLayananRI.aspx?RawatInapId=" + txtRawatInapId.Text + "','Pasien',600,800,(version4 ? event : null));");
            
        }
        else
        {
            btnKuitansi.Visible = false;
            btnRincian.Visible = false;
            btnPenagihan.Visible = false;
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
    private void SelectRuangRawat(string TempatInapId)
    {
        if (cmbRuangRawat.Items.Count > 0)
        {
            for (int i = 0; i < cmbRuangRawat.Items.Count; i++)
            {
                string[] ruangrawat = cmbRuangRawat.Items[i].Value.Split('|');
                if (ruangrawat[0] == TempatInapId)
                {
                    cmbRuangRawat.SelectedIndex = i;
                    break;
                }
            }
        }
        else
        {
            PopulateRuangRawat(TempatInapId);
        }
    }
    private void PopulateRuangRawat(string TempatInapId)
    {
        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        DataTable dt = myObj.SelectAllWRawatInapIdLogic();
        cmbRuangRawat.Items.Clear();
        int i = 0;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                cmbRuangRawat.Items.Add("");
                cmbRuangRawat.Items[i].Text = dr["KelasNama"].ToString() + " - " + dr["RuangNama"].ToString() + " - " + dr["NomorRuang"].ToString();
                cmbRuangRawat.Items[i].Value = dr["TempatInapId"].ToString()+"|"+dr["KelasId"].ToString();
                if (dr["TempatInapId"].ToString() == TempatInapId)
                    cmbRuangRawat.SelectedIndex = i;
                i++;
            }
        }
    }
    private void SelectJenisLayanan(string JenisLayananId)
    {
        if (cmbJenisLayanan.Items.Count > 0)
        {
            cmbJenisLayanan.SelectedIndex = 0;
            for (int i = 0; i < cmbJenisLayanan.Items.Count; i++)
            {
                if (cmbJenisLayanan.Items[i].Value == JenisLayananId)
                {
                    cmbJenisLayanan.SelectedIndex = i;
                    break;
                }
            }
        }
        else
        {
            PopulateJenisLayanan(JenisLayananId);
        }
    }
    private void PopulateJenisLayanan(string JenisLayananId)
    {
        SIMRS.DataAccess.RS_JenisLayanan myObj = new SIMRS.DataAccess.RS_JenisLayanan();
        DataTable dt = myObj.GetList();
        cmbJenisLayanan.Items.Clear();
        int i = 0;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Id"].ToString() != "1")
                {
                    cmbJenisLayanan.Items.Add("");
                    cmbJenisLayanan.Items[i].Text = dr["Nama"].ToString();
                    cmbJenisLayanan.Items[i].Value = dr["Id"].ToString();
                    if (dr["Id"].ToString() == JenisLayananId)
                        cmbJenisLayanan.SelectedIndex = i;
                    i++;
                }
            }
            if (JenisLayananId == "")
                cmbJenisLayanan.SelectedIndex = 0;
        }
    }
    private void SelectKelompokLayanan(string KelompokLayananId)
    {
        if (cmbKelompokLayanan.Items.Count > 0)
        {
            cmbKelompokLayanan.SelectedIndex = -1;
            for (int i = 0; i < cmbKelompokLayanan.Items.Count; i++)
            {
                if (cmbKelompokLayanan.Items[i].Value == KelompokLayananId)
                {
                    cmbKelompokLayanan.SelectedIndex = i;
                    break;
                }
            }
        }
        else
        {
            PopulateKelompokLayanan(KelompokLayananId);
        }
    }
    private void PopulateKelompokLayanan(string KelompokLayananId)
    {
        SIMRS.DataAccess.RS_KelompokLayanan myObj = new SIMRS.DataAccess.RS_KelompokLayanan();
        DataTable dt = myObj.GetList();
        cmbKelompokLayanan.Items.Clear();
        int i = 0;
        cmbKelompokLayanan.Items.Add("");
        cmbKelompokLayanan.Items[i].Text = "";
        cmbKelompokLayanan.Items[i].Value = "";
        i++;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                cmbKelompokLayanan.Items.Add("");
                cmbKelompokLayanan.Items[i].Text = dr["Nama"].ToString();
                cmbKelompokLayanan.Items[i].Value = dr["Id"].ToString();
                if (dr["Id"].ToString() == KelompokLayananId)
                    cmbKelompokLayanan.SelectedIndex = i;
                i++;
            }
        }
    }
    private void SelectLayanan(string LayananId)
    {
        cmbLayanan.Items.Clear();
        if (cmbKelompokLayanan.SelectedIndex > 0)
        {
            SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
            myObj.JenisLayananId = int.Parse(cmbJenisLayanan.SelectedItem.Value);
            myObj.KelompokLayananId = int.Parse(cmbKelompokLayanan.SelectedItem.Value);
            string[] ruangrawat = cmbRuangRawat.SelectedItem.Value.Split('|');
            int KelasId = int.Parse(ruangrawat[1]);
            DataTable dt = myObj.GetListFilterRI(KelasId);
            cmbLayanan.Items.Clear();
            int i = 0;
            cmbLayanan.Items.Add("");
            cmbLayanan.Items[i].Text = "";
            cmbLayanan.Items[i].Value = "";
            cmbLayanan.SelectedIndex = -1;
            pnlLayananLain.Visible = false;
            i++;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    cmbLayanan.Items.Add("");
                    cmbLayanan.Items[i].Text = dr["LayananNama"].ToString();
                    if (dr["LayananKeterangan"].ToString() != "")
                        cmbLayanan.Items[i].Text = cmbLayanan.Items[i].Text + " (" + dr["LayananKeterangan"].ToString() + ")";
                    cmbLayanan.Items[i].Value = dr["LayananId"].ToString();
                    if (dr["LayananId"].ToString() == LayananId)
                    {
                        cmbLayanan.SelectedIndex = i;
                    }
                    i++;
                }
            }
            cmbLayanan.Items.Add("");
            cmbLayanan.Items[i].Text = "Lainnya";
            cmbLayanan.Items[i].Value = "-1";
            if (LayananId == "")
            {
                cmbLayanan.SelectedIndex = i;
                pnlLayananLain.Visible = true;
            }
        }
        
        
    }
    //===================================================================
    public void SetDataRawatInap(string RawatInapId, string KelasId, string TempatInapId)
    {
        txtRawatInapId.Text = RawatInapId;
        txtTempatInapId.Text = TempatInapId;
        txtKelasId.Text = KelasId;
    }
    public DataView GetData()
    {
        SIMRS.DataAccess.RS_RILayanan objData = new SIMRS.DataAccess.RS_RILayanan();
        objData.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        DataTable dt = objData.SelectAllWRawatInapIdLogic();
        return dt.DefaultView;
    }
    private void EmptyFormEdit()
    {
        txtRILayananId.Text = "0";
        txtTanggalTransaksi.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtJamTransaksi.Text = "";
        SelectRuangRawat(txtTempatInapId.Text);
        SelectJenisLayanan("");
        SelectKelompokLayanan("");
        SelectLayanan("-1");
        txtTarif.Text = "0";
        txtJumlahSatuan.Text = "1";
        txtDiscount.Text = "0";
        txtBiayaTambahan.Text = "0";
        txtJumlahTagihan.Text = "0";
        txtKeterangan.Text = "";
    }
    private void FillFormEdit(string RILayananId)
    {
        SIMRS.DataAccess.RS_RILayanan myObj = new SIMRS.DataAccess.RS_RILayanan();
        myObj.RILayananId = Int64.Parse(RILayananId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtRILayananId.Text = dr["RILayananId"].ToString();
            txtTanggalTransaksi.Text = dr["TanggalTransaksi"].ToString() != "" ? ((DateTime)dr["TanggalTransaksi"]).ToString("dd/MM/yyyy") : "";
            txtJamTransaksi.Text = dr["TanggalTransaksi"].ToString() != "" ? ((DateTime)dr["TanggalTransaksi"]).ToString("HH:mm") : "";
            SelectRuangRawat(dr["TempatInapId"].ToString());
            SelectJenisLayanan(dr["JenisLayananId"].ToString());
            SelectKelompokLayanan(dr["KelompokLayananId"].ToString());
            SelectLayanan(dr["LayananId"].ToString());
            txtNamaLayanan.Text = dr["NamaLayanan"].ToString();
            txtTarif.Text = dr["Tarif"].ToString() != "" ? ((Decimal)dr["Tarif"]).ToString("#,###.###.###.###") : "";
            txtJumlahSatuan.Text = dr["JumlahSatuan"].ToString();
            txtDiscount.Text = dr["Discount"].ToString();
            txtBiayaTambahan.Text = dr["BiayaTambahan"].ToString();
            txtJumlahTagihan.Text = dr["JumlahTagihan"].ToString() != "" ? ((Decimal)dr["JumlahTagihan"]).ToString("#,###.###.###.###") : "";
            txtKeterangan.Text = dr["Keterangan"].ToString();
        }
    }
    private void FillFormView(string RILayananId)
    {
        SIMRS.DataAccess.RS_RILayanan myObj = new SIMRS.DataAccess.RS_RILayanan();
        myObj.RILayananId = Int64.Parse(RILayananId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            lblRILayananId.Text = dr["RILayananId"].ToString();
            lblTanggalTransaksi.Text = dr["TanggalTransaksi"].ToString() != "" ? ((DateTime)dr["TanggalTransaksi"]).ToString("dd/MM/yyyy HH:mm") : "";
            lblRuangRawat.Text = dr["KelasNama"].ToString() + " - " + dr["RuangNama"].ToString() + " - " + dr["NomorRuang"].ToString();
            lblJenisLayananNama.Text = dr["JenisLayananNama"].ToString();
            lblKelompokLayanan.Text = dr["KelompokLayananNama"].ToString();
            lblNamaLayanan.Text = dr["NamaLayanan"].ToString();
            lblTarif.Text = dr["Tarif"].ToString() != "" ? ((Decimal)dr["Tarif"]).ToString("#,###.###.###.###") : "";
            lblJumlahSatuan.Text = dr["JumlahSatuan"].ToString();
            lblDiscount.Text = dr["Discount"].ToString();
            lblBiayaTambahan.Text = dr["BiayaTambahan"].ToString();
            lblJumlahTagihan.Text = dr["JumlahTagihan"].ToString() != "" ? ((Decimal)dr["JumlahTagihan"]).ToString("#,###.###.###.###") : "";
            lblKeterangan.Text = dr["Keterangan"].ToString().Replace("\r\n","<br />");
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

        SIMRS.DataAccess.RS_RILayanan myObj = new SIMRS.DataAccess.RS_RILayanan();
        myObj.RILayananId = Int64.Parse(txtRILayananId.Text);
        if (myObj.RILayananId > 0)
            myObj.SelectOne();
        myObj.RawatInapId = Int64.Parse(txtRawatInapId.Text);
        if (txtTanggalTransaksi.Text != "")
        {
            DateTime tanggalTransaksi = DateTime.Parse(txtTanggalTransaksi.Text);
            if (txtJamTransaksi.Text != "")
            {
                tanggalTransaksi = tanggalTransaksi.AddHours(double.Parse(txtJamTransaksi.Text.Substring(0, 2)));
                tanggalTransaksi = tanggalTransaksi.AddMinutes(double.Parse(txtJamTransaksi.Text.Substring(3, 2)));
            }
            myObj.TanggalTransaksi = tanggalTransaksi;
        }
        string[] ruangrawat = cmbRuangRawat.SelectedItem.Value.Split('|');
        myObj.TempatInapId = Int64.Parse(ruangrawat[0]);
        myObj.JenisLayananId = int.Parse(cmbJenisLayanan.SelectedItem.Value);

        if (cmbKelompokLayanan.SelectedIndex > 0)
            myObj.KelompokLayananId = int.Parse(cmbKelompokLayanan.SelectedItem.Value);
        else
            myObj.KelompokLayananId = SqlInt32.Null;
        if (cmbLayanan.SelectedIndex > 0 && cmbLayanan.SelectedItem.Value != "-1")
            myObj.LayananId = int.Parse(cmbLayanan.SelectedItem.Value);
        else
            myObj.LayananId = SqlInt32.Null;
        myObj.NamaLayanan = txtNamaLayanan.Text;
        if(txtTarif.Text != "")
            myObj.Tarif = decimal.Parse(txtTarif.Text);

        if (txtJumlahSatuan.Text != "")
            myObj.JumlahSatuan = double.Parse(txtJumlahSatuan.Text);
        if (txtDiscount.Text != "")
            myObj.Discount = double.Parse(txtDiscount.Text);
        if (txtBiayaTambahan.Text != "")
            myObj.BiayaTambahan = double.Parse(txtBiayaTambahan.Text);
        if (txtJumlahTagihan.Text != "")
            myObj.JumlahTagihan = decimal.Parse(txtJumlahTagihan.Text);
        myObj.Keterangan = txtKeterangan.Text;
        
        if (myObj.RILayananId == 0)
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
    private void DeleteData(string RILayananId)
    {
        SIMRS.DataAccess.RS_RILayanan myObj = new SIMRS.DataAccess.RS_RILayanan();
        myObj.RILayananId = int.Parse(RILayananId);
        myObj.SelectOne();
        if (myObj.StatusBayar == 0)
        {
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
        else
        {
            lblWarning.Text = Resources.GetString("", "WarAlreadyUsed"); 
        }
        
    }

    private void GetTarif()
    {
        SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
        if (cmbLayanan.SelectedIndex > 0)
            myObj.Id = int.Parse(cmbLayanan.SelectedItem.Value);
        string[] ruangrawat = cmbRuangRawat.SelectedItem.Value.Split('|');
        int KelasId = int.Parse(ruangrawat[1]);
        DataTable dt = myObj.GetTarifRIByLayananId(KelasId);
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtTarif.Text = dr["Tarif"].ToString() != "" ? ((Decimal)dr["Tarif"]).ToString("#,###.###.###.###") : "0";
            HitungJumlahTagihan();
        }
        else
        {
            txtTarif.Text = "0";
            txtJumlahTagihan.Text = "0";
        }
    }
    protected void cmbRuangRawat_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectLayanan("-1");
        GetTarif();
    }
    protected void cmbLayanan_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetTarif();
        if (cmbLayanan.SelectedIndex == cmbLayanan.Items.Count - 1)
        {
            pnlLayananLain.Visible = true;
            txtNamaLayanan.Text = "";
        }
        else
        {
            pnlLayananLain.Visible = false;
            txtNamaLayanan.Text = cmbLayanan.SelectedItem.Text;
        }
    }
    protected void cmbKelompokLayanan_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectLayanan("-1");
        GetTarif();
    }
    private void HitungJumlahTagihan()
    {
        decimal jumlahTagihan = 0; ;
        decimal discount = 0;
        decimal biayaTambahan = 0;
        if (txtJumlahSatuan.Text != "")
            jumlahTagihan = decimal.Parse(txtJumlahSatuan.Text) * decimal.Parse(txtTarif.Text);
        if (txtDiscount.Text != "")
            discount = jumlahTagihan * decimal.Parse(txtDiscount.Text)/100;
        if (txtBiayaTambahan.Text != "")
            biayaTambahan = jumlahTagihan * decimal.Parse(txtBiayaTambahan.Text)/100;
        jumlahTagihan = jumlahTagihan + biayaTambahan - discount;
        if (jumlahTagihan > 0)
            txtJumlahTagihan.Text = jumlahTagihan.ToString("#,###.###.###.###");
        else
            txtJumlahTagihan.Text = "0";
    }

    protected void txtTarif_TextChanged(object sender, EventArgs e)
    {
        if (REVTarif.IsValid && txtTarif.Text != "")
        {
            if (txtTarif.Text != "0")
                txtTarif.Text = (decimal.Parse(txtTarif.Text)).ToString("#,###.###.###.###");
            HitungJumlahTagihan();
        }
    }
    protected void txtJumlahSatuan_TextChanged(object sender, EventArgs e)
    {
        if (REVJumlahSatuan.IsValid && txtJumlahSatuan.Text != "")
        {
            if (txtJumlahSatuan.Text != "0")
                txtJumlahSatuan.Text = (decimal.Parse(txtJumlahSatuan.Text)).ToString("#,###.###.###.###");
            HitungJumlahTagihan();
        }
    }
    protected void txtDiscount_TextChanged(object sender, EventArgs e)
    {
        if (REVDiscount.IsValid && txtDiscount.Text != "")
        {
            if(txtDiscount.Text != "0")
                txtDiscount.Text = (decimal.Parse(txtDiscount.Text)).ToString("#,###.###.###.###");
            HitungJumlahTagihan();
        }
    }
    protected void txtBiayaTambahan_TextChanged(object sender, EventArgs e)
    {
        if (REVBiayaTambahan.IsValid && txtBiayaTambahan.Text != "")
        {
            if (txtBiayaTambahan.Text != "0")
                txtBiayaTambahan.Text = (decimal.Parse(txtBiayaTambahan.Text)).ToString("#,###.###.###.###");
            HitungJumlahTagihan();
        }
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

    protected void cbxRILayananId_CheckedChanged(object sender, EventArgs e)
    {
        decimal total = 0;
        for (int i = 0; i < GV.Rows.Count; i++)
        {
            if (((CheckBox)GV.Rows[i].FindControl("cbxRILayananId")).Checked == true) 
            {
                total += decimal.Parse(((Label)GV.Rows[i].FindControl("lblgTarif")).Text);
            }
        }
        TotalTagihan = total;
    }
    protected void cmbJenisLayanan_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectLayanan("-1");
        GetTarif();
    }
}
