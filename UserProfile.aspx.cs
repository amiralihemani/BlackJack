using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

public partial class UserProfile : System.Web.UI.Page
{
    CurrentUser CU = new CurrentUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        Admin.userInfo(Admin.userID(Admin.IsLoggedIn()));
        LabelCurrentUser.Text = Admin.UserName;
        LabelStatus.Text = "";
        Button1.Enabled = true;
        Table2.Visible = true;
        Label12.Text = Admin.Cash.ToString();
        Label5.Text = Admin.UserName;
        Label12.Text = Admin.Cash.ToString();
        Label13.Text = Admin.Wins.ToString();
        Label14.Text = Admin.Losses.ToString();
        Label15.Text = Admin.Draws.ToString();
        Label17.Text = Admin.Blackjack.ToString();


        if (!IsPostBack)
        {
            TextBoxEmail.Text = Admin.Email;
            // Increase
            ListItem[] itemsIncrease = new ListItem[5];
            itemsIncrease[0] = new ListItem("$0.00", "0");
            itemsIncrease[1] = new ListItem("$5.00", "5");
            itemsIncrease[2] = new ListItem("$10.00", "10");
            itemsIncrease[3] = new ListItem("$15.00", "15");
            itemsIncrease[4] = new ListItem("$20.00", "20");
            DropDownList3.Items.AddRange(itemsIncrease);
            DropDownList3.DataBind();

            if (!Admin.IsAdmin)
            {
                Menu1.Items.Remove(Menu1.FindItem("User Administration"));
                Menu1.Items.Remove(Menu1.FindItem("Game Administration"));
            }

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (TextBoxP.Text != "")
        {
            if (TextBoxP.Text == Admin.Password)
            {
                if(TextBoxPN1.Text == TextBoxPN2.Text)
                {
                    CU.ChangePassword(Admin.UserName, TextBoxP.Text, TextBoxPN1.Text, TextBoxPN2.Text);
                    Menu1.Items.Remove(Menu1.FindItem("Play Game"));
                    if (Admin.IsAdmin)
                    {
                        Menu1.Items.Remove(Menu1.FindItem("User Administration"));
                        Menu1.Items.Remove(Menu1.FindItem("Game Administration"));
                    }
                    LabelStatus.Text = "Password Changed";
                }
                else
                {
                    LabelStatus.Text = "Passwords do not match";
                }
            }
            else
            {
                LabelStatus.Text = "Current Password Incorrect";
            }
        }

        if (TextBoxEmail.Text != Admin.Email)
        {
            var ET = new EmailAddressAttribute();
            if (ET.IsValid(TextBoxEmail.Text))
            {
                CU.ChangeEMail(Admin.UserName, TextBoxEmail.Text);
                LabelStatus.Text = "Email Changed";
            }
            else
            {
                LabelStatus.Text = "Email format not Valid";
            }
        }
        if (Convert.ToInt32(DropDownList3.SelectedValue) > 0)
        {
            CU.AddMoney(Admin.UserName, Convert.ToInt32(DropDownList3.SelectedValue));
            LabelStatus.Text = "Money Added";
        }
    }
}