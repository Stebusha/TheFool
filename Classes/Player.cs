
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
    public void RefillHand(Deck deck){      
        playerHand.cards = deck.DrawCards(6-playerHand.numberOfCardsRemaining);
        playerHand.Sort();
        Console.WriteLine("Cards:");
        foreach(var c in playerHand.cards){
            Console.WriteLine(c);
        }
        Console.WriteLine(ToString(playerHand.cards,TurnNumber));
            
    }

    public void Attack(int index, GameRiver gameRiver){
        isAttacking = true;
        if(isAttacking){
            Card attackingCard = playerHand.ChooseCardFromHand(index);
            gameRiver.AddCardToRiver(attackingCard);
            playerHand.RemoveCardFromHand(attackingCard);
        }
        isAttacking = false;
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

    public void Defend(int index, GameRiver gameRiver){
        isDefending = true;
        if(isDefending){
            Card defendingCard =playerHand.ChooseCardFromHand(index);
            gameRiver.AddCardToRiver(defendingCard);
            if(gameRiver.GameRiverComparison()==true){
                isDefending = false;
                playerHand.RemoveCardFromHand(defendingCard);
            }
            else {
                gameRiver.RemoveCardFromRiver(defendingCard);
            }

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