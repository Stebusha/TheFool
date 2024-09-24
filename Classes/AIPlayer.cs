namespace TheFool;
public class AIPlayer:IPlayer{
    
    PlayerHand playerHand;
    private int turnNumber = -1;
    private bool isAttacking = false;
    private bool isDefending = false;
    private float handValue = -1f;
    public string Name{get; set;}
    public AIPlayer(){
        Name = "Bot-Hard";
    }
    public void RefillHand(Deck deck){
                deck.DrawCards(6-playerHand.numberOfCardsRemaining);
        playerHand.Sort();
    }

    public void Attack(Card attackingCard, GameRiver gameRiver){

    }
    public void Defend(Card defendingCard, GameRiver gameRiver){

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

    protected virtual void MakeDecision(List<Card> inHand, float handValue){
        
    }

}