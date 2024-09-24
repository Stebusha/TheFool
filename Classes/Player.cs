namespace TheFool;
public class Player:IPlayer {
    private string name = 'Player';
    private int turnNumber=-1;
    private bool isAttacking=false;
    private bool isDefending=false;

    private PlayerHand playerHand;

    public string Name{get;set;}
    public void RefillHand(Deck deck){
        playerHand.cards = deck.DrawCards(playerHand.numberOfCardsRemaining);
    }

    public void Attack(Card attackingCard, GameRiver gameRiver){

    }

    public void Defend(Card defendingCard, GameRiver gameRiver){

    }
}