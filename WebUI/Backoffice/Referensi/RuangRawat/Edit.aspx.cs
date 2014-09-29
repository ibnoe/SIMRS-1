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

public partial class Backoffice_Referensi_RuangRawat_Edit : System.Web.UI.Page
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
            if (Session["RuangRawatManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }

    }

    public void GetListRuang(string RuangId)
    {
        SIMRS.DataAccess.RS_Ruang myObj = new SIMRS.DataAccess.RS_Ruang();
        DataTable dt = myObj.GetList();
        cmbRuang.Items.Clear();
        int i = 0;
        cmbRuang.Items.Add("");
        cmbRuang.Items[i].Text = "";
        cmbRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbRuang.Items.Add("");
            cmbRuang.Items[i].Text = "[" + dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbRuang.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == RuangId)
            {
                cmbRuang.SelectedIndex = i;
            }
            i++;
        }
    }

    public void GetListKelas(string KelasId)
    {
        SIMRS.DataAccess.RS_Kelas myObj = new SIMRS.DataAccess.RS_Kelas();
        DataTable dt = myObj.GetList();
        cmbKelas.Items.Clear();
        int i = 0;
        cmbKelas.Items.Add("");
        cmbKelas.Items[i].Text = "";
        cmbKelas.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelas.Items.Add("");
            cmbKelas.Items[i].Text = dr["Nama"].ToString();
            cmbKelas.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelasId)
            {
                cmbKelas.SelectedIndex = i;
            }
            i++;
        }
    }

    public void Draw()
    {
        try
        {
            string RuangRawatId = Request.QueryString["RuangRawatId"].ToString();
            SIMRS.DataAccess.RS_RuangRawat myObj = new SIMRS.DataAccess.RS_RuangRawat();
            myObj.RuangRawatId = Convert.ToInt32(RuangRawatId);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtRuangRawatId.Text = row["RuangRawatId"].ToString();
                GetListRuang(row["RuangId"].ToString());
                GetListKelas(row["KelasId"].ToString());
                txtNomorRuang.Text = row["NomorRuang"].ToString();
                txtTempatTidurTotal.Value = row["TempatTidurTotal"].ToString();
                txtTempatTidurIsi.Value = row["TempatTidurIsi"].ToString();
                txtTempatTidurKosong.Value = row["TempatTidurKosong"].ToString();
                txtKeterangan.Text = row["Keterangan"].ToString();
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.RuangRawat::Edit::Draw::Error occured.", ex);
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

        SIMRS.DataAccess.RS_RuangRawat myObj = new SIMRS.DataAccess.RS_RuangRawat();
        myObj.RuangRawatId = int.Parse(txtRuangRawatId.Text);
        myObj.SelectOne();
        if (cmbRuang.SelectedIndex > 0)
            myObj.RuangId = int.Parse(cmbRuang.SelectedItem.Value);
        if (cmbKelas.SelectedIndex > 0)
            myObj.KelasId = int.Parse(cmbKelas.SelectedItem.Value);
        myObj.NomorRuang = txtNomorRuang.Text;
        myObj.Keterangan = txtKeterangan.Text;

        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistRuangRawat");
            return;
        }
        else
        {
            myObj.Update();
            HttpRuntime.Cache.Remove("SIMRS_RuangRawat");
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
