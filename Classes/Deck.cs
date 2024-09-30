using System;
using System.Collections;
using System.Collections.Generic;

namespace TheFool
{
    public class Deck{
        private List<Card> cards;
        private SuitType[] suits = {SuitType.Clubs,SuitType.Diams,SuitType.Hearts, SuitType.Spades};
        private RankType[] ranks = {RankType.Six, RankType.Seven, RankType.Eight,RankType.Nine,RankType.Ten,RankType.Jack,RankType.Queen,RankType.King,RankType.Ace}; 
        public static SuitType trumpSuit = SuitType.Clubs;
        public int CardsAmount{get; set;}

        public SuitType GetTrumpSuit() {
            return trumpSuit;
        }

        public Deck(){
            CardsAmount = 36;
            cards = new List<Card>(CardsAmount);
            foreach(var suit in  suits){
                foreach(var rank in ranks){
                    Card cardToCreate = new Card(suit,rank);
                    cards.Add(cardToCreate);
                }

            }
        }
        
        public void Shuffle(){
            Random _random = new Random();
            cards.Sort((a,b) => _random.Next(-2,2));
        }

        public List<Card> DrawCards(int count){
            List<Card> drawnCards = new List<Card>();

            for(int i=0;i<count;i++){
                drawnCards.Add(cards.ElementAt(0));
                cards.RemoveAt(0);
            }
            CardsAmount = cards.Count;
            return drawnCards;
        }

        public void Trump(){
            Card trumpCard;
            trumpCard = cards.ElementAt(0);
            cards.RemoveAt(0);
            cards.Add(trumpCard);
            trumpSuit = trumpCard.Suit;
        }
    }
}
