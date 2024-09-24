using System;
using System.Collections;
using System.Collections.Generic;

namespace TheFool
{
    public class Deck{
        private List<Card> cards = new List<Card>();
        private int cardsAmount = 36;

        private SuitType trumpSuit = SuitType.Clubs;

        public SuitType GetTrumpSuit() {
            return trumpSuit;
        }
        
        public void Shuffle(List<Card> cards){
            cards.Sort((a,b) => _random.Next(-2,2));
        }

        public Card DrawCards(int count){
            List<Card> drawnCards = new List<Card>();

            for(int i=0;i<count;i++){
                drawnCards.Add(cards.ElementAt(0));
                cards.RemoveAt(0);
                cardsAmount--;
            }
            return drawnCards;
        }

        public CardsAmount{get; private set;}

        public SuitType Trump(List<Card> cards){
            Card trumpCard;
            trumpCard = cards.ElementAt(0);
            cards.RemoveAt(0);
            cards.Add(trumpCard);
            return trumpCard.suit;
        }

        public void DealCardsToPlayers(List<Card> cards, List<Player, AIPlayer> players){
            for(int p = 0;p<players.Count;p++){
                players[p].playerHand.cards = DrawCards(6);
            }
        }
    }
}
