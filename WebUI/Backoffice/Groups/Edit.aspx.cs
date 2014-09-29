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

public partial class Backoffice_Groups_Edit : System.Web.UI.Page
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
            if (!myUser.HasAccessToPolicy("EditGroup"))
            {
                Response.Redirect(Request.ApplicationPath + "/Backoffice/UnAuthorize.aspx");
            }
            btnSave.Text = "<center><img alt=\"Save\" src=\"" + Request.ApplicationPath + "/images/save_f2.gif\" align=\"middle\" border=\"0\" name=\"save\" value=\"save\"><br />Simpan<center>";
            btnCancel.Text = "<center><img alt=\"Cancel\" src=\"" + Request.ApplicationPath + "/images/cancel_f2.gif\" align=\"middle\" border=\"0\" name=\"cancel\" value=\"cancel\"><br />Batal<center>";

            Draw();
        }
    }
    public void Draw()
    {
        try
        {
            int GroupId = int.Parse(Request.QueryString["Id"].ToString());
            BkNet.DataAccess.Groups myGroup = new BkNet.DataAccess.Groups();
            myGroup.GroupId = GroupId;
            DataTable dt = myGroup.SelectOne();
            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txtGroupName.Text = row["GroupName"].ToString();
                txtGroupDesc.Text = row["GroupDesc"].ToString();
                PopulateModuleAccess((int)myGroup.GroupId);
            }
        }
        catch (Exception ex)
        {
            // some error occured. Bubble it to caller and encapsulate Exception object
            throw new Exception("Backoffice.Groups::Draw::Error occured.", ex);
        }

    }

    public void PopulateModuleAccess(int GroupId)
    {
        TVModulAccess.Controls.Clear();
        BkNet.DataAccess.GroupPolicy myPolicy = new BkNet.DataAccess.GroupPolicy();
        myPolicy.GroupId = GroupId;
        DataTable myData = myPolicy.SelectAllWGroupIdLogic();
        int i = 0;
        string temp;
        int itemp = -1;
        TreeNode nr;
        TreeNode nc;
        foreach (DataRow myRow in myData.Rows)
        {
            if (myRow["ParentId"].ToString() != "0")
            {
                nc = new TreeNode();
                nc.Text = myRow["PolicyDesc"].ToString();
                nc.Value = myRow["PolicyId"].ToString();
                if (myRow["GroupId"].ToString() != "0")
                {
                    nc.Checked = true;
                }
                TVModulAccess.Nodes[itemp].ChildNodes.Add(nc);
            }
            else
            {
                itemp = itemp + 1;
                nr = new TreeNode();
                nr.Text = myRow["PolicyDesc"].ToString();
                nr.Value = myRow["PolicyId"].ToString();
                temp = myRow["PolicyId"].ToString();
                if (myRow["GroupId"].ToString() != "0")
                {
                    nr.Checked = true;
                }
                TVModulAccess.Nodes.Add(nr);
            }
            i++;
        }
        TVModulAccess.ExpandAll();
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

        int GroupId = int.Parse(Request.QueryString["Id"].ToString());

        BkNet.DataAccess.Groups myGroup = new BkNet.DataAccess.Groups();
        myGroup.GroupId = GroupId;
        myGroup.GroupName = txtGroupName.Text;
        myGroup.GroupDesc = txtGroupDesc.Text;

        if (myGroup.IsExist())
        {
            lblError.Text = "Nama Group sudah ada dalam dalam database !";
            return;
        }
        else
        {
            myGroup.Update();
            BkNet.DataAccess.Policy objPol = new BkNet.DataAccess.Policy();
            BkNet.DataAccess.GroupPolicy myPolicy = new BkNet.DataAccess.GroupPolicy();
            myPolicy.GroupId = (int)myGroup.GroupId;
            bool parentCheck = false;
            for (int i = 0; i < TVModulAccess.Nodes.Count; i++)
            {
                parentCheck = false;
                for (int k = 0; k < TVModulAccess.Nodes[i].ChildNodes.Count; k++)
                {
                    myPolicy.PolicyId = int.Parse(TVModulAccess.Nodes[i].ChildNodes[k].Value.ToString());
                    myPolicy.UpdateData(TVModulAccess.Nodes[i].ChildNodes[k].Checked == true);
                    if (TVModulAccess.Nodes[i].ChildNodes[k].Checked == true)
                        parentCheck = true;
                }
                myPolicy.PolicyId = int.Parse(TVModulAccess.Nodes[i].Value.ToString());
                myPolicy.UpdateData(parentCheck);
            }

            int UserId = (int)Session["SIMRS.UserId"];
            BkNet.DataAccess.Users myUser = new BkNet.DataAccess.Users();
            myUser.UserId = UserId;
            DataTable dt = myUser.GetAllPolicy();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Session.Add(dr["PolicyName"].ToString(), dr["PolicyName"].ToString());
                }
            }
            Session.Remove("SIMRS.Menu");

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
    protected void TVModulAccess_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
    {
        if (e.Node.Depth == 1)
            Response.Write("asdsad");
        else
            Response.Write("0000000");
    }
}
