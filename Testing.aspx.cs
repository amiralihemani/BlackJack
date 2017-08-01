using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Testing : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {

        CurrentUser CU = new CurrentUser();

        int Test = 7;

        if (Test == 1)
        {
            if (CU.BlackJackLogon("GraybanG6308", "password"))
            {
                Label1.Text = "Found:" + CU.UserName + " - (" + CU.Password + ")";
            }
            else
            {
                Label1.Text = "Not Found";
            }
        }


        if (Test == 2)
            if (CU.ChangePassword("GraybanG6308", "password", "goodby", "goodby"))
            {
                Label1.Text = "Password Changed: " + CU.UserName + " - (" + CU.Password + ")";
            }
            else
            {
                Label1.Text = "Password Not Changed: " + CU.UserName + " - (" + CU.Password + ")";
            }


        if (Test == 3)
        {
            if (CU.BlackJackAdmin("GraybanG6308"))
            {
                Label1.Text = "Is Administrator: " + CU.UserName;
            }
            else
            {
                Label1.Text = "Is NOT Admin";
            }
        }

        if (Test == 4)
        {
            if (CU.ChangeEMail("GraybanG6308", "grgrayban@yahoo.com"))
            {
                Label1.Text = "Email Changed: " + CU.UserName + " - (" + CU.Password + ")";
            }
            else
            {
                Label1.Text = "EMail Not Changed: " + CU.UserName + " - (" + CU.Password + ")";
            }
        }
        if (Test == 6)
        {
            int TheUserID = Admin.userID("aaa");
            if (TheUserID > -1) 
            {
                Label1.Text = "User ID is: " + TheUserID.ToString();
            }
            else
            {
                Label1.Text = "User ID not found: " + TheUserID.ToString();
            }
        }
        if (Test == 7)
        {
            int TheUserID = Admin.userID("aaa");
            if (TheUserID != -1)
            {
                if (Admin.userDelete(TheUserID))
                {
                    Label1.Text = "User ID Deleted!";
                }
                else
                {
                    Label1.Text = "User ID NOT Deleted.";
                }
            }
            else
            {
                Label1.Text = "User ID NOT FOUND.";
            }
        }
    }
}

