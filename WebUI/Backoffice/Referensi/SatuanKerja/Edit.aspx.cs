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

public partial class Backoffice_Referensi_SatuanKerja_Edit : System.Web.UI.Page
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
            if (Session["SatuanKerjaManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }

    }

    /*
    public void PopolateOrdering(string Ordering)
    {
        SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
        DataTable dt = myObj.GetList();
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
    */

    public void Draw()
    {
        try
        {
            string IdSatuanKerja = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
            myObj.IdSatuanKerja = Convert.ToInt32(IdSatuanKerja);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtIdSatuanKerja.Text = row["IdSatuanKerja"].ToString();
                txtKode.Value = row["Kode"].ToString();
                txtNamaSatker.Text = row["NamaSatker"].ToString();
                txtKeterangan.Text = row["Keterangan"].ToString();
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.SatuanKerja::Edit::Draw::Error occured.", ex);
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

        SIMRS.DataAccess.RS_SatuanKerja myObj = new SIMRS.DataAccess.RS_SatuanKerja();
        myObj.IdSatuanKerja = int.Parse(txtIdSatuanKerja.Text);
        myObj.SelectOne();
        myObj.Kode = txtKode.Value;
        myObj.NamaSatker = txtNamaSatker.Text;
        myObj.Keterangan = txtKeterangan.Text;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistSatuanKerja");
            return;
        }
        else
        {
            myObj.Update();
            HttpRuntime.Cache.Remove("SIMRS_SatuanKerja");
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
