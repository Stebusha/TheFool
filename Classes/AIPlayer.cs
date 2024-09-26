namespace TheFool;
public class AIPlayer:IPlayer{
    
    PlayerHand playerHand = new PlayerHand();
    public bool Attacking{get; set;}
    public bool Defending{get; set;}
    public bool SuccesfulDefended{get; set;}
    private float handValue = -1f;
    public string Name{get; set;}
    public int TurnNumber{get;set;}
    public AIPlayer(){
        Name = "Bot";
    }
    public List<Card> GetCards(){
        return playerHand.cards;
    }
    public void RefillHand(Deck deck){
        playerHand.cards = deck.DrawCards(6-playerHand.numberOfCardsRemaining);
        playerHand.Sort();
        //Console.WriteLine("Cards:");
        //foreach(var c in playerHand.cards){
        //    Console.WriteLine(c);
        //}
    }
    public void Attack(Table gameTable){
        Attacking = CanBeAttacking(playerHand.cards,gameTable);
        if(Attacking){
            List<Card> attackingCards = GetCardsForAttack(gameTable);
            int index = MakeDecision();
            Card attackingCard = attackingCards[0];
            Console.WriteLine("Бот походил картой: "+ attackingCard.ToString());
            gameTable.AddCardToTable(attackingCard);
            playerHand.RemoveCardFromHand(attackingCard);
        }
        else if(playerHand.numberOfCardsRemaining==0){
            Attacking = false;
        }
    }
    public List<Card> GetCardsForAttack(Table gameTable){
        List <Card> cardsForAttack = new List<Card>();
        if(CanBeAttacking(playerHand.cards,gameTable)){
            if(gameTable.Length()==0){
                return playerHand.cards;
            }
            else{
                foreach(var card in playerHand.cards){
                    for(int i=0;i<gameTable.Length();i++){
                        if(card.Rank==gameTable.GetCard(i).Rank){
                            cardsForAttack.Add(card);
                        }
                    }
                }
            }            
        }
        return cardsForAttack;
    }

    private bool CanBeAttacking(List<Card> cards, Table gameTable){
        if (gameTable.Length() == 0){
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
            if(defended.Count >= gameTable.Length()/2){
                return true;
            }    
            return false;
        }
    }

    public void Defend(List<Card> attackingCards, Table gameTable){
        Defending = CanBeDefended(playerHand.cards,gameTable);
        if(Defending){
            List<Card> defendingList = new List<Card>();
            foreach(var card in playerHand.cards){
                if(card>gameTable.GetCard(0)){
                    defendingList.Add(card);
                }
                
            }
            Card defendingCard =defendingList[0];
            defendingList.RemoveAt(0);
            gameTable.AddCardToTable(defendingCard);
            playerHand.RemoveCardFromHand(defendingCard);

        }
        else if(playerHand.numberOfCardsRemaining==0){
            Defending = false;
        } 
        else{
            for(int i=0;i<gameTable.Length();i++){
                playerHand.cards.Add(gameTable.GetCard(i));
                playerHand.Sort();
            }
        }
    }

    private List<int> CardValue(List<Card> inHand, string trumpSuit){
        List<int> valueCost = new List<int>();
        for(int i=-400;i<=400;i++){
        valueCost.Add(i);
        i+=100;
        }
        string[] ranks = {"6","7", "8", "9", "10", "J","Q", "K", "A"};
        foreach(var rank in ranks){
            foreach (var card in inHand){
                
            }
        }
      
        return valueCost;
    }

    private float HandValue(List<Card> inHand, string trumpSuit, List<int> values){
        
        return handValue;
    }

    protected virtual int MakeDecision(){
        return 0;
    }

}