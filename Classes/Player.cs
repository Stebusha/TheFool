namespace TheFool;
public class Player:IPlayer {
    public bool TurnStarted{get;set;}
    PlayerHand playerHand = new PlayerHand();
    public Player(){
        Console.WriteLine("Введите имя: ");
        Name = Console.ReadLine();

    }
    public int TurnNumber{get;set;}
    public bool Taken{get; set;}
    public string Name{get;set;}
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
        //Console.WriteLine(ToString(playerHand.cards)); 
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
        cardsForAttack = cardsForAttack.Distinct().ToList();
        return cardsForAttack;
    }
    public void Attack(Table gameTable){
        bool isAttacking = CanBeAttacking(playerHand.cards,gameTable);
        if(isAttacking){
            List<Card> attackingCards = GetCardsForAttack(gameTable);
            if(attackingCards.Count!=0){
                Console.WriteLine(ToString(attackingCards));
                Console.WriteLine("Выберите порядковый номер карты, которой хотите походить: ");
                bool settingNumber = false;
                while(!settingNumber){
                    string number = Console.ReadLine();
                    if(int.TryParse(number, out var index)){
                        if((index-1)>=0&&(index-1)<attackingCards.Count){
                            settingNumber=true;
                            Card attackingCard = attackingCards[index-1];
                            Console.WriteLine($"Вы походили картой: {attackingCard}"/*attackingCard.ToString()*/);
                            gameTable.AddCardToTable(attackingCard);
                            playerHand.RemoveCardFromHand(attackingCard);
                            attackingCards.Remove(attackingCard);
                        } 
                        else{
                            Console.WriteLine("Нет такого номера. Введите порядковый номер повторно: ");
                        }
                    }
                    else{
                        Console.WriteLine("Некорректный ввод .Введите порядковый номер повторно: ");
                    }
                }
                
                //int index = Convert.ToInt32(Console.ReadLine())-1;            
                //Console.WriteLine(index);
                
            }
        }
    }
    private bool CanBeBeaten(Card attackingCard,Table gameTable){
        if(gameTable.Length()==0){
            return false;
        }
        else{
            foreach(var card in playerHand.cards){
                if(card>attackingCard){
                    return true;  
                }
            }
            return false;
        }  
    }
    private List<Card> GetCardsforDefense(Card attackingCard, Table gameTable){
        List<Card> defenseCards = new List<Card>();
        if (gameTable.Length()!=0){
            foreach(var card in playerHand.cards){
                if(card>attackingCard){
                    //Console.WriteLine(card.ToString()+ " - "+(card>gameTable.GetCard(i)).ToString());
                    defenseCards.Add(card);
                }   
            }
        }
        return defenseCards;    
    }
    private Card GetCardToDefend(Card attackingCard,Table gameTable){
        Card cardToDefend = new Card();
        List<Card> defendingCards = GetCardsforDefense(attackingCard,gameTable);
        if(defendingCards.Count!=0){
            Console.WriteLine(ToString(defendingCards));
            Console.WriteLine("Выберите порядковый номер карты, которой хотите отбиться: ");
            bool settingNumber = false;
            while(!settingNumber){
                string number = Console.ReadLine();
                if(int.TryParse(number, out var index)){
                    if((index-1)>=0&&(index-1)<defendingCards.Count){
                        settingNumber=true;
                        cardToDefend = defendingCards[index-1];
                    } 
                    else{
                        Console.WriteLine("Нет такого номера. Введите порядковый номер повторно: ");
                    }
                }
                else{
                    Console.WriteLine("Некорректный ввод .Введите порядковый номер повторно: ");
                }
            }        
            
        }
        return cardToDefend;
    }
    public void Defend(Card attackingCard, Table gameTable){
        bool beaten = CanBeBeaten(attackingCard,gameTable);
        Card defendingCard = GetCardToDefend(attackingCard,gameTable);
        if(beaten){
            Console.WriteLine($"Вы отбились картой: {defendingCard}" /*+defendingCard.ToString()*/);
            //Console.WriteLine($"{Name} отбился картой: "+defendingCard);
            gameTable.AddCardToTable(defendingCard);
            playerHand.RemoveCardFromHand(defendingCard);
            // SuccesfulDefended = true;
        }
        else{
            Console.WriteLine("Нечем отбиться");
            TakeAllCards(gameTable);
        }
    }
    public void TakeAllCards(Table gameTable){
        Taken = true;
        List<Card> onTableCards = gameTable.TakeCardsFromTable();
        playerHand.cards.AddRange(onTableCards);
        playerHand.Sort();
        Console.WriteLine("Вы взяли карты :" +ToString(playerHand.cards));
        // SuccesfulDefended=false;
    }
    public string ToString(List<Card> cards)
    {
        string cardDrawnString = "";
        cardDrawnString = "\nКарты игрока "+ Name+" \n";
        for(int i = 0;i<cards.Count;i++){
            Card tempCard = cards[i];
            cardDrawnString+=tempCard.ToString()+"\t";
        } 
        return cardDrawnString;
    }
}