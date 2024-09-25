namespace TheFool;

public interface IPlayer{
    public string Name{get;set;}
    public int TurnNumber{get;set;}
    public void RefillHand(Deck deck);

    public void Attack(int index, GameRiver gameRiver);
    public void Defend(int index, GameRiver gameRiver);
}