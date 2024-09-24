namespace TheFool;
    public class Card{
        public string Suit{get; set;} 
        public string Rank{get;set;}       
        public Card(){}
        public Card (string _suit, string _rank){
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
    
}
