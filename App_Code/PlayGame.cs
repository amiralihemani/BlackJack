using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PlayGame
/// </summary>
public class PlayGame
{
    public PlayGame()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int[] pickCard(int[] cardsAlreadyDelt)
    {
        int[] cardsLeft = new int[52 - cardsAlreadyDelt.Length];
        for (int i = 1,j=0; i <= 52; i++)//cardsLeft.Length; i++)    //1 to 52
        {
            if (cardsAlreadyDelt.ToList().Contains(i))
            {
                continue;
            }
            else
            {
                //cardsLeft[i-1] = i;
                cardsLeft[j] = i;
                j++;
            }
        }
        cardsLeft = PlayGame.shuffleCards(cardsLeft);
        return cardsLeft;
    }

    private static int[] shuffleCards(int[] cards)
    {
        int temp;
        Random rand = new Random();
        for (int i = 0; i < 1000; i++)
        {
            int a = rand.Next(0, cards.Length/2);
            int b = rand.Next(cards.Length / 2, cards.Length);
            temp = cards[a];
            cards[a] = cards[b];
            cards[b] = temp;
        }
        return cards;
    }

    public static string getCardName(int cardNum)
    {
        int n;
        var cardtype = "";
        string cardface = "";
        if (cardNum >= 1 && cardNum <= 13)
        {
            cardtype = "_of_diamonds";
        }
        else if (cardNum >= 14 && cardNum <= 26)
        {
            cardtype = "_of_clubs";
        }
        else if (cardNum >= 27 && cardNum <= 39)
        {
            cardtype = "_of_hearts";
        }
        else if (cardNum >= 40 && cardNum <= 52)
        {
            cardtype = "_of_spades";
        }
        n = (cardNum - 1) % 13 + 1;
        switch (n)
        {
            case 1:
                cardface = "ace";
                break;
            case 11:
                cardface = "jack";
                break;
            case 12:
                cardface = "queen";
                break;
            case 13:
                cardface = "king";
                break;
            default:
                cardface = n.ToString();
                break;
        }
        return cardface + cardtype;
    }
}