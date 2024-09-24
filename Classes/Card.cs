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
}
