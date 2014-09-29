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

public partial class Backoffice_Referensi_KelompokPemeriksaan_Edit : System.Web.UI.Page
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
            if (Session["KelompokPemeriksaanManagement"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }
    }
    public void GetListJenisPemeriksaan(string JenisPemeriksaanId)
    {
        SIMRS.DataAccess.RS_JenisPemeriksaan myObj = new SIMRS.DataAccess.RS_JenisPemeriksaan();
        DataTable dt = myObj.GetList();
        cmbJenisPemeriksaan.Items.Clear();
        int i = 0;
        cmbJenisPemeriksaan.Items.Add("");
        cmbJenisPemeriksaan.Items[i].Text = "";
        cmbJenisPemeriksaan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbJenisPemeriksaan.Items.Add("");
            cmbJenisPemeriksaan.Items[i].Text = dr["Nama"].ToString();
            cmbJenisPemeriksaan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == JenisPemeriksaanId)
            {
                cmbJenisPemeriksaan.SelectedIndex = i;
            }
            i++;
        }
    }

    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_KelompokPemeriksaan myObj = new SIMRS.DataAccess.RS_KelompokPemeriksaan();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                
                txtKode.Text = row["Kode"].ToString();
                txtNama.Text = row["Nama"].ToString();
                GetListJenisPemeriksaan(row["JenisPemeriksaanId"].ToString());
                txtKeterangan.Text = row["Keterangan"].ToString();
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.KelompokPemeriksaan::Edit::Draw::Error occured.", ex);
        }

    }

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

        SIMRS.DataAccess.RS_KelompokPemeriksaan myObj = new SIMRS.DataAccess.RS_KelompokPemeriksaan();
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        if (cmbJenisPemeriksaan.SelectedIndex > 0)
            myObj.JenisPemeriksaanId = int.Parse(cmbJenisPemeriksaan.SelectedItem.Value);
        myObj.Kode = txtKode.Text;
        myObj.Nama = txtNama.Text;
        myObj.Keterangan = txtKeterangan.Text;

        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistKelompokPemeriksaan");
            return;
        }
        else
        {
            myObj.Update();
            HttpRuntime.Cache.Remove("SIMRS_KelompokPemeriksaan");
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
        }
    }

    public void OnCancel(Object sender, EventArgs e)
    {
        string CurrentPage = "";
        if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
            CurrentPage = Request.QueryString["CurrentPage"].ToString();
        Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
    }
}
