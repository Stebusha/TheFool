namespace TheFool;
public class AINoobPlayer:AIPlayer{
    private string name = 'Bot-Noob';
    private int turnNumber = -1;
    private bool isAttacking = false;
    private bool isDefending= false;
    private int minValue = 0;
    public string Name{get;private set;}
    public void RefillHand(Deck deck){
        playerHand.cards = deck.DrawCards(playerHand.numberOfCardsRemaining);
    }

    public void Attack(Card attackingCard, GameRiver gameRiver)[

    ]
    public void Defend(Card defendingCard, GameRiver gameRiver){

    }
    protected virtual void MakeDecision(int minValue){
        
    }
}