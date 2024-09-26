
using System.ComponentModel;

namespace TheFool;
public class Player:IPlayer {
    
    private bool isAttacking=false;
    private bool isDefending=false;

    public PlayerHand playerHand = new PlayerHand();

    public Player(){
        //Console.WriteLine("Введите имя: ");
        //Name = Console.ReadLine();

    }
    public int TurnNumber{get;set;}
    public string Name{get;set;}
    public List<Card> GetCards(){
        return playerHand.cards;
    }
       public void RefillHand(Deck deck){      
        playerHand.cards = deck.DrawCards(6-playerHand.numberOfCardsRemaining);
        playerHand.Sort();
        // Console.WriteLine("Cards:");
        // foreach(var c in playerHand.cards){
        //     Console.WriteLine(c);
        // }
        Console.WriteLine(ToString(playerHand.cards,TurnNumber));
            
    }

    public void Attack(Table gameTable){
        isAttacking = CanBeAttacking(playerHand.cards,gameTable);
        if(isAttacking){
            Console.WriteLine("Выберите порядковый номер карты, которой хотите походить: ");
            int index = Convert.ToInt32(Console.ReadLine())-1;            
            Console.WriteLine(index);
            Card attackingCard = playerHand.ChooseCardFromHand(index);
            attackingCard = playerHand.ChooseCardFromHand(index);
            Console.WriteLine(attackingCard.ToString());
            gameTable.AddCardToTable(attackingCard);
            playerHand.RemoveCardFromHand(attackingCard);
        }
        else if(playerHand.numberOfCardsRemaining==0){
            isAttacking = false;
        }

        // isAttacking = true;
        // if(isAttacking){
        //     Card attackingCard = new Card();
        //     if(playerHand.numberOfCardsRemaining!=0){
        //         Console.WriteLine(ToString(playerHand.cards,TurnNumber));
        //         Console.WriteLine("Выберите порядковый номер карты, которой хотите походить: ");
        //         int index = Convert.ToInt32(Console.ReadLine())-1;
        //         Console.WriteLine(index);
        //         attackingCard = playerHand.ChooseCardFromHand(index);
        //         Console.WriteLine(attackingCard.ToString());        
                       
        //     }
            
        // }
    }
    private bool CanBeAttacking(List<Card> cards, Table gameTable){
        if (gameTable.Length() ==0){
            return true;
        }
        else{
            foreach(var card in cards){
                for(int i=0;i<gameTable.Length();i++){
                    if(card.Rank==gameTable.GetCard(i).Rank){
                        return true;
                    }
                }
            }
            return false;
        }
    }
    private bool CanBeDefended(List<Card> cards, Table gameTable){
        if (gameTable.Length()==0){
            return false;
        }
        else{
            List<bool> defended = new List<bool>();
            for(int i=0;i<gameTable.Length();i+=2){
                foreach(var card in cards){
                    if(card>gameTable.GetCard(i)){
                        defended.Add(true);
                    }
                    
                }
            }
            if(defended.Count == gameTable.Length()/2){
                return true;
            }    
            return false;
        }
    }

    public void Defend(Table gameTable){
        isDefending = CanBeDefended(playerHand.cards,gameTable);
        if(isDefending){
            Console.WriteLine("Выберите порядковый номер карты, которой хотите отбиться: ");
            int index = Convert.ToInt32(Console.ReadLine())-1;            
            Console.WriteLine(index);
            Card defendingCard =playerHand.ChooseCardFromHand(index);
            gameTable.AddCardToTable(defendingCard);
            playerHand.RemoveCardFromHand(defendingCard);

        }
        else if(playerHand.numberOfCardsRemaining==0){
            isDefending = false;
        }
        // List<Card> defendingList = new List<Card>();
        // bool succesfulDefended = false;
        // for (int i=0;i< gameRiver.Length(); i++){
        //     defendingList.Add(gameRiver.GetCard(i));
        // }

        // switch (gameRiver.Length()){
        //     case 1:
        //         if(defendingCard.Suit== defendingList[0].Suit&defendingCard>defendingList[0]|defendingCard.Suit==Deck.trumpSuit&defendingCard>defendingList[0]){
        //             gameRiver.AddCardToRiver(defendingCard);
        //             playerHand.RemoveCardFromHand(defendingCard);
        //             succesfulDefended = true;
        //             break;
        //         }break;
        //     case 3:
        //         if(defendingCard.Suit== defendingList[2].Suit&defendingCard>defendingList[2]|defendingCard.Suit==Deck.trumpSuit&defendingCard>defendingList[2]){
        //             gameRiver.AddCardToRiver(defendingCard);
        //             playerHand.RemoveCardFromHand(defendingCard);
        //             succesfulDefended = true;
        //             break;
        //         }break;
        //     case 5:
        //         if(defendingCard.Suit== defendingList[4].Suit&defendingCard>defendingList[4]|defendingCard.Suit==Deck.trumpSuit&defendingCard>defendingList[4]){
        //             gameRiver.AddCardToRiver(defendingCard);
        //             playerHand.RemoveCardFromHand(defendingCard);
        //             succesfulDefended = true;
        //             break;
        //         }break;
        //     case 7:
        //         if(defendingCard.Suit== defendingList[6].Suit&defendingCard>defendingList[6]|defendingCard.Suit==Deck.trumpSuit&defendingCard>defendingList[6]){
        //             gameRiver.AddCardToRiver(defendingCard);
        //             playerHand.RemoveCardFromHand(defendingCard);
        //             succesfulDefended = true;
        //             break;
        //         }break;
        //     case 9:
        //         if(defendingCard.Suit== defendingList[8].Suit&defendingCard>defendingList[8]|defendingCard.Suit==Deck.trumpSuit&defendingCard>defendingList[8]){
        //             gameRiver.AddCardToRiver(defendingCard);
        //             playerHand.RemoveCardFromHand(defendingCard);
        //             succesfulDefended = true;
        //             break;
        //         }break;
        //     case 11:
        //         if(defendingCard.Suit== defendingList[10].Suit&defendingCard>defendingList[10]|defendingCard.Suit==Deck.trumpSuit&defendingCard>defendingList[10]){
        //             gameRiver.AddCardToRiver(defendingCard);
        //             playerHand.RemoveCardFromHand(defendingCard);
        //             succesfulDefended = true;
        //             break;
        //         }
        //         break;

        // }

    }

    public string ToString(List<Card> cards, int turnNumber)
    {
        string cardDrawnString = "";
        cardDrawnString = "\nКарты игрока "+ turnNumber.ToString()+"\n";
        for(int i = 0;i<cards.Count;i++){
            Card tempCard = playerHand.GetCard(i);
            cardDrawnString+=tempCard.ToString()+"\t";
        } 
        return cardDrawnString;
    }
}