using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    CurrentUser CU = new CurrentUser();

    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (CU.BlackJackLogon(TextBoxUN.Text, TextBoxP.Text))
        {
            Session["UserName"] = CU.UserName;
            Response.Redirect("~/UserProfile.aspx");
        }
        else
        {
            Label1.Text = "Invalid username or password.";
        }
    }
}
