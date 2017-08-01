using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// This class will host all the methods needed by an administrator to manage users, cards and the entire game. All commands to get statistics will be here also.
/// THIS CLASS WILL NOT BE ABLE TO BE COPIED (NEW) AS THIS WILL NOT BE AN OBJECT
/// </summary>
public static class Admin
{
    /// <summary>
    /// Set when Method userID is processed successfully.
    /// </summary>
    public static string UserName { get; set; }
    /// <summary>
    /// Set when Method userID is processed.
    /// </summary>
    public static int UserID { get; set; }
    public static int Cash { get; set; }
    public static string Password { get; set; }
    public static string Email { get; set; }
    public static bool IsAdmin { get; set; }

    public static int MaxBet { get; set; }
    public static int MinBet { get; set; }
    public static int IncreaseBet { get; set; }

    public static int Wins { get; set; }
    public static int Losses { get; set; }
    public static int Draws { get; set; }
    public static int Blackjack { get; set; }

    /// <summary>
    /// Returns success status when attempting to delete a current user record based on ID passed to method.
    /// </summary>
    public static bool userDelete(int i)
    {
        bool IsDeleted = false;
        bool succeed = Utilities.updateRecord("delete from Users where UserID='" + i + "'");
        if (succeed)
        {
            IsDeleted = true;
            return IsDeleted;
        }
        return IsDeleted;
    }
    public static string IsLoggedIn()
    {
        if (System.Web.HttpContext.Current.Session["UserName"] != null)
        {
            Admin.userInfo(Admin.userID(System.Web.HttpContext.Current.Session["UserName"].ToString()));
            // renew session each time the session is checked.
            System.Web.HttpContext.Current.Session["UserName"] = System.Web.HttpContext.Current.Session["UserName"].ToString();
            return System.Web.HttpContext.Current.Session["UserName"].ToString();
        }
        HttpContext.Current.Response.Redirect("~/Default.aspx");
        return "";
    }

    /// <summary>
    /// Returns ID of user passed to method. If there is not a match, -1 is returned.
    /// </summary>
    public static int userID(string u)
    {
        DataTable RS = Utilities.getRecordSet("select UserID from Users where UserName='" + u + "'");

        if (RS.Rows.Count == 1)
        {
            UserID = (int)RS.Rows[0]["UserId"];
            UserName = u;
            return UserID;
        }
        UserID = -1;
        UserName = null;
        return UserID;
    }
    public static bool userInfo(int i)
    {
        bool succeed = false;
        DataTable RS = Utilities.getRecordSet("select * from Users where UserID='" + i + "'");

        if (RS.Rows.Count == 1)
        {
            succeed = true;
            UserID = (int)RS.Rows[0]["UserId"];
            Cash = (int)RS.Rows[0]["Cash"];
            UserName = (string)RS.Rows[0]["UserName"];
            Password = (string)RS.Rows[0]["Password"];
            Email = (string)RS.Rows[0]["EMail"];
            IsAdmin = (bool)RS.Rows[0]["IsAdmin"];
        }
        DataTable RS1 = Utilities.getRecordSet("select * from Records where UserID='" + i + "'");

        if (RS1.Rows.Count == 1)
        {
            succeed = true;
            Wins = (int)RS1.Rows[0]["Wins"];
            Losses = (int)RS1.Rows[0]["Losses"];
            Draws = (int)RS1.Rows[0]["Draws"];
            Blackjack = (int)RS1.Rows[0]["Blackjack"];
        }
        return succeed;
    }
    public static bool settingInfo()
    {
        bool succeed = false;
        DataTable RS = Utilities.getRecordSet("select * from Settings");

        if (RS.Rows.Count == 1)
        {
            succeed = true;
            MaxBet = (int)RS.Rows[0]["MaxBet"];
            MinBet = (int)RS.Rows[0]["MinBet"];
            IncreaseBet = (int)RS.Rows[0]["IncreaseBet"];
        }
        return succeed;
    }

    /// <summary>
    /// Returns success status when attempting to add a new user.
    /// </summary>
    public static bool userAdd(string u, string p, string e)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("insert into Users (UserName, Password, EMail) values ('" + u + "','" + p + "','" + e + "')");
        bool succeed1 = Utilities.updateRecord("insert into Records (UserID) values ('" + Admin.userID(u) + "')");
        if (succeed && succeed1)
        {
            IsChanged = true;
            return IsChanged;
        }
        return IsChanged;
    }
    public static bool userUpdate(int i, string p, string e, bool a)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("update Users SET Password='" + p + "', EMail='" + e + "', IsAdmin='" + a + "' where UserID='" + i + "'");
        if (succeed)
        {
            IsChanged = true;
            userInfo(i);
            return IsChanged;
        }
        return IsChanged;
    }

    public static bool settingUpdate(int x, int n, int i)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("update Settings SET MaxBet='" + x + "', MinBet='" + n + "', IncreaseBet='" + i + "' where ID='1'");
        if (succeed)
        {
            IsChanged = true;
            settingInfo();
            return IsChanged;
        }
        return IsChanged;
    }

    /*
        public bool userRename(string query)
        {
            return true;
        }
        public bool userChangePassword(string query)
        {
            return true;
        }
        // score of each player and each game.....
        public bool playerStats(string query)
        {
            return true;
        }
        public bool gameMinBet(string query)
        {
            return true;
        }
        public bool gameMaxBet(string query)
        {
            return true;
        }
        */
}