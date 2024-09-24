namespace TheFool;
    public class Card{
        public SuitType Suit{get; set;} 
        public RankType Rank{get;set;}       
        public Card(){}
        public Card (SuitType _suit, RankType _rank){
            Suit = _suit;
            Rank = _rank;
        }
    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }

    public static bool operator ==(Card card1, Card card2){
        return (card1.Suit==card2.Suit &&card1.Rank==card2.Rank);
    }

    public static bool operator !=(Card card1, Card card2){
        return !(card1==card2);
    }

    public static bool operator>(Card card1, Card card2){
        if(card1.Suit==card2.Suit){
            return card1.Rank>card2.Rank;
        }
        
    }
    public static bool operator <(Card card1, Card card2){
        return !(card1>card2);
    }
    
}
