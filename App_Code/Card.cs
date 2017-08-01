using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// This card holds card details like image URL, left and top position in the panel and card number
/// </summary>
public class Card
{
        //
        // TODO: Add constructor logic here
        //
        //string imgURL, Panel panel1,int top,int left
        public string imgURL { get; set; }
    public Panel panel1 { get; set; }
    public int top { get; set; }
    public int left { get; set; }
    public int cardNum { get; set; }

}
