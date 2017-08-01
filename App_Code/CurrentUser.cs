using System.Data;

/// <summary>
/// These methods are ONLY executed by the current user logged into the game and ONLY for manipulating entities of their account.
/// </summary>
public class CurrentUser
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public int UserID { get; set; }

    public bool BlackJackLogon(string u, string p)
    {
        bool IsFound = false;
        DataTable RS = Utilities.getRecordSet("select * from Users where UserName='" + u + "' and Password='" + p + "'");

        if (RS.Rows.Count == 1)
        {
            IsFound = true;
            UserName = u;
            Password = p;
            UserID = (int)RS.Rows[0]["UserId"];
            return IsFound;
        }
    return IsFound;
    }

    public bool BlackJackAdmin(string u)
    {
        bool IsFound = false;
        DataTable RS = Utilities.getRecordSet("select IsAdmin from Users where UserName='" + u + "' and IsAdmin=1");
        if (RS.Rows.Count == 1)
        {
            IsFound = true;
            UserName = u;
            return IsFound;
        }
        return IsFound;
    }
    public bool ChangePassword(string u, string op, string np0, string np1)
    {
        bool IsChanged = false;
        if (np0 != np1)
        {
            return IsChanged;
        }
        bool succeed = Utilities.updateRecord("update Users SET Password='" + np0 + "' where UserName='" + u + "'");
        if (succeed)
        {
            IsChanged = true;
            Password = np0;
            return IsChanged;
        }
        return IsChanged;
    }

    public bool ChangeEMail(string u, string e)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("update Users SET EMail='" + e + "' where UserName='" + u + "'");
        if (succeed)
        {
            IsChanged = true;
            UserName = u;
            return IsChanged;
        }
        return IsChanged;
    }

    public bool AddMoney(string u, int m)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("update Users SET Cash = Cash +" + " " + m + " where UserName='" + u + "'");
        if (succeed)
        {
            IsChanged = true;
            UserName = u;
            return IsChanged;
        }
        return IsChanged;
    }
    public bool AddGameRecord(int i, string f)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("update Records SET " + f + " = " + f + "+ 1 where UserID='" + i + "'");
        if (succeed)
        {
            IsChanged = true;
            return IsChanged;
        }
        return IsChanged;
    }
    public bool GetGameRecord(int i, string f)
    {
        bool IsChanged = false;
        bool succeed = Utilities.updateRecord("update Records SET " + f + " = " + f + "+ 1 where UserID='" + i + "'");
        if (succeed)
        {
            IsChanged = true;
            return IsChanged;
        }
        return IsChanged;
    }

}
