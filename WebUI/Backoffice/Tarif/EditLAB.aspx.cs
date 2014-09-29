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
public partial class Backoffice_Tarif_EditLAB : System.Web.UI.Page
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
            if (Session["EditTarif"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"" + Resources.GetString("", "Save") + "\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><center>";
            btnCancel.Text = "<center><img alt=\"" + Resources.GetString("", "Cancel") + "\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><center>";

            Draw();
        }

    }

    public void Draw()
    {
        try
        {
            string Id = Request.QueryString["Id"].ToString();
            SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
            myObj.Id = Convert.ToInt32(Id);
            DataTable dt = myObj.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtId.Text = row["Id"].ToString();
                GetListKelompokPemeriksaan(row["KelompokPemeriksaanId"].ToString());
                txtKode.Text = row["Kode"].ToString();
                txtKodePeriksa.Text = row["KodePeriksa"].ToString();
                txtNama.Text = row["Nama"].ToString();
                txtRJ.Value = row["RJ"].ToString() != "" ? ((decimal)row["RJ"]).ToString("N") : "";
                txtTarifIII.Value = row["KelasIII"].ToString() != "" ? ((decimal)row["KelasIII"]).ToString("N") : "";
                txtTarifII.Value = row["KelasII"].ToString() != "" ? ((decimal)row["KelasII"]).ToString("N") : "";
                txtTarifI.Value = row["KelasI"].ToString() != "" ? ((decimal)row["KelasI"]).ToString("N") : "";
                txtTarifVIP.Value = row["KelasVIP"].ToString() != "" ? ((decimal)row["KelasVIP"]).ToString("N") : "";
                txtTarifVVIP.Value = row["KelasVVIP"].ToString() != "" ? ((decimal)row["KelasVVIP"]).ToString("N") : "";
                //if ((bool)row["Published"])
                //    rbtYes.Checked = true;
                //else
                //    rbtNo.Checked = true;
                txtKeterangan.Text = row["Keterangan"].ToString();
                
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Referensi.Layanan::Edit::Draw::Error occured.", ex);
        }

    }

    public void GetListKelompokPemeriksaan(string KelompokPemeriksaanId)
    {
        SIMRS.DataAccess.RS_KelompokPemeriksaan myObj = new SIMRS.DataAccess.RS_KelompokPemeriksaan();
        myObj.JenisPemeriksaanId = 1; //  Pemeriksaan Laboratorium
        DataTable dt = myObj.GetListByJenisPemeriksaanId();
        cmbKelompokPemeriksaan.Items.Clear();
        int i = 0;
        cmbKelompokPemeriksaan.Items.Add("");
        cmbKelompokPemeriksaan.Items[i].Text = "";
        cmbKelompokPemeriksaan.Items[i].Value = "";
        i++;
        foreach (DataRow dr in dt.Rows)
        {
            cmbKelompokPemeriksaan.Items.Add("");
            cmbKelompokPemeriksaan.Items[i].Text = dr["Kode"].ToString()+". "+dr["Nama"].ToString();
            cmbKelompokPemeriksaan.Items[i].Value = dr["Id"].ToString();
            if (dr["Id"].ToString() == KelompokPemeriksaanId)
                cmbKelompokPemeriksaan.SelectedIndex = i;
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

        SIMRS.DataAccess.RS_Layanan myObj = new SIMRS.DataAccess.RS_Layanan();
        myObj.Id = int.Parse(txtId.Text);
        myObj.SelectOne();
        myObj.Kode = txtKode.Text;
        myObj.KodePeriksa = txtKodePeriksa.Text;
        myObj.Nama = txtNama.Text;
        myObj.JenisLayananId = 3;// Kesehatan Lain
        myObj.PoliklinikId = 42;// LAB
        if (cmbKelompokPemeriksaan.SelectedIndex > 0)
            myObj.KelompokPemeriksaanId = int.Parse(cmbKelompokPemeriksaan.SelectedItem.Value);
        decimal RJ = 0;
        decimal Kelas3 = 0;
        decimal Kelas2 = 0;
        decimal Kelas1 = 0;
        decimal KelasV = 0;
        decimal KelasVV = 0;
        if (txtRJ.Value != "")
            RJ = decimal.Parse(txtRJ.Value);
        else
            RJ = 0;
        if (txtTarifIII.Value != "")
            Kelas3 = decimal.Parse(txtTarifIII.Value);
        else
            Kelas3 = 0;
        if (txtTarifII.Value != "")
            Kelas2 = decimal.Parse(txtTarifII.Value);
        else
            Kelas2 = 0;
        if (txtTarifI.Value != "")
            Kelas1 = decimal.Parse(txtTarifI.Value);
        else
            Kelas1 = 0;
        if (txtTarifVIP.Value != "")
            KelasV = decimal.Parse(txtTarifVIP.Value);
        else
            KelasV = 0;
        if (txtTarifVVIP.Value != "")
            KelasVV = decimal.Parse(txtTarifVVIP.Value);
        else
            KelasVV = 0;
        
        myObj.Keterangan = txtKeterangan.Text;
        myObj.ModifiedBy = UserId;
        myObj.ModifiedDate = DateTime.Now;

        if (myObj.IsExist())
        {
            lblError.Text = Resources.GetString("Referensi", "WarExistLayanan");
            return;
        }
        else
        {
            myObj.UpdateDataRI(RJ, Kelas3, Kelas2, Kelas1, KelasV, KelasVV);
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("ListLAB.aspx?CurrentPage=" + CurrentPage);
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
        Response.Redirect("ListLAB.aspx?CurrentPage=" + CurrentPage);
    }
}
