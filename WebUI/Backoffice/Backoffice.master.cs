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

public partial class Backoffice_Backoffice : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Header.Title = ConfigurationManager.AppSettings["Main.Title"].ToString();
        this.StyleMaster.Href = Request.ApplicationPath + "/css/StyleSheet.css";
        if (Session["SIMRS.UserId"] != null)
        {
            int GroupId = (int)Session["SIMRS.GroupId"];
            string GroupName = Session["SIMRS.GroupName"].ToString();
            lblUserName.Text = Session["SIMRS.UserName"].ToString() + " [" + GroupName;
            //if (Session["SIMRS.UnitNama"] != null && Session["SIMRS.UnitNama"].ToString() != "")
            //   lblUserName.Text += ", " + Session["SIMRS.UnitNama"].ToString();
            lblUserName.Text += "]";
            GetMainMenu();
        }
        else
        {
            lblUserName.Text = "";
            Response.Redirect(Request.ApplicationPath + "/Backoffice/login.aspx");
        }   
    }
    public void GetMainMenu()
    {
        Menu1.Items.Clear();
        int UserId = (int)Session["SIMRS.UserId"];
        BkNet.DataAccess.Menus myMainMenu = new BkNet.DataAccess.Menus();
        DataTable DTSubMenu2;
        DataTable DTSubMenu3;
        DataTable DTMainMenu = myMainMenu.GetMainMenuByUserId(UserId);
        if (DTMainMenu.Rows.Count > 0)
        {
            int i = 0;
            int j = 0;
            foreach (DataRow row in DTMainMenu.Rows)
            {
                if (row["MenuId"].ToString() == "1")
                {
                    Menu1.Items.Add(new MenuItem(row["MenuName"].ToString(), row["MenuId"].ToString(), "", row["MenuLink"].ToString()));
                    i++;
                }
                else
                {
                    myMainMenu.ParentId = (int)row["MenuId"];
                    DTSubMenu2 = myMainMenu.GetSubMenuByUserId(UserId);
                    if (DTSubMenu2.Rows.Count > 0)
                    {
                        Menu1.Items.Add(new MenuItem(row["MenuName"].ToString(), row["MenuId"].ToString(), "", row["MenuLink"].ToString()));
                        j = 0;
                        foreach (DataRow row2 in DTSubMenu2.Rows)
                        {
                            Menu1.Items[i].ChildItems.Add(new MenuItem(row2["MenuName"].ToString(), row2["MenuId"].ToString(), "", row2["MenuLink"].ToString()));
                            myMainMenu.ParentId = (int)row2["MenuId"];
                            DTSubMenu3 = myMainMenu.GetSubMenuByUserId(UserId);
                            if (DTSubMenu3.Rows.Count > 0)
                            {
                                foreach (DataRow row3 in DTSubMenu3.Rows)
                                {
                                    Menu1.Items[i].ChildItems[j].ChildItems.Add(new MenuItem(row3["MenuName"].ToString(), row3["MenuId"].ToString(), "", row3["MenuLink"].ToString()));
                                }
                            }
                            j++;
                        }
                        i++;
                    }
                }
            }
        }

    }
    protected void Menu1_MenuItemClick(object sender, MenuEventArgs e)
    {

    }
}
