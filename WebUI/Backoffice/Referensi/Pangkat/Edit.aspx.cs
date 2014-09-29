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
public partial class Backoffice_Referensi_Pangkat_Edit : System.Web.UI.Page
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
            if (Session["PangkatManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }

    }
    public void GetListStatus(string StatusId)
    {
        SIMRS.DataAccess.RS_Status myObj = new SIMRS.DataAccess.RS_Status();
        DataTable dt = myObj.GetList();
        cmbStatus.Items.Clear();
        int i = 0;
        cmbStatus.Items.Add("");
        cmbStatus.Items[i].Text = "";
        cmbStatus.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbStatus.Items.Add("");
            cmbStatus.Items[i].Text = dr["Nama"].ToString();
            cmbStatus.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == StatusId)
                cmbStatus.SelectedIndex = i;
            i++;
        }
    }
    public void GetListKelompokPangkat(string KelompokPangkatId)
    {
        SIMRS.DataAccess.RS_KelompokPangkat myObj = new SIMRS.DataAccess.RS_KelompokPangkat();
        DataTable dt = myObj.GetList();
        cmbKelompokPangkat.Items.Clear();
        int i = 0;
        cmbKelompokPangkat.Items.Add("");
        cmbKelompokPangkat.Items[i].Text = "";
        cmbKelompokPangkat.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelompokPangkat.Items.Add("");
            cmbKelompokPangkat.Items[i].Text = dr["Nama"].ToString();
            cmbKelompokPangkat.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelompokPangkatId)
                cmbKelompokPangkat.SelectedIndex = i;
            i++;
        }
    }
    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                GetListStatus(row["StatusId"].ToString());
                txtKode.Text = row["Kode"].ToString();
                txtNama.Text = row["Nama"].ToString();
                GetListKelompokPangkat(row["KelompokPangkatId"].ToString());
                txtKeterangan.Text = row["Keterangan"].ToString();
                if ((bool)row["Published"])
                    rbtYes.Checked = true;
                else
                    rbtNo.Checked = true;
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.Pangkat::Edit::Draw::Error occured.", ex);
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

        SIMRS.DataAccess.RS_Pangkat myObj = new SIMRS.DataAccess.RS_Pangkat();
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        if (cmbStatus.SelectedIndex > 0)
            myObj.StatusId = int.Parse(cmbStatus.SelectedItem.Value);
        else
            myObj.StatusId = SqlInt32.Null;
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        if (cmbKelompokPangkat.SelectedIndex > 0)
            myObj.KelompokPangkatId = int.Parse(cmbKelompokPangkat.SelectedItem.Value);
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistPangkat");
            return;
        }
        else
        {
            myObj.Update();
            HttpRuntime.Cache.Remove("SIMRS_Pangkat");
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
