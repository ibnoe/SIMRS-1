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

public partial class Backoffice_Referensi_KabupatenKota_Edit : System.Web.UI.Page
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

            Draw();
        }

    }

    public void GetListPropinsi(string propinsiId)
    {
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
            if (dr["Id"].ToString() == propinsiId)
                cmbPropinsi.SelectedIndex = i;

            i++;
        }
    }

    public void PopolateOrdering(string Ordering)
    {
        BkNet.DataAccess.KabupatenKota myObj = new BkNet.DataAccess.KabupatenKota();
        if (cmbPropinsi.SelectedIndex > 0)
            myObj.PropinsiId = int.Parse(cmbPropinsi.SelectedValue);
        DataTable dt = myObj.SelectAllWPropinsiIdLogic();
        cmbOrdering.Items.Clear();
        int i = 0;
        foreach (DataRow dr in dt.Rows)
        {
            cmbOrdering.Items.Add("");
            cmbOrdering.Items[i].Text = dr["Ordering"].ToString() + ". " + dr["Nama"].ToString();
            cmbOrdering.Items[i].Value = (i + 1).ToString();
            if (dr["Ordering"].ToString() == Ordering)
            {
                cmbOrdering.SelectedIndex = i;
            }
            i++;
        }
    }
    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            BkNet.DataAccess.KabupatenKota myObj = new BkNet.DataAccess.KabupatenKota();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                GetListPropinsi(row["propinsiId"].ToString());
                txtId.Text = row["Id"].ToString();
                txtKode.Text = row["Kode"].ToString();
                string[] kodekab = txtKode.Text.Split('.');
                txtKodeProp.Value = kodekab[0];
                txtKodeKab.Value = kodekab[1];
                txtNama.Text = row["Nama"].ToString();
                txtKeterangan.Text = row["Keterangan"].ToString();
                if ((bool)row["Published"])
                    rbtYes.Checked = true;
                else
                    rbtNo.Checked = true;
                PopolateOrdering(row["Ordering"].ToString());
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.KabupatenKota::Edit::Draw::Error occured.", ex);
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
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        myObj.PropinsiId = int.Parse(cmbPropinsi.SelectedValue);
        myObj.Kode = txtKodeProp.Value + "." + txtKodeKab.Value;
        myObj.Nama = txtNama.Text;
        myObj.Keterangan = txtKeterangan.Text;
        myObj.Published = rbtYes.Checked ? true : false;
        if (cmbOrdering.Items.Count > 0)
            myObj.Ordering = int.Parse(cmbOrdering.SelectedValue);
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistKabupatenKota");
            return;
        }
        else
        {
            myObj.Update();
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
