using System;

namespace TheFool;
public class Card
{
    public SuitType Suit { get; set; }
    public RankType Rank { get; set; }

    public Card() { }
    public Card(SuitType _suit, RankType _rank)
    {
        Suit = _suit;
        Rank = _rank;
    }

    //return rank string for card output based on RankType
    private string GetRankName(RankType rank)
    {
        string rankName = string.Empty;

        switch (rank)
        {
            case RankType.Six:
                rankName = "6";
                break;
            case RankType.Seven:
                rankName = "7";
                break;
            case RankType.Eight:
                rankName = "8";
                break;
            case RankType.Nine:
                rankName = "9";
                break;
            case RankType.Ten:
                rankName = "10";
                break;
            case RankType.Jack:
                rankName = "J";
                break;
            case RankType.Queen:
                rankName = "Q";
                break;
            case RankType.King:
                rankName = "K";
                break;
            case RankType.Ace:
                rankName = "A";
                break;
        }

        return rankName;
    }

    //return suit unicode char string for card output based on SuitType 
    private string GetSuitName(SuitType suit)
    {
        string suitName = string.Empty;

        switch (suit)
        {
            case SuitType.Clubs:
                suitName = "♣";
                break;
            case SuitType.Hearts:
                suitName = "♥";
                break;
            case SuitType.Spades:
                suitName = "♠";
                break;
            case SuitType.Diams:
                suitName = "♦";
                break;
        }

        return suitName;
    }

    //card output
    public override string ToString() => $"{GetRankName(Rank)}{GetSuitName(Suit)}";

    //ovveride operators
    public static bool operator ==(Card card1, Card card2)
    {
        return card1.Suit == card2.Suit && card1.Rank == card2.Rank;
    }

    public static bool operator !=(Card card1, Card card2)
    {
        return !(card1 == card2);
    }

    public static bool operator >(Card card1, Card card2)
    {
        //same suit
        if (card1.Suit == card2.Suit)
        {
            return card1.Rank > card2.Rank;
        }
        //first trump
        else if (card1.Suit == Deck.s_trumpSuit && card2.Suit != Deck.s_trumpSuit)
        {
            return true;
        }
        //second trump
        else if (card1.Suit != Deck.s_trumpSuit && card2.Suit == Deck.s_trumpSuit)
        {
            return false;
        }
        //all another cases
        else
        {
            return false;
        }
    }

    public static bool operator <(Card card1, Card card2)
    {
        //same suit
        if (card1.Suit == card2.Suit)
        {
            return card1.Rank < card2.Rank;
        }
        //first trump
        else if (card1.Suit == Deck.s_trumpSuit && card2.Suit != Deck.s_trumpSuit)
        {
            return false;
        }
        //second trump
        else if (card1.Suit != Deck.s_trumpSuit && card2.Suit == Deck.s_trumpSuit)
        {
            return true;
        }
        //all another cases
        else
        {
            return false;
        }
    }

    public static bool operator >=(Card card1, Card card2)
    {
        //same rank, suit
        if (card1.Suit == card2.Suit && card1.Rank == card2.Rank)
        {
            return true;
        }
        //first trump
        else if (card1.Suit == Deck.s_trumpSuit && card2.Suit != Deck.s_trumpSuit)
        {
            return true;
        }
        //second trump
        else if (card2.Suit == Deck.s_trumpSuit && card1.Suit != Deck.s_trumpSuit)
        {
            return false;
        }
        //not the same suit, not trump
        else if (card1.Suit != card2.Suit)
        {
            return false;
        }
        //same suit for trumps
        else if (card1.Suit == card2.Suit && card1.Suit == Deck.s_trumpSuit)
        {
            return card1.Rank > card2.Rank;
        }
        //all another cases
        else
        {
            return card1.Rank > card2.Rank;
        }
    }

    public static bool operator <=(Card card1, Card card2)
    {
        //same rank, suit
        if (card1.Suit == card2.Suit && card1.Rank == card2.Rank)
        {
            return true;
        }
        //first trump
        else if (card1.Suit == Deck.s_trumpSuit && card2.Suit != Deck.s_trumpSuit)
        {
            return false;
        }
        //second trump
        else if (card2.Suit == Deck.s_trumpSuit && card1.Suit != Deck.s_trumpSuit)
        {
            return true;
        }
        //not the same suit
        else if (card1.Suit != card2.Suit)
        {
            return false;
        }
        //same suit for trumps
        else if (card1.Suit == card2.Suit && card1.Suit == Deck.s_trumpSuit)
        {
            return card1.Rank < card2.Rank;
        }
        //all another cases
        else
        {
            return card1.Rank < card2.Rank;
        }
    }

    // override object.Equals
    public override bool Equals(object? card)
    {
        if (card is null)
        {
            throw new ArgumentNullException(nameof(card));
        }

        return this == (Card)card;
    }

    // override object.GetHashCode
    public override int GetHashCode()
    {
        return 9 * (int)Suit + (int)Rank;
    }

}
