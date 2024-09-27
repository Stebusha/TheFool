namespace TheFool;
public class AIPlayer:IPlayer{
    
    PlayerHand playerHand = new PlayerHand();
    public bool Attacking{get; set;}
    public bool Defending{get; set;}
    public bool SuccesfulDefended{get; set;}
    private float handValue = -1f;
    public string Name{get; set;}
    public int TurnNumber{get;set;}

    public bool Taken{get;set;}
    public AIPlayer(){
        Name = "Bot";
    }
    public List<Card> GetCards(){
        return playerHand.cards;
    }
    public void RefillHand(Deck deck){
        if(playerHand.cards.Count==0){
            playerHand.cards = deck.DrawCards(6);
            playerHand.Sort();
        }
        else if(playerHand.cards.Count<6){
            playerHand.cards.AddRange(deck.DrawCards(6-playerHand.cards.Count));
            playerHand.Sort();
        }
        //Console.WriteLine("Cards:");
        //foreach(var c in playerHand.cards){
        //    Console.WriteLine(c);
        //}
    }
    public void Attack(Table gameTable){
        Attacking = CanBeAttacking(playerHand.cards,gameTable);
        if(Attacking){

            List<Card> attackingCards = GetCardsForAttack(gameTable);
            if(attackingCards.Count!=0){
                int index = MakeDecision();
                Card attackingCard = attackingCards[0];
                Console.WriteLine("Бот походил картой: "+ attackingCard.ToString());
                gameTable.AddCardToTable(attackingCard);
                playerHand.RemoveCardFromHand(attackingCard);
            }
            else{
                Attacking = false;
            }
            
        }
        else if(playerHand.NumberOfCardsRemainingRemaining==0){
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
            SuccesfulDefended = false;
            // for(int c=0;c<gameTable.Length();c++){
            //     playerHand.AddCardToHand(gameTable.GetCard(c));
            //     playerHand.Sort();
            // }
            // Console.WriteLine(ToString(playerHand.cards));
            return SuccesfulDefended;
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
            if(defendingList.Count!=0){
                Card defendingCard = defendingList[0];
                Console.WriteLine("Бот отбился картой: "+defendingCard);
                defendingList.RemoveAt(0);
                gameTable.AddCardToTable(defendingCard);
                playerHand.RemoveCardFromHand(defendingCard);
                //SuccesfulDefended = true;
                Defending = false;
            } 
            else if(attackingCards.Count==0){
                Defending = false;
                SuccesfulDefended = true;
            }
            else if(!SuccesfulDefended){
                TakeAllCards(gameTable);
                Defending = false;
                gameTable.ClearTable();
            }
        }           
    }

    public void TakeAllCards(Table gameTable){
        // for(int i=0;i<gameTable.Length();i++){
        //     playerHand.cards.Add(gameTable.GetCard(i));           
        // }
        // playerHand.Sort();
        Taken =true;
        List<Card> onTableCards = gameTable.TakeCardsFromTable();
        // for(int i=0;i<gameTable.Length();i++){
        //             playerHand.cards.Add(gameTable.GetCard(i));
        //             playerHand.Sort();
        //         }
        playerHand.cards.AddRange(onTableCards);
        playerHand.Sort();
        if(playerHand.cards.Count!=0){
            Console.WriteLine("Бот взял карты :" +ToString(playerHand.cards));
            SuccesfulDefended=false;
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