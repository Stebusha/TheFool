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
            cards.OrderBy(c=>c.Rank).ToList();
        }
    }    

}
