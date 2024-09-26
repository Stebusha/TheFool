using System.Diagnostics;

namespace TheFool;
public class Player:IPlayer {
    
    public bool Attacking{get; set;}
    public bool Defending{get; set;}
    public bool SuccesfulDefended{get; set;}

    public bool TurnStarted{get;set;}

    public PlayerHand playerHand = new PlayerHand();

    public Player(){
        Console.WriteLine("Введите имя: ");
        Name = Console.ReadLine();

    }
    public int TurnNumber{get;set;}
    public string Name{get;set;}
    public List<Card> GetCards(){
        return playerHand.cards;
    }
    public void RefillHand(Deck deck){      
        playerHand.cards = deck.DrawCards(6-playerHand.NumberOfCardsRemainingRemaining);
        playerHand.Sort();
        // Console.WriteLine("Cards:");
        // foreach(var c in playerHand.cards){
        //     Console.WriteLine(c);
        // }
        Console.WriteLine(ToString(playerHand.cards));
            
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
    public List<Card> GetCardsForAttack(Table gameTable){
        List <Card> cardsForAttack = new List<Card>();
        if(gameTable.Length()==0){
            cardsForAttack = playerHand.cards;
            return cardsForAttack;
        }
        else if(CanBeAttacking(playerHand.cards,gameTable)){ 
            foreach(var card in playerHand.cards){
                for(int i=0;i<gameTable.Length();i++){
                    if(card.Rank==gameTable.GetCard(i).Rank){
                        cardsForAttack.Add(card);
                    }
                }
            }       
        }
        return cardsForAttack;
    }
    public void Attack(Table gameTable){
        Attacking = CanBeAttacking(playerHand.cards,gameTable);
        if(Attacking){
            List<Card> attackingCards = GetCardsForAttack(gameTable);
            Console.WriteLine(ToString(attackingCards));
            Console.WriteLine("Выберите порядковый номер карты, которой хотите походить: ");
            int index = Convert.ToInt32(Console.ReadLine())-1;            
            Console.WriteLine(index);
            Card attackingCard = attackingCards[index];
            Console.WriteLine(attackingCard.ToString());
            gameTable.AddCardToTable(attackingCard);
            playerHand.RemoveCardFromHand(attackingCard);
            attackingCards.Remove(attackingCard);
        }
        else if(playerHand.NumberOfCardsRemainingRemaining==0){
            Attacking = false;
        }
    }
    private bool CanBeDefended(List<Card> attackingCards, Table gameTable){
        if (gameTable.Length()<1){
            SuccesfulDefended = false;
            return SuccesfulDefended;
        }
        else{
            List<bool> defended = new List<bool>();
            for(int i=1;i<gameTable.Length();i+=2){
                foreach(var card in attackingCards){
                    if(card>gameTable.GetCard(i)){
                        defended.Add(true);
                    }   
                }
            }
            if(defended.Count >= gameTable.Length()/2){
                return true;
            }    
            SuccesfulDefended = false;
            return SuccesfulDefended;
        }
    }
    private List<Card> GetCardsforDefense(Table gameTable){
        List<Card> defenseCards = new List<Card>();
        if (gameTable.Length()!=0){
            for(int i=0;i<gameTable.Length();i+=2){
                foreach(var card in playerHand.cards){
                    if(card>gameTable.GetCard(i)){
                        Console.WriteLine(card.ToString()+ " - "+(card>gameTable.GetCard(i)).ToString());
                        defenseCards.Add(card);
                    }   
                }
            }
        }
        return defenseCards;    
    }
    public void Defend(List<Card> attackingCards, Table gameTable){
        Defending = CanBeDefended(attackingCards,gameTable);
        if(Defending){
            List<Card> defendingCards = GetCardsforDefense(gameTable);
            Console.WriteLine(ToString(defendingCards));
            Console.WriteLine("Выберите порядковый номер карты, которой хотите отбиться: ");
            int index = Convert.ToInt32(Console.ReadLine())-1;           
            
            Card defendingCard =defendingCards[index];
            Console.WriteLine("Вы отбились картой: " +defendingCard.ToString());
            gameTable.AddCardToTable(defendingCard);
            playerHand.RemoveCardFromHand(defendingCard);
            defendingCards.RemoveAt(index);
            
        } 
        else if(playerHand.NumberOfCardsRemainingRemaining==0){
            Defending = false;
            SuccesfulDefended = true;
        }      
    }
    
    public string ToString(List<Card> cards)
    {
        string cardDrawnString = "";
        cardDrawnString = "\nКарты игрока "+ Name+"\n";
        for(int i = 0;i<cards.Count;i++){
            Card tempCard = cards[i];
            cardDrawnString+=tempCard.ToString()+"\t";
        } 
        return cardDrawnString;
    }
}