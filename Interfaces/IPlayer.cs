namespace TheFool;

interface IPlayer{
    private string name = 'Bot';
    private int turnNumber;
    private bool isAttacking;
    private bool isDefending;

    public string Name{get;set;}
    public void RefillHand(Deck deck);

    public void Attack(Card attackingCard, GameRiver gameRiver);
    public void Defend(Card defendingCard, GameRiver gameRiver);
}