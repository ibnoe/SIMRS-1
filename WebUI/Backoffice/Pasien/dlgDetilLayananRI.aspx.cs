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

public partial class Backoffice_Pasien_dlgDetilLayananRI : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["RawatInapId"] != null && Request.QueryString["RawatInapId"].ToString() != "")
        {
            DataSet ds = new DataSet();
            if (!Page.IsPostBack)
            {
                string RawatInapId = Request.QueryString["RawatInapId"].ToString();
                GetData(RawatInapId);
                PopulateRuangRawat(Request.QueryString["RawatInapId"].ToString());
            }
            //else
            //{
                
            //}
            
        }
    }
    private void PopulateRuangRawat(string RawatInapaId)
    {
        //string TempatInapId = "";
        SIMRS.DataAccess.RS_TempatInap myObj = new SIMRS.DataAccess.RS_TempatInap();
        myObj.RawatInapId = Int64.Parse(RawatInapaId);
        DataTable dt = myObj.SelectAllWRawatInapIdLogic();
        cmbRuangRawat.Items.Clear();
        int i = 0;
        if (dt.Rows.Count > 0)
        {
            foreach (DataRow dr in dt.Rows)
            {
                cmbRuangRawat.Items.Add("");
                cmbRuangRawat.Items[i].Text = dr["KelasNama"].ToString() + " - " + dr["RuangNama"].ToString() + " - " + dr["NomorRuang"].ToString();
                cmbRuangRawat.Items[i].Value = dr["TempatInapId"].ToString();
                //if (dr["TempatInapId"].ToString() == TempatInapId)
                //    cmbRuangRawat.SelectedIndex = i;
                i++;
            }
        }
    }

    public void GetData(string RawatInapId)
    {
        SIMRS.DataAccess.RS_RawatInap myObj = new SIMRS.DataAccess.RS_RawatInap();
        myObj.RawatInapId = Int64.Parse(RawatInapId);
        DataTable dt = myObj.SelectOne();
        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            HFRawatInapId.Value = RawatInapId;    
            lblNoRM.Text = row["NoRM"].ToString();
            lblNamaPasienHeader.Text = row["Nama"].ToString();
            lblUmurPasienHeader.Text = row["Umur"].ToString() != "" ? " / " + row["Umur"].ToString() : "";
            lblStatusPasienHeader.Text = row["StatusNama"].ToString();

        }
    }
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        Response.Redirect("DetilLayananRI.aspx?RawatInapId=" + HFRawatInapId.Value+"&TempatInapId="+cmbRuangRawat.SelectedItem.Value);
    }
}
