namespace TheFool
{
    public class PlayerHand{
        public List<Card> cards = new List<Card>();
        public int numberOfCardsRemaining = 0;
        public void AddCardToHand(Card card){
            cards.Add(card);
            numberOfCardsRemaining++;
            Sort();
        }
        public void AddCardsToHand(List<Card> cards){
            foreach(var card in cards){
                cards.Add(card);
            }
            numberOfCardsRemaining = cards.Count;
            Sort();
        }
        public void RemoveCardFromHand(Card card){
            cards.Remove(card);
            numberOfCardsRemaining--;
            Sort();
        }
        public Card ChooseCardFromHand(int number){
            Card chosenCard = new Card();
            chosenCard = cards.ElementAt(number);
            RemoveCardFromHand(chosenCard);
            Sort();
            return chosenCard;
        }
        public void Sort(){
            cards = cards.OrderBy(c=>c.Rank).ToList();
            List<Card> trumpCards = new List<Card>();
            foreach(var card in cards){
                if(card.Suit==Deck.trumpSuit){
                    trumpCards.Add(card);
                }
            }
            //Console.WriteLine();
            //Console.WriteLine("Trumps:");
            //foreach (var trump in trumpCards){
            //    Console.WriteLine(trump);
            //}
            if(trumpCards!=null){
                foreach(var trump in trumpCards){
                    cards.Remove(trump);
                }
            }
            //Console.WriteLine();
            //Console.WriteLine("Without Trumps:");
            //foreach (var card in cards){
            //    Console.WriteLine(card);   
            //}
            //Console.WriteLine();
            trumpCards = trumpCards.OrderBy(t=>t.Rank).ToList();
            foreach (var trump in trumpCards){
                cards.Add(trump);
            }
            //Console.WriteLine("Sorted:");
            //foreach (var card in cards){
            //    Console.WriteLine(card);
            //}
            
        }
    }    

}
