using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextBoxEmail.Enabled = false;
        TextBoxPass.Enabled = false;
        TextBoxRpass.Enabled = false;
        Button1.Enabled = false;
        Button2.Enabled = false;
        Session.RemoveAll();
        LabelCurrentUser.Text = "New User";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Admin.userAdd(TextBoxUN.Text, TextBoxPass.Text, TextBoxEmail.Text))
        {
            LabelStatus.Text = "Your Registration is successful. You can now login.";
        }
        else
        {
            LabelStatus.Text = "Your Registration FAILED!!!";
        }
        if (IsPostBack)
        {
            TextBoxUN.Enabled = false;
            Button1.Enabled = false;
            Button2.Enabled = false;
        }

    }

    protected void TextBoxUN_TextChanged(object sender, EventArgs e)
    {
        if (TextBoxUN.Text != "")
        {
            if (Admin.userID(TextBoxUN.Text) != -1)
            {
                LabelStatus.Text = "This username is already being used.";
            }
            else
            {
                LabelStatus.Text = "You can use this username!";
                TextBoxEmail.Enabled = true;
                TextBoxPass.Enabled = true;
                TextBoxRpass.Enabled = true;
                Button1.Enabled = true;
                Button2.Enabled = true;

            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBoxUN.Text = "";
        TextBoxEmail.Text = "";
        TextBoxPass.Text = "";
        TextBoxRpass.Text = "";
    }
}