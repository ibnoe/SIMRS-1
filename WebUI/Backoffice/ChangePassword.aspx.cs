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

public partial class Backoffice_ChangePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnSave.Text = "<center><img alt=\"Save\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><br />Simpan<center>";
            Draw();
        }
    }

    public void Draw()
    {
        try
        {
            if (Session["SIMRS.UserId"] == null)
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
            }
            int UserId = (int)Session["SIMRS.UserId"];
            BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
            myUser.UserId = UserId;
            myUser.SelectOne();
            txtUserId.Text = myUser.UserId.ToString();
            txtUserName.Text = myUser.UserName.ToString();
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtVerifyPassword.Text = "";
        }
        catch
        {

        }
    }

    public void OnSave(Object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        BkNet.Common.Crypto myCripto = new BkNet.Common.Crypto();

        BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
        myUser.UserId = int.Parse(txtUserId.Text);
        myUser.SelectOne();
        if (myCripto.Encrypt(txtOldPassword.Text) == myUser.Password.ToString())
        {
            myUser.Password = myCripto.Encrypt(txtNewPassword.Text);
            if (myUser.Update())
            {
                pnlEdit.Visible = false;
                pnlOK.Visible = true;
            }
        }
        else
        {
            lblError.Text = "Masukan password lama yang benar !";
            return;
        }
    }

    public void OnCancel(Object sender, EventArgs e)
    {
        Response.Write("<script>window.history.go(-1);</script>");
    }
}
