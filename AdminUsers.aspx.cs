using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class Administration : System.Web.UI.Page
{
    CurrentUser CU = new CurrentUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        Table2.Visible = false;
        LabelCurrentUser.Text = CU.UserName;
    }
    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //        if (userUpdate(int i, string u, string p, string e, bool a))
        int i = Convert.ToInt32(ListBox1.SelectedValue);
        if (Admin.userInfo(i))
        {
            LabelStatus.Text = "";
            Button1.Enabled = true;
            Table2.Visible = true;
            Label5.Text = Admin.UserName;
            TextBox2.Text = Admin.Password;
            TextBox3.Text = Admin.Email;
            CheckBox1.Checked = Admin.IsAdmin;
            Label12.Text = Admin.Cash.ToString();
            Label13.Text = Admin.Wins.ToString();
            Label14.Text = Admin.Losses.ToString();
            Label15.Text = Admin.Draws.ToString();
            Label11.Text = Admin.Blackjack.ToString();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Admin.userUpdate(Admin.UserID, TextBox2.Text, TextBox3.Text, CheckBox1.Checked))
        {
            LabelStatus.Text = Admin.UserName + " Updated!";
        }
        else
        {
            LabelStatus.Text = Admin.UserName + " was not Updated!";
        }
    }
}