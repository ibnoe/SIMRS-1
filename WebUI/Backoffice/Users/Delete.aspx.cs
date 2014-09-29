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

public partial class Backoffice_Users_Delete : System.Web.UI.Page
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
            if (!myUser.HasAccessToPolicy("DeleteUser"))
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnDelete.Text = "<center><img alt=\"Delete\" src=\"" + Request.ApplicationPath + "/images/delete_f2.gif\" align=\"middle\" border=\"0\" name=\"delete\" value=\"save\"><br />Hapus<center>";
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
                lblNamaLengkap.Text = row["NamaLengkap"].ToString();
                lblUserName.Text = row["UserName"].ToString();
                BkNet.DataAccess.Groups myGroup = new BkNet.DataAccess.Groups();
                myGroup.GroupId = myUser.GroupId;
                myGroup.SelectOne();
                lblGroupName.Text = myGroup.GroupName.ToString();
                if ((int)myUser.UserId == 1)
                {
                    lblError.Text = "Username: " + lblUserName.Text + " Tidak dapat dihapus";
                    btnDelete.Visible = false;
                }
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Users::Draw::Error occured.", ex);
        }

    }
    /// <summary>
    /// This function is responsible for delete data from database.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnDelete(Object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        int UserId = int.Parse(Request.QueryString["Id"].ToString());
        BkNet.Common.Crypto myCripto = new BkNet.Common.Crypto();
        BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
        myUser.UserId = UserId;

        try
        {
            myUser.Delete();
            string CurrentPage = "";
            if (Request.QueryString["CurrentPage"] != null && Request.QueryString["CurrentPage"].ToString() != "")
                CurrentPage = Request.QueryString["CurrentPage"].ToString();
            Response.Redirect("List.aspx?CurrentPage=" + CurrentPage);
        }
        catch
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            Response.Write("<script>alert(\"" + Resources.GetString("", "WarAlreadyUsed") + "\"); window.history.go(-1)</script>");
        }

    }
    /// <summary>
    /// This function is responsible for cancel delete data into database.
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
