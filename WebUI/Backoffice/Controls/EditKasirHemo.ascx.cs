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

public partial class Backoffice_Controls_EditKasirHemo : System.Web.UI.UserControl
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
        lblTitleEditForm.Text = Resources.GetString("RS", "TitleKasirEditHemo");
        GV.SelectedIndex = e.NewEditIndex;
        string key = GV.DataKeys[e.NewEditIndex].Value.ToString();
        FillFormEdit(key);
        ModeEditForm();
    }

    protected void btnEditDetil_Click(object sender, EventArgs e)
    {
        //FillFormEdit(txtRJLayananId.Text);
        FillFormEdit(lblRJLayananId.Text);
        lblTitleEditForm.Text = Resources.GetString("RS", "TitleKasirEditHemo");
        ModeEditForm();
    }

    protected void GV_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = e.RowIndex;
        DeleteData(GV.DataKeys[i].Value.ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        lblTitleEditForm.Text = Resources.GetString("RS", "TitleKasirAddHemo");
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
        DeleteData(lblRJLayananId.Text);
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
            if (!statusbayar)
            {
                btnKuitansi.Visible = true;
                btnKuitansi.Attributes.Remove("onclick");
                btnKuitansi.Attributes.Add("onclick", "displayPopup_scroll(2,'PrintKuitansiRJ.aspx?RawatJalanId=" + txtRawatJalanId.Text + "','Pasien',600,800,(version4 ? event : null));");
            }
            else {
                btnKuitansi.Visible = false;
            }
            
        }
        else
        {
            btnKuitansi.Visible = false;
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
    private void SelectKelompokPemeriksaan(string KelompokPemeriksaanId)
    {
        if (cmbKelompokPemeriksaan.Items.Count > 0)
        {
            cmbKelompokPemeriksaan.SelectedIndex = -1;
            for (int i = 0; i < cmbKelompokPemeriksaan.Items.Count; i++)
            {
                if (cmbKelompokPemeriksaan.Items[i].Value == KelompokPemeriksaanId)
                {
                    cmbKelompokPemeriksaan.SelectedIndex = i;
                    break;
                }
            }
        }
        else
        {
            PopulateKelompokPemeriksaan(KelompokPemeriksaanId);
        }
    }
    private void PopulateKelompokPemeriksaan(string KelompokPemeriksaanId)
    {
        SIMRS.DataAccess.RS_KelompokPemeriksaan myObj = new SIMRS.DataAccess.RS_KelompokPemeriksaan();
        myObj.JenisPemeriksaanId = 3;//Hemodialisa
        DataTable dt = myObj.GetListByJenisPemeriksaanId();
        cmbKelompokPemeriksaan.Items.Clear();
        int i = 0;
        cmbKelompokPemeriksaan.Items.Add("");
        cmbKelompokPemeriksaan.Items[i].Text = "";
        cmbKelompokPemeriksaan.Items[i].Value = "";
        i++;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                cmbKelompokPemeriksaan.Items.Add("");
                cmbKelompokPemeriksaan.Items[i].Text = dr["Nama"].ToString();
                cmbKelompokPemeriksaan.Items[i].Value = dr["Id"].ToString();
                if (dr["Id"].ToString() == KelompokPemeriksaanId)
                    cmbKelompokPemeriksaan.SelectedIndex = i;
                i++;
            }
        }
    }
    private void SelectLayanan(string LayananId)
    {
        cmbLayanan.Items.Clear();
        if (cmbKelompokPemeriksaan.SelectedIndex > 0)
        {
            SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
            myObj.KelompokPemeriksaanId = int.Parse(cmbKelompokPemeriksaan.SelectedItem.Value);
            DataTable dt = myObj.GetListByKelompokPemeriksaanId();
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
                    cmbLayanan.Items[i].Text = dr["Nama"].ToString();
                    cmbLayanan.Items[i].Value = dr["Id"].ToString();
                    if (dr["Id"].ToString() == LayananId)
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
    public void SetDataRawatJalan(string RawatJalanId, string PolilinikId, string KelasId)
    {
        txtRawatJalanId.Text = RawatJalanId;
        txtPolilinikId.Text = PolilinikId;
        txtKelasId.Text = KelasId;
    }
    public DataView GetData()
    {
        SIMRS.DataAccess.RS_RJLayanan objData = new SIMRS.DataAccess.RS_RJLayanan();
        objData.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        DataTable dt = objData.SelectAllWRawatJalanIdLogic();
        return dt.DefaultView;
    }
    private void EmptyFormEdit()
    {
        txtRJLayananId.Text = "0";
        SelectKelompokPemeriksaan("");
        SelectLayanan("-1");
        txtTarif.Text = "0";
        txtJumlahSatuan.Text = "1";
        txtDiscount.Text = "0";
        txtBiayaTambahan.Text = "0";
        txtJumlahTagihan.Text = "0";
        txtKeterangan.Text = "";
    }
    private void FillFormEdit(string RJLayananId)
    {
        SIMRS.DataAccess.RS_RJLayanan myObj = new SIMRS.DataAccess.RS_RJLayanan();
        myObj.RJLayananId = Int64.Parse(RJLayananId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtRJLayananId.Text = dr["RJLayananId"].ToString();
            SelectKelompokPemeriksaan(dr["KelompokPemeriksaanId"].ToString());
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
    private void FillFormView(string RJLayananId)
    {
        SIMRS.DataAccess.RS_RJLayanan myObj = new SIMRS.DataAccess.RS_RJLayanan();
        myObj.RJLayananId = Int64.Parse(RJLayananId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            lblRJLayananId.Text = dr["RJLayananId"].ToString();
            lblKelompokPemeriksaan.Text = dr["KelompokPemeriksaanNama"].ToString();
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

        SIMRS.DataAccess.RS_RJLayanan myObj = new SIMRS.DataAccess.RS_RJLayanan();
        myObj.RJLayananId = Int64.Parse(txtRJLayananId.Text);
        if (myObj.RJLayananId > 0)
            myObj.SelectOne();
        myObj.RawatJalanId = Int64.Parse(txtRawatJalanId.Text);
        myObj.JenisLayananId = 3;
        myObj.KelompokLayananId = 2;
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
        
        if (myObj.RJLayananId == 0)
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
    private void DeleteData(string RJLayananId)
    {
        SIMRS.DataAccess.RS_RJLayanan myObj = new SIMRS.DataAccess.RS_RJLayanan();
        myObj.RJLayananId = int.Parse(RJLayananId);
        myObj.SelectOne();
        /*
        if (myObj.StatusBayar == 0)
        {
        */
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
        /*
        }
        else
        {
            lblWarning.Text = Resources.GetString("", "WarAlreadyUsed"); 
        }
        */
    }

    private void GetTarif()
    {
        SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
        if (cmbLayanan.SelectedIndex > 0)
            myObj.Id = int.Parse(cmbLayanan.SelectedItem.Value);
        DataTable dt = myObj.GetTarifRIByLayananId(int.Parse(txtKelasId.Text));
        if (dt.Rows.Count > 0)
        {
            DataRow dr = dt.Rows[0];
            txtTarif.Text = dr["Tarif"].ToString() != "" ? ((Decimal)dr["Tarif"]).ToString("#,###.###.###.###") : "0";
            HitungJumlahTagihan();
        }
        else
        {
            txtTarif.Text = "0";
        }
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
    protected void cmbKelompokPemeriksaan_SelectedIndexChanged(object sender, EventArgs e)
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
            ((CheckBox)GV.Rows[i].FindControl("cbxRJLayananId")).Checked = ceck;
        }
    }

    protected void cbxRJLayananId_CheckedChanged(object sender, EventArgs e)
    {
        decimal total = 0;
        for (int i = 0; i < GV.Rows.Count; i++)
        {
            if (((CheckBox)GV.Rows[i].FindControl("cbxRJLayananId")).Checked == true) 
            {
                total += decimal.Parse(((Label)GV.Rows[i].FindControl("lblgTarif")).Text);
            }
        }
        TotalTagihan = total;
    }

    protected void GV_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
