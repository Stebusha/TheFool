namespace TheFool;
public class AIPlayer:IPlayer {
    private string name = 'Bot-Hard';
    private int turnNumber = -1;
    private bool isAttacking = false;
    private bool isDefending = false;

    private float handValue = -1f;

    public string Name{get;private set;}
    public void RefillHand(Deck deck){
        playerHand.cards = deck.DrawCards(playerHand.numberOfCardsRemaining);
    }

    public void Attack(Card attackingCard, GameRiver gameRiver){

    }
    public void Defend(Card defendingCard, GameRiver gameRiver){

    }

    private List<int> CardValue(List<Card> inHand, SuitType trumpSuit){
        List<int> values = new List<int>();

        return values;
    }

    private float HandValue(List<Card> inHand, SuitType trumpSuit, List<int> values){
 
        return handValue;
    }

    protected virtual void MakeDecision(){
        
    }

}