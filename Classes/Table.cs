using System;
using System.Collections.Generic;

namespace TheFool
{
    public class Table{
        private List<Card> onTable = new List<Card>();
        public Card GetCard(int index){
            return onTable[index];
        }       
        public int Length(){
            return onTable.Count;
        }
        public List<Card> TakeCardsFromTable(){
            return  onTable;
        }
        public void AddCardToTable(Card card){
            onTable.Add(card);
        }
        public void RemoveCardFromTable(Card card){
            onTable.Remove(card);
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