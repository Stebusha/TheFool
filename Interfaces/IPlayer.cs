namespace TheFool;

public interface IPlayer{
    public string Name{get;set;}
    public void RefillHand(Deck deck);

    public void Attack( );
    public void Defend(Card defendingCard, GameRiver gameRiver);
}