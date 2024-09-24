namespace TheFool
{
    public class GameRiver{
        private List<Card> gameRiver = new List<Card>();
        private int riverCardRemaining = 0;

        public void AddCardToRiver(Card card){
            gameRiver.Add(card);
            riverCardRemaining++;
        }

        public void RemoveCardFromRiver(Card card){
            gameRiver.Remove(card);
            riverCardRemaining = gameRiver.Count;
        }

        public void ClearRiver(){
            gameRiver.Clear();
        }

        public bool GameRiverComparison(Deck deck){
            bool defended = false;

            switch(gameRiver.Count){
                
            }
            return defended;
        }

    }
}