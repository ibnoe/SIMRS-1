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

public partial class Backoffice_Users_Add : System.Web.UI.Page
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
            if (!myUser.HasAccessToPolicy("AddUser"))
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"Save\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><br />Simpan<center>";
            btnCancel.Text = "<center><img alt=\"Cancel\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><br />Batal<center>";

            PopulateGroup();
        }

    }

    /// <summary>
    /// This function is responsible for populate data group user into combobox.
    /// </summary>
    private void PopulateGroup()
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
        BkNet.Common.Crypto myCripto = new BkNet.Common.Crypto();

        BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
        myUser.NamaLengkap = txtName.Text;
        myUser.UserName = txtUserName.Text;
        myUser.Password = myCripto.Encrypt(txtPassword.Text);
        myUser.GroupId = int.Parse(cmbGroup.SelectedValue.ToString());

        if (myUser.IsExist())
        {
            lblError.Text = "Username sudah ada dalam dalam database !";
            return;
        }
        else
        {
            myUser.Insert();
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
