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
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelCurrentUser.Text = Admin.IsLoggedIn();
        if (!Admin.IsAdmin)
        {
            Menu1.Items.Remove(Menu1.FindItem("User Administration"));
        }

        if (!IsPostBack)
        {
            Admin.settingInfo();
            // Max
            ListItem[] itemsMax = new ListItem[3];
            itemsMax[0] = new ListItem("100", "100");
            itemsMax[1] = new ListItem("50", "50");
            itemsMax[2] = new ListItem("25", "25");
            DropDownList1.Items.AddRange(itemsMax);
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = Admin.MaxBet.ToString();
            // Min
            ListItem[] itemsMin = new ListItem[3];
            itemsMin[0] = new ListItem("15", "15");
            itemsMin[1] = new ListItem("10", "10");
            itemsMin[2] = new ListItem("5", "5");
            DropDownList2.Items.AddRange(itemsMin);
            DropDownList2.DataBind();
            DropDownList2.SelectedValue = Admin.MinBet.ToString();
            // Increase
            ListItem[] itemsIncrease = new ListItem[2];
            itemsIncrease[0] = new ListItem("10", "10");
            itemsIncrease[1] = new ListItem("5", "5");
            DropDownList3.Items.AddRange(itemsIncrease);
            DropDownList3.DataBind();
            DropDownList3.SelectedValue = Admin.IncreaseBet.ToString();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(DropDownList1.SelectedValue);
        int n = Convert.ToInt32(DropDownList2.Text);
        int i = Convert.ToInt32(DropDownList3.Text);

        if (Admin.settingUpdate(x, n, i))
        {
            Label6.Text = " Updated!";
        }
        else
        {
            Label6.Text = " Not Updated!";
        }
    }
}