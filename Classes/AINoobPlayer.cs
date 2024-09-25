namespace TheFool;
public class AINoobPlayer:AIPlayer{
    
    private bool isAttacking = false;
    private bool isDefending = false;

    public AINoobPlayer(){
        Name = "Bot-Noob";
    }
    PlayerHand playerHand;
    private void MakeDecision(){
        GameRiver gameRiver = new GameRiver();
        Attack(0,gameRiver);
    }
  
}