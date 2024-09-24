    public class Card{
        public readonly SuitType suit;
        public readonly RankType rank;
        public Card(){}
        public Card (SuitType _suit, RankType _rank){
            suit = _suit;
            rank = _rank;
        }
        public SuitType GetCardSuit() {
            return suit;
        }
        public RankType GetCardRank(){
            return rank;
        }
    }
