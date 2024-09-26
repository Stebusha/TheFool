namespace TheFool;
public class AINoobPlayer:AIPlayer{
    
    private bool isAttacking = false;
    private bool isDefending = false;

    public AINoobPlayer(){
        Name = "Bot-Noob";
    }
    PlayerHand playerHand;
    private void MakeDecision(){
        Table gameTable = new Table();
        Attack(gameTable);
    }
  
}