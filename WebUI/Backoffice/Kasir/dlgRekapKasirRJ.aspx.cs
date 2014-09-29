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

public partial class Backoffice_Kasir_dlgRekapKasirRJ : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtTanggalMulai.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtTanggalSelesai.Text = txtTanggalMulai.Text;
            GetListPoliklinik();
            cmbPoliklinik.SelectedIndex = 0;
            GetLinkRekap();
        }
    }
    public void GetListPoliklinik()
    {
        string PoliklinikId = "";
        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        DataTable dt = myObj.GetList();
        cmbPoliklinik.Items.Clear();
        int i = 0;
        cmbPoliklinik.Items.Add("");
        cmbPoliklinik.Items[i].Text = "Semua Poliklinik";
        cmbPoliklinik.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPoliklinik.Items.Add("");
            cmbPoliklinik.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbPoliklinik.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == PoliklinikId)
                cmbPoliklinik.SelectedIndex = i;
            i++;
        }
    }
    private void GetLinkRekap()
    {
        string TanggalMulai = txtTanggalMulai.Text.Replace("/", "");
        string TanggalSelesai = txtTanggalSelesai.Text.Replace("/", "");
        string ModeRekap = cmbModelRekap.SelectedIndex == 0 ? "1": "2";
        string PoliklinikId = cmbPoliklinik.SelectedItem.Value;

        string UserId = cmbUser.Text == "User Aktif" ? Session["SIMRS.UserId"].ToString() : "0";
        /*
        string UserId="";
        if (cmbUser.SelectedItem.Text == "User Aktif")
            UserId = Session["SIMRS.UserId"].ToString();
        else
            UserId = "0";
        */
        
        btnPrint.Attributes.Remove("onclick");
        btnPrint.Attributes.Add("onclick", "displayPopup_scroll(2,'PrintRekapKasirRJ.aspx?TanggalMulai=" + TanggalMulai + "&TanggalSelesai=" + TanggalSelesai + "&ModeRekap=" + ModeRekap + "&PoliklinikId=" + PoliklinikId + "&UserId="+ UserId +"','Rekap',600,800,(version4 ? event : null));");
        
    }
    protected void txtTanggalMulai_TextChanged(object sender, EventArgs e)
    {
        GetLinkRekap();
    }
    protected void txtTanggalSelesai_TextChanged(object sender, EventArgs e)
    {
        GetLinkRekap();
    }
    protected void rbtAllData_CheckedChanged(object sender, EventArgs e)
    {
        GetLinkRekap();
    }
    protected void rbtPoliklinik_CheckedChanged(object sender, EventArgs e)
    {
        GetLinkRekap();
    }
    protected void cmbPoliklinik_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetLinkRekap();
    }
    protected void cmbModelRekap_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (cmbModelRekap.SelectedIndex == 1)
        {
            cmbPoliklinik.Visible = true;
        }
        else
        {
            cmbPoliklinik.Visible = false;
        }
        GetLinkRekap();
    }

    protected void cmbUser_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetLinkRekap();
    }
}
