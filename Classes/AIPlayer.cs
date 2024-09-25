namespace TheFool;
public class AIPlayer:IPlayer{
    
    PlayerHand playerHand = new PlayerHand();
    private int turnNumber = -1;
    private bool isAttacking = false;
    private bool isDefending = false;
    private float handValue = -1f;
    public string Name{get; set;}
    public int TurnNumber{get;set;}
    public AIPlayer(){
        Name = "Bot-Hard";
    }
    public void RefillHand(Deck deck){
        playerHand.cards = deck.DrawCards(6-playerHand.numberOfCardsRemaining);
        playerHand.Sort();
        //Console.WriteLine("Cards:");
        //foreach(var c in playerHand.cards){
        //    Console.WriteLine(c);
        //}
    }

    public void Attack(int index, GameRiver gameRiver){

    }
    public void Defend(int index, GameRiver gameRiver){

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