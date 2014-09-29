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

public partial class Backoffice_Referensi_KabupatenKota_Add : System.Web.UI.Page
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
            if (Session["KabupatenKotaManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            GetListPropinsi();
        }

    }

    public void GetListPropinsi()
    {
        string propId = "";
        if (Request.QueryString["propId"] != null)
            propId = Request.QueryString["propId"].ToString();

        BkNet.DataAccess.Propinsi myObj = new BkNet.DataAccess.Propinsi();
        DataTable dt = myObj.GetList();
        cmbPropinsi.Items.Clear();
        int i = 0;
        cmbPropinsi.Items.Add("");
        cmbPropinsi.Items[i].Text = "";
        cmbPropinsi.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbPropinsi.Items.Add("");
            cmbPropinsi.Items[i].Text = dr["Kode"].ToString() + ". [" + dr["Nama"].ToString() + "]";
            cmbPropinsi.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == propId)
            {
                txtKodeProp.Value = dr["Kode"].ToString();
                cmbPropinsi.SelectedIndex = i;
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

        BkNet.DataAccess.KabupatenKota myObj = new BkNet.DataAccess.KabupatenKota();
        myObj.Id = 0;
        myObj.PropinsiId = int.Parse(cmbPropinsi.SelectedValue);
        myObj.Kode = txtKodeProp.Value + "." + txtKodeKab.Value;
        myObj.Nama = txtNama.Text;
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        myObj.CreatedBy = UserId;
        myObj.CreatedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistKabupatenKota");
            return;
        }
        else
        {
            myObj.Insert();
            HttpRuntime.Cache.Remove("SIMRS_KabupatenKota");
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            string propId = "";
            if (cmbPropinsi.SelectedIndex > 0)
                propId = cmbPropinsi.SelectedValue;
            Response.Redirect("List.aspx?CurrentPage=" + CurrentPage + "&propId=" + propId);
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
        string propId = "";
        if (Request.QueryString["propId"] != null)
            propId = Request.QueryString["propId"].ToString();
        Response.Redirect("List.aspx?CurrentPage=" + CurrentPage + "&propId=" + propId);
    }

    public void OnPropinsiChanged(object sender, System.EventArgs e)
    {
        if (cmbPropinsi.SelectedIndex > 0)
        {
            string[] kodeprop = cmbPropinsi.SelectedItem.Text.Split('.');
            txtKodeProp.Value = kodeprop[0];
            txtKodeKab.Value = "";
        }
        else
        {
            txtKodeProp.Value = "";
            txtKodeKab.Value = "";
        }
    }
}
