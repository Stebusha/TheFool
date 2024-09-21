using System;
using System.Collections;
using System.Collections.Generic;

namespace TheFool
{
    public class Deck{
        private List<Card> cards = new List<Card>();
        private int cardsAmount = 36;


        public void Shuffle(List<Card> cards){
            cards.sort((a,b) => _random.Next(-2,2));
        }

        public Card DrawCards(int count){
            List<Card> drawnCards = new List<Card>();

            for(int i=0;i<count;i++){
                drawnCards.Add(cards.ElementAt(0));
                cards.RemoveAt(0);
            }
            return drawnCards;
        }

        public CardsAmount{get; set;}

        public SuitType Trump(List<Card> cards){
            Card trumpCard;
            trumpCard = cards.ElementAt(0);
            cards.RemoveAt(0);

            //что-то для циклического сдвига в списке

            return trumpCard.suit;
        }

        public void DealCardsToPlayers(List<Card> cards){

        }
    }
}
