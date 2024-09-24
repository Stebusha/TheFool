namespace TheFool
{
    public class PlayerHand{
        public List<Card> cards = new List<Card>();
        public int numberOfCardsRemaining = 0;


        public void AddCardToHand(Card card){
            
        }
        public void AddCardsToHand(List<Card> cards){

        }
        public void RemoveCardFromHand(Card card){
            cards.Remove(card);
            numberOfCardsRemaining++;
        }
        public Card ChooseCardFromHand(int number){
            Card chosenCard = new Card();
            chosenCard = cards.ElementAt(number);
            return chosenCard;
        }

        

        public void Sort(){
            cards.OrderBy(c=>c.Suit).ToList();
        }
    }    

}
