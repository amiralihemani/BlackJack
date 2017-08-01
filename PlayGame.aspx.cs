using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Diagnostics;

/// <summary>
/// This handles the play game logic.
/// Two lists, PlayerList and DealerList is created to hols player and dealer cards dealt respectively
/// These lists are saved in the session and retrieved from it to deal more cards ehich are not dealt already i.e not in these list.
/// 
/// </summary>
public partial class _PlayGame : System.Web.UI.Page
{
    List<Card> dealerList = new List<Card>();
    List<Card> playerList = new List<Card>();
    CurrentUser CU = new CurrentUser();

    protected void Page_Load(object sender, EventArgs e)
    {
        StackTrace stackTrace = new StackTrace();
        string eventName = stackTrace.GetFrame(1).GetMethod().Name;
        Admin.settingInfo();

        LabelCurrentUser.Text = Admin.UserName;

        if (!IsPostBack)
        {
            Hit.Enabled = false;
            Hit.Visible = false;
            Stand.Visible = false;
            Stand.Enabled = false;
            Play_Again.Visible = false;
            Play_Again.Enabled = false;
            Admin.userInfo(Admin.userID(Admin.IsLoggedIn()));
            Label12.Text = Admin.Cash.ToString();
            Label13.Text = Admin.Wins.ToString();
            Label14.Text = Admin.Losses.ToString();
            Label15.Text = Admin.Draws.ToString();
            Label17.Text = Admin.Blackjack.ToString();

            if (!Admin.IsAdmin)
            {
                Menu1.Items.Remove(Menu1.FindItem("User Administration"));
                Menu1.Items.Remove(Menu1.FindItem("Game Administration"));
            }
        }
        else if (eventName == "Play_Again_Click")
        {
            Admin.userInfo(Admin.userID(Admin.IsLoggedIn()));
            Label12.Text = Admin.Cash.ToString();
            Label13.Text = Admin.Wins.ToString();
            Label14.Text = Admin.Losses.ToString();
            Label15.Text = Admin.Draws.ToString();
            Label17.Text = Admin.Blackjack.ToString();

        }
    }
    /// <summary>
    /// Add a Card to the panel
    /// </summary>
    /// <param name="imgURL"></param>
    /// <param name="panel1"></param>
    /// <param name="top"></param>
    /// <param name="left"></param>
    /// <param name="cardNum"></param>
    public void AddCard(string imgURL, Panel panel1, int top, int left, int cardNum)
    {
        Image img = new Image();
        img.ImageUrl = "~/Images/" + (imgURL.Equals("card.jpg") ? imgURL : imgURL + ".png");
        img.Style["width"] = "100px";
        img.Style["height"] = "100px";
        img.Style["position"] = "absolute";
        img.Style["margin-left"] = "-10px";
        img.Style["top"] = top.ToString() + "px";//"20px";
        img.Style["left"] = left.ToString() + "px";//"525px";
        img.CssClass = "imageCSS";
        img.ID = cardNum.ToString();
        panel1.Controls.Add(img);
    }
    /// <summary>
    /// Increase bet amount clicked,
    /// Ignore if current bet amount goes beyond max bet amount set
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (!((Convert.ToInt32(betamount.Text) + Admin.IncreaseBet) > Admin.MaxBet))
        {
            betamount.Text = (Convert.ToInt32(betamount.Text) + Admin.IncreaseBet).ToString();
        }
    }

    /// <summary>
    /// Decrease bet amount clicked,
    /// Ignore if current bet amount goes below min bet amount set
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (!((Convert.ToInt32(betamount.Text) - Admin.IncreaseBet) < Admin.MinBet))
        {
            betamount.Text = (Convert.ToInt32(betamount.Text) - Admin.IncreaseBet).ToString();
        }
    }

    /// <summary>
    /// User hits deal button, begin game
    /// Deal to cards to dealer and show only one to user,
    /// Deal two cards to user.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Deal_Click(object sender, EventArgs e)
    {
        double playerAmount = Convert.ToDouble(betamount.Text);
        PlayGame playgame = new PlayGame();
        int[] cards = playgame.pickCard(new int[0]);
        int left = 505;
        int dealerScore = 0;
        int playerScore = 0;
        CU.AddMoney(Admin.UserName, Convert.ToInt32(-playerAmount));
        for (int i = 0; i < 4; i++)
        {
            string cardName = PlayGame.getCardName(cards[i]);
            if (i <= 1)
            {
                //dealer
                if (i == 0)
                {
                    left = 485;
                }
                left += 20;
                if (i == 0)
                {
                    this.AddCard("card.jpg", Panel1, 20, left, cards[i]);
                }
                else
                {
                    this.AddCard(cardName, Panel1, 20, left, cards[i]);
                }
                Card cardDealer = new Card();
                cardDealer.imgURL = cardName;
                cardDealer.panel1 = Panel1;
                cardDealer.top = 20;
                cardDealer.left = left;
                cardDealer.cardNum = cards[i];
                dealerList.Add(cardDealer);
                dealerScore += this.score(new int[] { cards[i] });
                continue;
            }
            if (i == 2)
            {
                left = 485;
            }
            //player
            left += 20;
            this.AddCard(cardName, Panel1, 320, left, cards[i]);
            Card card = new Card();
            card.imgURL = cardName;
            card.panel1 = Panel1;
            card.top = 320;
            card.left = left;
            card.cardNum = cards[i];
            playerList.Add(card);
            playerScore += this.score(new int[] { cards[i] });
        }
        if (playerScore == 21) //player blackjack game ends player wins
        {
            Deal.Enabled = false;
            Deal.Visible = false;
            Hit.Visible = false;
            Hit.Enabled = false;
            Stand.Enabled = false;
            Stand.Visible = false;
        }
        Session["PlayerList"] = playerList;
        Session["DealerList"] = dealerList;
        if (playerScore == 21) //player blackjack game ends player wins
        {
            Deal.Enabled = false;
            Deal.Visible = false;
            Hit.Visible = false;
            Hit.Enabled = false;
            Stand.Enabled = false;
            Stand.Visible = false;
            playerAmount = playerAmount + (playerAmount * 0.5);     //('" + msg + "')
            CU.AddMoney(Admin.UserName, Convert.ToInt32(playerAmount * 0.5));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Player has BlackJack!!! ,Player Wins $" + playerAmount + "');</script>");
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "callMyJSFunction",true);
            //Need DB
            //this.MyTrace("Player has BlackJack!!!' ,Player Wins $" + playerAmount + "", playerList.ElementAt(playerList.Count - 1).cardNum);
            CU.AddGameRecord(Admin.UserID, "Wins");
            CU.AddGameRecord(Admin.UserID, "BlackJack");
        }
        else
        {
            Hit.Enabled = true;
            Hit.Visible = true;
            Stand.Visible = true;
            Stand.Enabled = true;
        }
        ImageButton1.Enabled = false;
        ImageButton2.Enabled = false;
        ImageButton1.Visible = false;
        ImageButton2.Visible = false;
        Deal.Enabled = false;
        Deal.Visible = false;
        Play_Again.Visible = true;
        Play_Again.Enabled = true;
        Admin.userInfo(Admin.userID(Admin.IsLoggedIn()));
        Label12.Text = Admin.Cash.ToString();
        Label13.Text = Admin.Wins.ToString();
        Label14.Text = Admin.Losses.ToString();
        Label15.Text = Admin.Draws.ToString();
        Label17.Text = Admin.Blackjack.ToString();
    }

    /// <summary>
    /// this method adds cards to panel reading them from session
    /// </summary>
    public void rebuiidPanel()
    {
        //List<Card> dealerListOld = new List<Card>();
        //List<Card> playerListOld = new List<Card>();
        if (Session["PlayerList"] != null)
        {
            playerList = Session["PlayerList"] as List<Card>;
        }
        if (Session["DealerList"] != null)
        {
            dealerList = Session["DealerList"] as List<Card>;
        }
        foreach (var item in playerList)
        {
            this.AddCard(item.imgURL, Panel1, item.top, item.left, item.cardNum);
        }
        foreach (var item in dealerList)
        {
            this.AddCard(item.imgURL, Panel1, item.top, item.left, item.cardNum);
        }
    }

    /// <summary>
    /// Player decides to hit, deal a card to him
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Hit_Click(object sender, EventArgs e)
    {
        double playerAmount = Convert.ToDouble(betamount.Text);
        this.rebuiidPanel();
        //this.getCardsDealt();

        int[] cardsDealt = this.getCardsDealt();
        //int left = getLeftPosition("Player") + 20;
        PlayGame playgame = new PlayGame();
        int[] cards = playgame.pickCard(cardsDealt);
        //int playerScore = 0;

        string cardName = PlayGame.getCardName(cards[0]);

        int playerScore = this.getScore(playerList);//this.score(playerCardsArray);


        this.AddCard(cardName, Panel1, 320, (playerList.ElementAt(playerList.Count - 1).left + 20), cards[0]);
        Card card = new Card();
        card.imgURL = cardName;
        card.panel1 = Panel1;
        card.top = 320;
        card.left = (playerList.ElementAt(playerList.Count - 1).left + 20);
        card.cardNum = cards[0];
        playerList.Add(card);
        Session["PlayerList"] = playerList;
        //calculate total


        if ((playerScore += this.score(new int[] { cards[0] })) > 21)
        {
            //player busted dealer wins
            Hit.Enabled = false;
            Hit.Visible = false;
            Stand.Enabled = false;
            Stand.Visible = false;
            Deal.Enabled = false;
            Deal.Visible = false;
            ImageButton1.Enabled = false;
            ImageButton2.Enabled = false;
            ImageButton1.Visible = false;
            ImageButton2.Visible = false;
            playerAmount = 0;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Player Busted!!!, Player Wins $" + playerAmount + "');</script>");

            CU.AddGameRecord(Admin.UserID, "Losses");

        }
        ImageButton1.Enabled = false;
        ImageButton2.Enabled = false;
        ImageButton1.Visible = false;
        ImageButton2.Visible = false;
        Deal.Enabled = false;
        Deal.Visible = false;
        Play_Again.Visible = true;
        Play_Again.Enabled = true;

        Admin.userInfo(Admin.userID(Admin.IsLoggedIn()));
        Label12.Text = Admin.Cash.ToString();
        Label13.Text = Admin.Wins.ToString();
        Label14.Text = Admin.Losses.ToString();
        Label15.Text = Admin.Draws.ToString();
        Label17.Text = Admin.Blackjack.ToString();
    }

    private int getScore(List<Card> cardList)
    {
        int j = 0;
        int[] CardsArray = new int[cardList.Count];
        foreach (var item in cardList)
        {
            CardsArray[j] = item.cardNum;
            j++;
        }
        return this.score(CardsArray);
    }

    /// <summary>
    /// return an array of all cards dealt to both user and dealer
    /// </summary>
    /// <returns></returns>
    private int[] getCardsDealt()
    {

        int[] cardsDealt = new int[dealerList.Count + playerList.Count];
        int i = 0;
        foreach (var item in dealerList)
        {
            cardsDealt[i] = item.cardNum;
            i++;
        }
        foreach (var item in playerList)
        {
            cardsDealt[i] = item.cardNum;
            i++;
        }
        return cardsDealt;
    }

    /// <summary>
    /// User decides to stand, no more cards will be dealt to user
    /// The dealer is dealt cards one at a time untill his score is between 17 and 21.
    /// if score is between 17 and 21, stop dealing further cards to dealer and evaluate the winner based on whose score is high
    /// if score goes beyond 21, dealer is busted
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Stand_Click(object sender, EventArgs e)
    {
        double playerAmount = Convert.ToDouble(betamount.Text);
        this.rebuiidPanel();
        //this.getCardsDealt();
        int[] cardsDealt = this.getCardsDealt();        // including player and dealer
        bool dealerBJ = false;
        //calculate total
        //int[] dealerCardsArray = new int[dealerList.Count];
        /*int j = 0;
        foreach (var item in dealerList)
        {
            dealerCardsArray[j] = item.cardNum;
            j++;
        }*/
        //int dealerScore = this.score(dealerCardsArray);
        int dealerScore = this.getScore(dealerList);

        if (dealerScore < 17)
        {
            PlayGame playgame = new PlayGame();
            int[] cards = playgame.pickCard(cardsDealt);
            int i = 0;
            int cardNum;
            do//while((dealerScore += this.score(new int[] { cards[i] }))<17)//cards[i] 1 to 53 //for (int i = 0; i < 5; i++)
            {
                string cardName = PlayGame.getCardName(cards[i]);
                //Thread.Sleep(100);
                this.AddCard(cardName, Panel1, 20, (dealerList.ElementAt(dealerList.Count - 1).left + 20), cards[0]);
                Card card = new Card();
                card.imgURL = cardName;
                card.panel1 = Panel1;
                card.top = 20;
                card.left = (dealerList.ElementAt(dealerList.Count - 1).left + 20);
                card.cardNum = cards[0];//cards[0];
                dealerList.Add(card);
                cardNum = cards[i];
                i++;
                if (i >= cards.Length - 1)
                {
                    break;
                }
            }
            while ((dealerScore += this.score(new int[] { cardNum })) < 17);
        }
        else if (dealerScore == 21)
        {
            //dealer has blackjack
            dealerBJ = true;
            playerAmount = 0;
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Dealer has Black Jack!!!, Player Loses all money');</script>");
        }
        if (dealerScore >= 17 && dealerScore <= 21 && !dealerBJ)
        {
            //compare wih user score.. win or lose
            int playerScore = this.getScore(playerList);
            if (dealerScore < playerScore)
            {
                //player wins
                //Need DB
                playerAmount = playerAmount * 2;
                CU.AddMoney(Admin.UserName, Convert.ToInt32(playerAmount * 2));
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Player Wins!!!, Player money is $ " + playerAmount + "');</script>");
                CU.AddGameRecord(Admin.UserID, "Wins");
            }
            else if (dealerScore > playerScore)
            {
                playerAmount = 0;
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Dealer Wins!!!, Player loses all money');</script>");

                CU.AddGameRecord(Admin.UserID, "Losses");
            }
            else if (dealerScore == playerScore)
            {
                //Push
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('It is Push!!!, Player has amount $" + playerAmount + "');</script>");
                //this.MyTrace("Its a Push!!!! Player wins nothing",0);
                CU.AddGameRecord(Admin.UserID, "Draws");
            }
        }
        else if (dealerScore > 21)
        {
            playerAmount = playerAmount * 2;
            CU.AddMoney(Admin.UserName, Convert.ToInt32(playerAmount * 2));
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>alert('Dealer Busted!!!, Player wins amount" + playerAmount + "');</script>");
            CU.AddGameRecord(Admin.UserID, "Wins");
        }

        Hit.Visible = false;
        Hit.Enabled = false;
        Stand.Enabled = false;
        Stand.Visible = false;
        Deal.Visible = false;
        Deal.Enabled = false;
        ImageButton1.Visible = false;
        ImageButton2.Visible = false;
        Play_Again.Visible = true;
        Play_Again.Enabled = true;

        Session["DealerList"] = dealerList;

        Admin.userInfo(Admin.userID(Admin.IsLoggedIn()));
        Label12.Text = Admin.Cash.ToString();
        Label13.Text = Admin.Wins.ToString();
        Label14.Text = Admin.Losses.ToString();
        Label15.Text = Admin.Draws.ToString();
        Label17.Text = Admin.Blackjack.ToString();
    }

    /// <summary>
    /// return the score of the cards dealt
    /// return -1, i.e busted if score is beyond 21
    /// Ace card has two values, 1 if adding 11 takes the score beyond 21 else it is 11
    /// </summary>
    /// <param name="actorCards"></param>
    /// <returns></returns>
    private int score(int[] actorCards)
    {
        int score = 0;
        int n;
        int aces = 0;
        for (int i = 0; i < actorCards.Length; i++)
        {
            n = (actorCards[i] - 1) % 13 + 1;
            switch (n)
            {
                case 1:     //Ace ?? 1 or 11
                    score += 1;
                    aces++;
                    break;
                case 11:
                    score += 10;
                    break;
                case 12:
                    score += 10;
                    break;
                case 13:
                    score += 10;
                    break;
                default:
                    score += n;
                    break;
            }
            if (score > 21)
            {
                //Busted
                return -1;
            }
        }
        for (int i = 0; i < aces; i++)
        {
            if (score <= 11)
            {
                score += 10;
            }
        }
        return score;
    }

    protected void Play_Again_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/PlayGame.aspx");
    }

    protected void MyTrace(string msg, int id)
    {
        //script += "{ var ele = getElementById('"+id+"'); ele.onload = function() {alert('" + msg + "') };};";
        Response.Write("<script>function abc() { alert('" + msg + "'); }</script>");
        //Response.Write(script);
    }
}