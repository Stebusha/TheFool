namespace TheFool
{
    public class Table{
        private List<Card> onTable = new List<Card>();
        private int tableCardRemaining = 0;

        public Card GetCard(int index){
            return onTable[index];
        }
        
        public int Length(){
            return onTable.Count;
        }
        public void AddCardToTable(Card card){
            onTable.Add(card);
            tableCardRemaining++;
        }

        public void RemoveCardFromTable(Card card){
            onTable.Remove(card);
            tableCardRemaining = onTable.Count;
        }

        public void ClearTable(){
            onTable.Clear();
        }

        // public bool GameTableComparison(){
        //     bool defended = false;
        //     string defendingString = "";

        //     switch(gameRiver.Count){
        //         case 2:
        //         if(gameRiver[1].Suit>gameRiver[0].Suit|gameRiver[1].Suit == Deck.trumpSuit){
        //             if(gameRiver[1]>gameRiver[0]|gameRiver[1].Suit==Deck.trumpSuit){
        //                 defendingString+="\nЭта карта отбита: "+gameRiver[1].ToString();
        //                 defended = true;
        //             }
        //             else{
        //                 defendingString+="\nКарта не отбита: "+gameRiver[1].ToString();
        //             }
        //         }
        //         else {
        //             defendingString+="\nНе та масть";
        //         }
        //         break;
        //         case 4:
        //         if(gameRiver[3].Suit>gameRiver[2].Suit|gameRiver[3].Suit == Deck.trumpSuit){
        //             if(gameRiver[3]>gameRiver[2]|gameRiver[3].Suit==Deck.trumpSuit){
        //                 defendingString+="\nЭта карта отбита: "+gameRiver[3].ToString();
        //                 defended = true;
        //             }
        //             else{
        //                 defendingString+="\nКарта не отбита: "+gameRiver[3].ToString();
        //             }
        //         }
        //         else {
        //             defendingString+="\nНе та масть";
        //         }
        //         break;
        //         case 6:
        //         if(gameRiver[5].Suit>gameRiver[4].Suit|gameRiver[5].Suit == Deck.trumpSuit){
        //             if(gameRiver[5]>gameRiver[4]|gameRiver[5].Suit==Deck.trumpSuit){
        //                 defendingString+="\nЭта карта отбита: "+gameRiver[5].ToString();
        //                 defended = true;
        //             }
        //             else{
        //                 defendingString+="\nКарта не отбита: "+gameRiver[5].ToString();
        //             }
        //         }
        //         else {
        //             defendingString+="\nНе та масть";
        //         }
        //         break;
        //         case 8:
        //         if(gameRiver[7].Suit>gameRiver[6].Suit|gameRiver[7].Suit == Deck.trumpSuit){
        //             if(gameRiver[7]>gameRiver[6]|gameRiver[7].Suit==Deck.trumpSuit){
        //                 defendingString+="\nЭта карта отбита: "+gameRiver[7].ToString();
        //                 defended = true;
        //             }
        //             else{
        //                 defendingString+="\nКарта не отбита: "+gameRiver[7].ToString();
        //             }
        //         }
        //         else {
        //             defendingString+="\nНе та масть";
        //         }
        //         break;
        //         case 10:
        //         if(gameRiver[9].Suit>gameRiver[8].Suit|gameRiver[9].Suit == Deck.trumpSuit){
        //             if(gameRiver[9]>gameRiver[8]|gameRiver[9].Suit==Deck.trumpSuit){
        //                 defendingString+="\nЭта карта отбита: "+gameRiver[9].ToString();
        //                 defended = true;
        //             }
        //             else{
        //                 defendingString+="\nКарта не отбита: "+gameRiver[9].ToString();
        //             }
        //         }
        //         else {
        //             defendingString+="\nНе та масть";
        //         }
        //         break;
        //         case 12:
        //         if(gameRiver[11].Suit>gameRiver[10].Suit|gameRiver[11].Suit == Deck.trumpSuit){
        //             if(gameRiver[11]>gameRiver[10]|gameRiver[11].Suit==Deck.trumpSuit){
        //                 defendingString+="\nЭта карта отбита: "+gameRiver[1].ToString();
        //                 defended = true;
        //             }
        //             else{
        //                 defendingString+="\nКарта не отбита: "+gameRiver[11].ToString();
        //             }
        //         }
        //         else {
        //             defendingString+="\nНе та масть";
        //         }
        //         break;
                
        //     }
        //     return defended;
        // }

        public string ToString(List<Card> onTable){
            string onTableString = "";
            onTableString = "\n\n Карты в игре: \t";
            for(int i=0;i<onTable.Count;i++){
                Card tempCard = onTable[i];
                onTableString+=tempCard.ToString();
            }
            return onTableString;

        }
    }
}