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

public partial class Backoffice_Controls_EditRekamMedisRI : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["RawatInapId"] != null && Request["RawatInapId"] != "")
            {
                FillDataRawatInap(int.Parse(Request["RawatInapId"]));
            }
        }
    }
    public void GetListJenisPenyakit()
    {
        string JenisPenyakitId = "";
        SIMRS.DataAccess.RS_JenisPenyakit myObj = new SIMRS.DataAccess.RS_JenisPenyakit();
        DataTable dt = myObj.GetList();
        lbJenisPenyakitAvaliable.Items.Clear();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            lbJenisPenyakitAvaliable.Items.Add("");
            lbJenisPenyakitAvaliable.Items[i].Text = dr["Kode"].ToString() + " " + dr["Nama"].ToString();
            lbJenisPenyakitAvaliable.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisPenyakitId)
            {
                lbJenisPenyakitAvaliable.SelectedIndex = i;
            }
            i++;

        }
    }
    public void GetListStatusRM(string StatusRMId)
    {
        SIMRS.DataAccess.RS_StatusRM myObj = new SIMRS.DataAccess.RS_StatusRM();
        myObj.JenisPoliklinikId = 3;//Rawat Inap
        DataTable dt = myObj.GetListWJenisPoliklinikId();
        cmbStatusRM.Items.Clear();
        int i = 0;
        cmbStatusRM.Items.Add("");
        cmbStatusRM.Items[i].Text = "";
        cmbStatusRM.Items[i].Value = "";
        i++;  
        foreach (DataRow dr in dt.Rows)
        {
            cmbStatusRM.Items.Add("");
            cmbStatusRM.Items[i].Text = dr["Nama"].ToString();
            cmbStatusRM.Items[i].Value = dr["StatusRMId"].ToString();
            if (dr["StatusRMId"].ToString() == StatusRMId)
            {
                cmbStatusRM.SelectedIndex = i;
            }
            i++;

        }
    }
    public void FillDataRawatInap(Int64 RawatInapId)
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = RawatInapId;
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtRegistrasiId.Value = row["RegistrasiId"].ToString();
            txtRawatInapId.Value = row["RawatInapId"].ToString();
            txtPasienId.Value = row["PasienId"].ToString();
            txtStatusRawatInap.Value = row["StatusRawatInap"].ToString();
            lblNoRMHeader.Text = row["NoRM"].ToString();
            lblNamaPasienHeader.Text = row["Nama"].ToString();
            txtTanggalMasuk.Value = ((DateTime)row["TanggalMasuk"]).ToString("dd/MM/yyyy");
            txtJamMasuk.Value = ((DateTime)row["TanggalMasuk"]).ToString("HH:mm");
            lblNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            lblTanggalMasuk.Text = ((DateTime)row["TanggalMasuk"]).ToString("dd/MM/yyyy HH:mm");
            lblRuangRawat.Text = row["KelasNama"].ToString() + " - " + row["RuangNama"].ToString() + " - " + row["NomorRuang"].ToString();
            lblDokter.Text = row["DokterNama"].ToString();

            GetDataRekamMedis(int.Parse(txtRegistrasiId.Value));
            GetListJenisPenyakit();
        }
    }

    public void GetDataRekamMedis(Int64 RegistrasiId)
    {
        SIMRS.DataAccess.RS_RM myObj = new SIMRS.DataAccess.RS_RM();
        myObj.RegistrasiId = RegistrasiId;
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtTanggalKeluar.Text = ((DateTime)row["TanggalKeluar"]).ToString("dd/MM/yyyy");
            txtJamKeluar.Text = ((DateTime)row["TanggalKeluar"]).ToString("HH:mm");
            txtKeluhanUtama.Text = row["KeluhanUtama"].ToString();
            txtKeluhanTambahan.Text = row["KeluhanTambahan"].ToString();
            txtDiagnosa.Text = row["Diagnosa"].ToString();
            txtTindakanMedis.Text = row["TindakanMedis"].ToString();
            txtObat.Text = row["Obat"].ToString();
            GetListStatusRM(row["StatusRMId"].ToString());
            txtKeteranganStatusRM.Text = row["KeteranganStatus"].ToString();
            txtKeteranganLain.Text = row["Keterangan"].ToString();
            SIMRS.DataAccess.RS_RMJenisPenyakit myPenyakit = new SIMRS.DataAccess.RS_RMJenisPenyakit();
            myPenyakit.RegistrasiId = RegistrasiId;
            DataTable dtPenyakit = myPenyakit.SelectAllWRegistrasiIdLogic();
            if (dtPenyakit.Rows.Count > 0)
            {
                int i = 0;
                foreach (DataRow dr in dtPenyakit.Rows)
                {
                    lbJenisPenyakit.Items.Add("");
                    lbJenisPenyakit.Items[i].Value = dr["JenisPenyakitId"].ToString();
                    lbJenisPenyakit.Items[i].Text = dr["JenisPenyakitKode"].ToString() + ". " + dr["JenisPenyakitNama"].ToString();
                    i++;
                }
            }
        }
        else
        {
            EmptyFormRekamMedis();
        }
    }
    public void EmptyFormRekamMedis()
    {
        txtTanggalKeluar.Text = "";
        txtJamKeluar.Text = "";
        txtKeluhanUtama.Text = "";
        txtKeluhanTambahan.Text = "";
        txtDiagnosa.Text = "";
        txtTindakanMedis.Text = "";
        txtObat.Text = "";
        GetListStatusRM("");
        txtKeteranganStatusRM.Text = "";
        txtKeteranganLain.Text = "";
        lbJenisPenyakit.Items.Clear();
    }


    protected void btnAddJenisPenyakit_Click(object sender, EventArgs e)
    {
        if (lbJenisPenyakitAvaliable.SelectedIndex != -1)
        {
            int i = lbJenisPenyakit.Items.Count;
            bool exist = false;
            for (int j = 0; j < i; j++)
            {
                if (lbJenisPenyakit.Items[j].Value == lbJenisPenyakitAvaliable.SelectedItem.Value)
                {
                    exist = true;
                    break;
                }
            }
            if (!exist)
            {
                lbJenisPenyakit.Items.Add("");
                lbJenisPenyakit.Items[i].Value = lbJenisPenyakitAvaliable.SelectedItem.Value;
                lbJenisPenyakit.Items[i].Text = lbJenisPenyakitAvaliable.SelectedItem.Text;
            }
            lbJenisPenyakitAvaliable.SelectedIndex = -1;
        }
    }
    protected void btnRemoveJenisPenyakit_Click(object sender, EventArgs e)
    {
        if (lbJenisPenyakit.SelectedIndex != -1)
        {
            lbJenisPenyakit.Items.RemoveAt(lbJenisPenyakit.SelectedIndex);
        }
    }
    public bool OnSave()
    {
        bool result = false;
        lblError.Text = "";
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        int UserId = (int)Session["SIMRS.UserId"];
        if (!Page.IsValid)
        {
            return false;
        }
        SIMRS.DataAccess.RS_RM myObj = new SIMRS.DataAccess.RS_RM();
        myObj.RegistrasiId = Int64.Parse(txtRegistrasiId.Value);
        DataTable dtRM = myObj.SelectOne();
        DateTime TanggalMasuk = DateTime.Parse(txtTanggalMasuk.Value);
        TanggalMasuk = TanggalMasuk.AddHours(double.Parse(txtJamMasuk.Value.Substring(0, 2)));
        TanggalMasuk = TanggalMasuk.AddMinutes(double.Parse(txtJamMasuk.Value.Substring(3, 2)));
        myObj.TanggalMasuk = TanggalMasuk;

        DateTime TanggalKeluar = DateTime.Parse(txtTanggalKeluar.Text);
        TanggalKeluar = TanggalKeluar.AddHours(double.Parse(txtJamKeluar.Text.Substring(0, 2)));
        TanggalKeluar = TanggalKeluar.AddMinutes(double.Parse(txtJamKeluar.Text.Substring(3, 2)));
        myObj.TanggalKeluar = TanggalKeluar;
        myObj.KeluhanUtama = txtKeluhanUtama.Text;
        myObj.KeluhanTambahan = txtKeluhanTambahan.Text;
        myObj.Diagnosa = txtDiagnosa.Text;
        myObj.TindakanMedis = txtTindakanMedis.Text;
        myObj.Obat = txtObat.Text;
        if (cmbStatusRM.SelectedIndex> 0)
            myObj.StatusRMId = int.Parse(cmbStatusRM.SelectedItem.Value);
        myObj.KeteranganStatus = txtKeteranganStatusRM.Text;
        myObj.Keterangan = txtKeteranganLain.Text;
        if (dtRM.Rows.Count == 0)
        {
            myObj.CreatedBy = UserId;
            myObj.CreatedDate = DateTime.Now;
            result = myObj.Insert();
        }
        else {
            myObj.ModifiedBy = UserId;
            myObj.ModifiedDate = DateTime.Now;
            result = myObj.Update();
        }
        
        if (lbJenisPenyakit.Items.Count > 0)
        {
            SIMRS.DataAccess.RS_RMJenisPenyakit myPenyakit = new SIMRS.DataAccess.RS_RMJenisPenyakit();
            myPenyakit.RegistrasiId = Int64.Parse(txtRegistrasiId.Value);
            myPenyakit.DeleteAllWRegistrasiIdLogic();
            for (int i = 0; i < lbJenisPenyakit.Items.Count; i++)
            {
                myPenyakit.JenisPenyakitId = int.Parse(lbJenisPenyakit.Items[i].Value);
                result = myPenyakit.Insert();
            }
        }
        return result;        
    }

}
