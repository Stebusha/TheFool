using System;
using System.Collections.Generic;

namespace TheFool;
public class AIPlayer : IPlayer
{
    private const int REQUIRED_CARDS_COUNT = 6;
    PlayerHand playerHand = new PlayerHand();
    public string Name { get; set; } = "Бот";
    public int TurnNumber { get; set; }
    public bool Taken { get; set; }
    public bool IsFool { get; set; }
    public AIPlayer() { }
    public AIPlayer(string _name, bool _fool)
    {
        Name = _name;
        IsFool = _fool;
    }
    //return cards in hand
    public List<Card> GetCards() => playerHand.cards;

    //draw cards from deck
    public void RefillHand(Deck deck)
    {
        if (playerHand.cards.Count == 0)
        {
            playerHand.cards = deck.DrawCards(REQUIRED_CARDS_COUNT);
            playerHand.Sort();
        }
        else if (playerHand.cards.Count < REQUIRED_CARDS_COUNT)
        {
            playerHand.cards.AddRange(deck.DrawCards(REQUIRED_CARDS_COUNT - playerHand.cards.Count));
            playerHand.Sort();
        }
    }

    //check exist cards for attack
    private bool CanBeAttacking(List<Card> cards, Table gameTable)
    {
        if (gameTable.Length() == 0)
        {
            return true;
        }
        else
        {
            foreach (var card in cards)
            {
                for (int i = 0; i < gameTable.Length(); i++)
                {
                    if (card.Rank == gameTable.GetCard(i).Rank)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    //return cards for attack
    public List<Card> GetCardsForAttack(Table gameTable)
    {
        List<Card> cardsForAttack = new List<Card>();

        if (CanBeAttacking(playerHand.cards, gameTable))
        {
            if (gameTable.Length() == 0)
            {
                return playerHand.cards;
            }
            else
            {
                foreach (var card in playerHand.cards)
                {
                    for (int i = 0; i < gameTable.Length(); i++)
                    {
                        if (card.Rank == gameTable.GetCard(i).Rank)
                        {
                            cardsForAttack.Add(card);
                        }
                    }
                }
            }
        }

        cardsForAttack = cardsForAttack.Distinct().ToList();

        return cardsForAttack;
    }

    //attack card based on decision
    public Card Attack(Table gameTable)
    {
        bool Attacking = CanBeAttacking(playerHand.cards, gameTable);
        Card attackingCard = new Card();

        if (Attacking)
        {
            List<Card> attackingCards = GetCardsForAttack(gameTable);
            if (attackingCards.Count != 0)
            {
                int index = MakeDecision();
                attackingCard = attackingCards[index];
                Console.WriteLine($"\n{Name} походил картой: " + attackingCard.ToString());
                gameTable.AddCardToTable(attackingCard);
                //fixed
                //first card delete before defend, comparison with next card -> bug defend 
                playerHand.RemoveCardFromHand(attackingCard);

                return attackingCard;
            }
            else
            {
                return attackingCard;
            }
        }
        else
        {
            return attackingCard;
        }
    }

    //check attacking card can be beaten
    private bool CanBeBeaten(Card attackingCard, Table gameTable)
    {
        if (gameTable.Length() == 0)
        {
            return false;
        }
        else
        {
            foreach (var card in playerHand.cards)
            {
                if (card > attackingCard)
                {
                    return true;
                }
            }
            return false;
        }
    }

    //return  card to defend based on decision
    private Card GetCardToDefend(Card attackingCard)
    {
        Card cardToDefend = new Card();

        foreach (var card in playerHand.cards)
        {
            if (card > attackingCard)
            {
                cardToDefend = card;
                break;
            }
        }

        return cardToDefend;
    }

    //defend
    public void Defend(Card attackingCard, Table gameTable)
    {
        bool beaten = CanBeBeaten(attackingCard, gameTable);
        Card defendingCard = GetCardToDefend(attackingCard);

        if (beaten)
        {
            Console.WriteLine($"{Name} отбился картой: " + defendingCard);
            gameTable.AddCardToTable(defendingCard);
            playerHand.RemoveCardFromHand(defendingCard);
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nНечем отбиться");
            Console.ResetColor();
            TakeAllCards(gameTable);
        }
    }

    //taken all cards from the game table, set property Taken
    public void TakeAllCards(Table gameTable)
    {
        Taken = true;
        List<Card> onTableCards = gameTable.TakeCardsFromTable();
        playerHand.cards.AddRange(onTableCards);
        playerHand.Sort();

        if (playerHand.cards.Count != 0)
        {
            Console.WriteLine($"\n{Name} взял карты");
        }
    }

    //output cards for console
    public string ToString(List<Card> cards)
    {
        string cardDrawnString = string.Empty;
        cardDrawnString = "\nКарты игрока " + Name + "\n";

        for (int i = 0; i < cards.Count; i++)
        {
            Card tempCard = cards[i];
            cardDrawnString += tempCard.ToString() + "\t";
        }

        return cardDrawnString;
    }

    //return min card
    protected virtual int MakeDecision() => 0;
}