namespace TheFool
{
    public class Card{
        public readonly SuitType suit;
        public readonly RankType rank;
        private bool isTrump = false;

        public Card(){}
        public Card (SuitType _suit, RankType _rank, bool _trump){
            suit = _suit;
            rank = _rank;
            isTrump = _trump;
        }

        public bool IsTrump{
            get{
                return isTrump;
            }
            set{
                isTrump = value;
            }
        }

        public SuitType GetCardSuit() {
            return suit;
        }

        public RankType GetCardRank(){
            return rank;
        }
    }
}
