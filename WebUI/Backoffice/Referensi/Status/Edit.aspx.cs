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

public partial class Backoffice_Referensi_Status_Edit : System.Web.UI.Page
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
            if (Session["StatusManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }

    }

    public void GetListKelompokStatus(string KelompokStatusId)
    {
        SIMRS.DataAccess.RS_KelompokStatus myObj = new SIMRS.DataAccess.RS_KelompokStatus();
        DataTable dt = myObj.GetList();
        cmbKelompokStatus.Items.Clear();
        int i = 0;
        cmbKelompokStatus.Items.Add("");
        cmbKelompokStatus.Items[i].Text = "";
        cmbKelompokStatus.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelompokStatus.Items.Add("");
            cmbKelompokStatus.Items[i].Text = dr["Nama"].ToString();
            cmbKelompokStatus.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelompokStatusId)
                cmbKelompokStatus.SelectedIndex = i;
            i++;
        }
    }
    public void GetListJenisPembayaran(string JenisPembayaranId)
    {
        SIMRS.DataAccess.RS_JenisPembayaran myObj = new SIMRS.DataAccess.RS_JenisPembayaran();
        DataTable dt = myObj.GetList();
        cmbJenisPembayaran.Items.Clear();
        int i = 0;
        cmbJenisPembayaran.Items.Add("");
        cmbJenisPembayaran.Items[i].Text = "";
        cmbJenisPembayaran.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbJenisPembayaran.Items.Add("");
            cmbJenisPembayaran.Items[i].Text = dr["Nama"].ToString();
            cmbJenisPembayaran.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisPembayaranId)
                cmbJenisPembayaran.SelectedIndex = i;
            i++;
        }
    }
    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_Status myObj = new SIMRS.DataAccess.RS_Status();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                txtKode.Text = row["Kode"].ToString();
                txtNama.Text = row["Nama"].ToString();
                GetListKelompokStatus(row["KelompokStatusId"].ToString());
                GetListJenisPembayaran(row["JenisPembayaranId"].ToString());
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
            throw new Exception("Backoffice.Referensi.Status::Edit::Draw::Error occured.", ex);
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

        SIMRS.DataAccess.RS_Status myObj = new SIMRS.DataAccess.RS_Status();
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        if (cmbKelompokStatus.SelectedIndex > 0)
            myObj.KelompokStatusId = int.Parse(cmbKelompokStatus.SelectedItem.Value);
        if (cmbJenisPembayaran.SelectedIndex > 0)
            myObj.JenisPembayaranId = int.Parse(cmbJenisPembayaran.SelectedItem.Value);
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistStatus");
            return;
        }
        else
        {
            myObj.Update();
            HttpRuntime.Cache.Remove("SIMRS_Status");
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
