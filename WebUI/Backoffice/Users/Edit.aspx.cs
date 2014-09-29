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

public partial class Backoffice_Users_Edit : System.Web.UI.Page
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
            BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
            myUser.UserId = UserId;
            if (!myUser.HasAccessToPolicy("EditUser"))
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"Save\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><br />Simpan<center>";
            btnCancel.Text = "<center><img alt=\"Cancel\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><br />Batal<center>";

            Draw();
        }

    }

    /// <summary>
    /// This function is responsible for initial view data.
    /// </summary>
    public void Draw()
    {
        try
        {
            int UserId = int.Parse(Request.QueryString["Id"].ToString());
            BkNet.Common.Crypto myCripto = new BkNet.Common.Crypto();

            BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
            myUser.UserId = UserId;
            DataTable dt = myUser.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtName.Text = row["NamaLengkap"].ToString();
                txtUserName.Text = row["UserName"].ToString();
                txtPassword.Text = myCripto.Decrypt(row["Password"].ToString());
                txtVerifyPassword.Text = txtPassword.Text;
                PopulateGroup((int)myUser.GroupId);
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Users::Draw::Error occured.", ex);
        }

    }

    /// <summary>
    /// This function is responsible for populate data group user.
    /// </summary>
    /// <param name="GroupId"></param>
    private void PopulateGroup(int GroupId)
    {
        BkNet.DataAccess.Groups myGroup = new BkNet.DataAccess.Groups();
        DataTable myData = myGroup.SelectAll();
        cmbGroup.Items.Clear();
        if (myData.Rows.Count > 0)
        {
            int i = 0;
            cmbGroup.Items.Add("");
            cmbGroup.Items[i].Text = "";
            cmbGroup.Items[i].Value = "";
            i++;
            foreach (DataRow row in myData.Rows)
            {
                cmbGroup.Items.Add("");
                cmbGroup.Items[i].Text = row["GroupName"].ToString();
                cmbGroup.Items[i].Value = row["GroupId"].ToString();
                if (row["GroupId"].ToString() == GroupId.ToString())
                    cmbGroup.SelectedIndex = i;
                i++;
            }
        }
    }
    /// <summary>
    /// This function is responsible for save data into database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnSave(Object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        if ((txtPassword.Text != "" || txtVerifyPassword.Text != "") && txtVerifyPassword.Text != txtPassword.Text)
        {
            lblError.Visible = true;
            lblError.Text = "Password dan Verifikasi Password harus sama !";
            return;
        }

        int UserId = int.Parse(Request.QueryString["Id"].ToString());
        BkNet.Common.Crypto myCripto = new BkNet.Common.Crypto();
        BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
        myUser.UserId = UserId;
        DataTable dt = myUser.SelectOne();

        myUser.NamaLengkap = txtName.Text;
        myUser.UserName = txtUserName.Text;
        if (txtPassword.Text != "")
            myUser.Password = myCripto.Encrypt(txtPassword.Text);
        myUser.GroupId = int.Parse(cmbGroup.Items[cmbGroup.SelectedIndex].Value);

        if (myUser.IsExist())
        {
            lblError.Text = "Username sudah ada dalam dalam database !";
            return;
        }
        else
        {
            myUser.Update();
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
