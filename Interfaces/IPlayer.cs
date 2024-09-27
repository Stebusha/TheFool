namespace TheFool;

public interface IPlayer{
    public string Name{get;set;}
    public int TurnNumber{get;set;}
    public bool Attacking{get; set;}
    public bool Defending{get; set;}
    public bool SuccesfulDefended{get; set;}

    public bool Taken{get; set;}
    public void RefillHand(Deck deck);

    public List<Card> GetCards();
    public List<Card> GetCardsForAttack(Table gameTable);

    public void Attack(Table gameTable);
    public void Defend(List<Card> attackingCards,Table gameTable);

    public void TakeAllCards(Table gameTable);
}