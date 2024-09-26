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