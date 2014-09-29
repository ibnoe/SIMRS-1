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

public partial class Backoffice_Controls_EditRekamMedisLAB : System.Web.UI.UserControl
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
    private void UpdateHari()
    {
        string hari = DateTime.Parse(txtTanggalPeriksa.Text).DayOfWeek.ToString();
        switch (hari)
        {
            case "Monday":
                txtHari.Text = "1";
                break;
            case "Tuesday":
                txtHari.Text = "2";
                break;
            case "Wednesday":
                txtHari.Text = "3";
                break;
            case "Thursday":
                txtHari.Text = "4";
                break;
            case "Friday":
                txtHari.Text = "5";
                break;
            case "Saturday":
                txtHari.Text = "6";
                break;
            case "Sunday":
                txtHari.Text = "7";
                break;
        }
    }
    protected void txtTanggalPeriksa_TextChanged(object sender, EventArgs e)
    {
        UpdateHari();
        GetListDokter("");
    }

    public void GetListDokter(string DokterId)
    {
        SIMRS.DataAccess.RS_JadwalDokter myObj = new SIMRS.DataAccess.RS_JadwalDokter();
        myObj.PoliklinikId = 42;//Poliklinik Laboratorium
        if (txtHari.Text != "")
            myObj.HariId = int.Parse(txtHari.Text);
        DataTable dt = myObj.GetListDokterByPoliklinikIdAndHariId();
        cmbDokter.Items.Clear();
        int i = 0;
        cmbDokter.Items.Add("");
        cmbDokter.Items[i].Text = "";
        cmbDokter.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbDokter.Items.Add("");
            cmbDokter.Items[i].Text = dr["DokterNama"].ToString();
            cmbDokter.Items[i].Value = dr["DokterId"].ToString();
            if (dr["DokterId"].ToString() == DokterId)
                cmbDokter.SelectedIndex = i;
            i++;
        }
        UpdateHari();
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

            txtTanggalPeriksa.Text = ((DateTime)row["TanggalBerobat"]).ToString("dd/MM/yyyy");
            UpdateHari();
            txtJamPeriksa.Text = row["JamPraktek"].ToString();
            GetListDokter(row["DokterId"].ToString());
            
            GetDataRekamMedis(int.Parse(txtRegistrasiId.Value));
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
            UpdateHari();
            txtJamPeriksa.Text = row["JamPeriksa"].ToString();
            GetListDokter(row["DokterId"].ToString());
            txtDiagnosa.Text = row["Diagnosa"].ToString();
            txtKeteranganLain.Text = row["Keterangan"].ToString();
        }
        else
        {
            EmptyFormRekamMedis();
        }
    }
    public void EmptyFormRekamMedis()
    {
        //txtTanggalPeriksa.Text = txtTanggalBerobat.Value;
        //txtJamPeriksa.Text = txtJamPraktek.Value;
        txtDiagnosa.Text = "";
        txtKeteranganLain.Text = "";
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
        if (cmbDokter.SelectedIndex > 0)
            myObj.DokterId = int.Parse(cmbDokter.SelectedItem.Value);
        myObj.TanggalPeriksa = DateTime.Parse(txtTanggalPeriksa.Text);
        myObj.JamPeriksa = txtJamPeriksa.Text;
        //myObj.DokterId = 
        myObj.Diagnosa = txtDiagnosa.Text;
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
        return result;        
    }

}
