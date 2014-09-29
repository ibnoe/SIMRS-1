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

public partial class Backoffice_Referensi_JadwalDokter_Edit : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["SIMRS.UserId"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
            }
            int UserId = (int)Session["SIMRS.UserId"];
            if (Session["JadwalDokterManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }
    }
    public void GetListPoliklinik(string PoliklinikId)
    {
        SIMRS.DataAccess.RS_Poliklinik myObj = new SIMRS.DataAccess.RS_Poliklinik();
        DataTable dt = myObj.GetList();
        cmbPoliklinik.Items.Clear();
        int i = 0;
        cmbPoliklinik.Items.Add("");
        cmbPoliklinik.Items[i].Text = "";
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
    public void GetListHari(string HariId)
    {
        SIMRS.DataAccess.RS_Hari myObj = new SIMRS.DataAccess.RS_Hari();
        DataTable dt = myObj.GetList();
        cmbHari.Items.Clear();
        int i = 0;
        cmbHari.Items.Add("");
        cmbHari.Items[i].Text = "";
        cmbHari.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbHari.Items.Add("");
            cmbHari.Items[i].Text = dr["Nama"].ToString();
            cmbHari.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == HariId)
                cmbHari.SelectedIndex = i;
            i++;
        }
    }
    public void GetListDokter(string DokterId)
    {
        SIMRS.DataAccess.RS_Dokter myObj = new SIMRS.DataAccess.RS_Dokter();
        DataTable dt = myObj.GetList();
        cmbDokter.Items.Clear();
        int i = 0;
        cmbDokter.Items.Add("");
        cmbDokter.Items[i].Text = "";
        cmbDokter.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbDokter.Items.Add("");
            cmbDokter.Items[i].Text = dr["Nama"].ToString() + " [" + dr["SpesialisNama"].ToString() + "]";
            cmbDokter.Items[i].Value = dr["DokterId"].ToString();
            if (dr["DokterId"].ToString() == DokterId)
                cmbDokter.SelectedIndex = i;
            i++;
        }
    }

    public void Draw()
    {
        try
        {
            string JadwalDokterId = Request.QueryString["JadwalDokterId"].ToString();
            SIMRS.DataAccess.RS_JadwalDokter myObj = new SIMRS.DataAccess.RS_JadwalDokter();
            myObj.JadwalDokterId = Convert.ToInt32(JadwalDokterId);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtJadwalDokterId.Text = row["JadwalDokterId"].ToString();
                GetListPoliklinik(row["PoliklinikId"].ToString());
                GetListHari(row["HariId"].ToString());
                GetListDokter(row["DokterId"].ToString());
                //JamMulai
                txtJamMulai.Text = row["JamMulai"].ToString();
                string[] jamMulai = txtJamMulai.Text.Split(':');
                cmbJamMulai.SelectedValue = jamMulai[0];
                cmbMenitMulai.SelectedValue = jamMulai[1];
                //JamSelesai
                txtJamSelesai.Text = row["JamSelesai"].ToString();
                string[] jamSelesai = txtJamSelesai.Text.Split(':');
                if (jamSelesai.Length > 1)
                {
                    cmbJamSelesai.SelectedValue = jamSelesai[0];
                    cmbMenitSelesai.SelectedValue = jamSelesai[1];
                }
                //JamPraktek
                txtJamPraktek.Text = row["JamPraktek"].ToString();
                txtKeterangan.Text = row["Keterangan"].ToString();
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.JadwalDokter::Edit::Draw::Error occured.", ex);
        }

    }


    /// <summary>
    /// This function is responsible for save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnSave(Object sender, EventArgs e)
    {
        if (Session["SIMRS.UserId"] == null)
        {
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }
        int UserId = (int)Session["SIMRS.UserId"];
        if (!Page.IsValid)
        {
            return;
        }

        SIMRS.DataAccess.RS_JadwalDokter myObj = new SIMRS.DataAccess.RS_JadwalDokter();
        myObj.JadwalDokterId = int.Parse(txtJadwalDokterId.Text);
        myObj.SelectOne();
        if (cmbPoliklinik.SelectedIndex > 0)
            myObj.PoliklinikId = int.Parse(cmbPoliklinik.SelectedItem.Value);
        if (cmbHari.SelectedIndex > 0)
            myObj.HariId = int.Parse(cmbHari.SelectedItem.Value);
        if (cmbDokter.SelectedIndex > 0)
            myObj.DokterId = int.Parse(cmbDokter.SelectedItem.Value);
        txtJamMulai.Text = cmbJamMulai.SelectedItem.Value + ":" + cmbMenitMulai.SelectedItem.Value;
        txtJamSelesai.Text = cmbJamSelesai.SelectedItem.Value + ":" + cmbMenitSelesai.SelectedItem.Value;
        txtJamSelesai.Text = txtJamSelesai.Text == "00:00" ? "Selesai" : txtJamSelesai.Text;
        myObj.JamMulai = txtJamMulai.Text;
        myObj.JamSelesai = txtJamSelesai.Text;
        myObj.JamPraktek = txtJamMulai.Text + " s/d " + txtJamSelesai.Text;
        myObj.Keterangan = txtKeterangan.Text;
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistJadwalDokter");
            return;
        }
        else
        {
            myObj.Update();
            myObj.UpdateView();
            HttpRuntime.Cache.Remove("SIMRS_JadwalDokter");
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
        }
    }
    /// <summary>
    /// This function is responsible for cancel save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
    }
}
