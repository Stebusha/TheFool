namespace TheFool;
public class AINoobPlayer:AIPlayer{
    
    private int turnNumber = -1;
    private bool isAttacking = false;
    private bool isDefending = false;

    public AINoobPlayer(){
        Name = "Bot-Noob";
    }
    PlayerHand playerHand;
    private void MakeDecision(int minValue){
        GameRiver gameRiver = new GameRiver();
        Attack(playerHand.cards.ElementAt(0),gameRiver);
    }
  
}