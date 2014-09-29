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

public partial class Backoffice_Controls_EditRekamMedisRJ : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request["RawatJalanId"] != null && Request["RawatJalanId"] != "")
            {
                FillDataRawatJalan(int.Parse(Request["RawatJalanId"]));
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
    public void FillDataRawatJalan(Int64 RawatJalanId)
    {
        SIMRS.DataAccess.RS_RawatJalan myObj = new SIMRS.DataAccess.RS_RawatJalan();
        myObj.RawatJalanId = RawatJalanId;
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            txtRegistrasiId.Value = row["RegistrasiId"].ToString();
            txtRawatJalanId.Value = row["RawatJalanId"].ToString();
            txtPasienId.Value = row["PasienId"].ToString();
            txtStatusRawatJalan.Value = row["StatusRawatJalan"].ToString();
            lblNoRMHeader.Text = row["NoRM"].ToString();
            lblNamaPasienHeader.Text = row["Nama"].ToString();
            txtTanggalBerobat.Value = ((DateTime)row["TanggalBerobat"]).ToString("dd/MM/yyyy");
            txtJamPraktek.Value = row["JamPraktek"].ToString();
            lblNoRegistrasi.Text = row["NoRegistrasi"].ToString();
            lblTanggalBerobat.Text = txtTanggalBerobat.Value;
            lblPoliklinik.Text = row["PoliklinikNama"].ToString();
            lblDokter.Text = row["DokterNama"].ToString();
            lblDokterId.Text = row["DokterId"].ToString();

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
            txtTanggalPeriksa.Text = ((DateTime)row["TanggalPeriksa"]).ToString("dd/MM/yyyy");
            txtJamPeriksa.Text = row["JamPeriksa"].ToString();
            txtKeluhanUtama.Text = row["KeluhanUtama"].ToString();
            txtDiagnosa.Text = row["Diagnosa"].ToString();
            txtTindakanMedis.Text = row["TindakanMedis"].ToString();
            txtObat.Text = row["Obat"].ToString();
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
        txtTanggalPeriksa.Text = txtTanggalBerobat.Value;
        txtJamPeriksa.Text = txtJamPraktek.Value;
        txtKeluhanUtama.Text = "";
        txtDiagnosa.Text = "";
        txtTindakanMedis.Text = "";
        txtObat.Text = "";
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
        if (lblDokterId.Text != "")
            myObj.DokterId = int.Parse(lblDokterId.Text);
        myObj.TanggalPeriksa = DateTime.Parse(txtTanggalPeriksa.Text);
        myObj.JamPeriksa = txtJamPeriksa.Text;
        myObj.KeluhanUtama = txtKeluhanUtama.Text;
        myObj.Diagnosa = txtDiagnosa.Text;
        myObj.TindakanMedis = txtTindakanMedis.Text;
        myObj.Obat = txtObat.Text;
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
