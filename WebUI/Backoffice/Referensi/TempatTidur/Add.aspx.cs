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

public partial class Backoffice_Referensi_TempatTidur_Add : System.Web.UI.Page
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
            if (Session["TempatTidurManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListKelas();
            GetListRuang();
            GetListNomorRuang();
        }

    }

    public void GetListRuang()
    {
        string RuangId = "";
        if (Request.QueryString["RuangId"] != null)
            RuangId = Request.QueryString["RuangId"].ToString();

        int kelasId = 0;
        if (cmbKelas.SelectedIndex > 0)
            kelasId = int.Parse(cmbKelas.SelectedItem.Value);               
        SIMRS.DataAccess.RS_Ruang myObj = new SIMRS.DataAccess.RS_Ruang();
        DataTable dt = myObj.GetListByKelasId(kelasId);
        cmbRuang.Items.Clear();
        int i = 0;
        cmbRuang.Items.Add("");
        cmbRuang.Items[i].Text = "";
        cmbRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbRuang.Items.Add("");
            cmbRuang.Items[i].Text = "["+dr["Kode"].ToString() + "] " + dr["Nama"].ToString();
            cmbRuang.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == RuangId)
            {
                cmbRuang.SelectedIndex = i;
            }
            i++;
        }
    }
    public void GetListKelas()
    {
        string KelasId = "";
        if (Request.QueryString["KelasId"] != null)
            KelasId = Request.QueryString["KelasId"].ToString();

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
    public void GetListNomorRuang()
    {
        string NomorRuang = "";
        if (Request.QueryString["NomorRuang"] != null)
            NomorRuang = Request.QueryString["NomorRuang"].ToString();

        SIMRS.DataAccess.RS_RuangRawat myObj = new SIMRS.DataAccess.RS_RuangRawat();
        if (cmbKelas.SelectedIndex > 0)
            myObj.KelasId = int.Parse(cmbKelas.SelectedItem.Value);
        if (cmbRuang.SelectedIndex > 0)
            myObj.RuangId = int.Parse(cmbRuang.SelectedItem.Value);
        DataTable dt = myObj.GetListNomorRuang();
        cmbNoRuang.Items.Clear();
        int i = 0;
        cmbNoRuang.Items.Add("");
        cmbNoRuang.Items[i].Text = "";
        cmbNoRuang.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbNoRuang.Items.Add("");
            cmbNoRuang.Items[i].Text = dr["NomorRuang"].ToString();
            cmbNoRuang.Items[i].Value = dr["NomorRuang"].ToString();
            if (dr["NomorRuang"].ToString() == NomorRuang)
            {
                cmbNoRuang.SelectedIndex = i;
            }
            i++;
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

        SIMRS.DataAccess.RS_RuangRawat myRR = new SIMRS.DataAccess.RS_RuangRawat();
        if (cmbKelas.SelectedIndex > 0)
            myRR.KelasId = int.Parse(cmbKelas.SelectedItem.Value);
        if (cmbRuang.SelectedIndex > 0)
            myRR.RuangId = int.Parse(cmbRuang.SelectedItem.Value);
        if (cmbNoRuang.SelectedIndex > 0)
            myRR.NomorRuang = cmbNoRuang.SelectedItem.Value;
        
        SIMRS.DataAccess.RS_TempatTidur myObj = new SIMRS.DataAccess.RS_TempatTidur();
        myObj.TempatTidurId = 0;
        myObj.RuangRawatId = myRR.GetRuangRawatId();
        myObj.Kode = txtNomorTempat.Text;
        myObj.NomorTempat = txtNomorTempat.Text;
        myObj.Keterangan = txtKeterangan.Text;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistTempatTidur");
            return;
        }
        else
        {
            myObj.Insert();
            HttpRuntime.Cache.Remove("SIMRS_TempatTidur");
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
    protected void cmbKelas_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListRuang();
    }
    protected void cmbRuang_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetListNomorRuang();
    }
}
