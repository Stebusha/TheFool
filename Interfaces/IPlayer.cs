namespace TheFool;

public interface IPlayer{
    public string Name{get;set;}
    public int TurnNumber{get;set;}
    public void RefillHand(Deck deck);

    public List<Card> GetCards();

    public void Attack(Table gameTable);
    public void Defend(Table gameTable);
}