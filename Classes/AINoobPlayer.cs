namespace TheFool;
public class AINoobPlayer:AIPlayer{
    public AINoobPlayer(){
        Name = "Bot-Noob";
    }
    PlayerHand playerHand;
    private void MakeDecision(){
        Table gameTable = new Table();
        Attack(gameTable);
    }
  
}