
namespace TheFool;
public class Player:IPlayer {
    
    private int turnNumber=-1;
    private bool isAttacking=false;
    private bool isDefending=false;

    public PlayerHand playerHand = new PlayerHand();

    public Player(){
        //Console.WriteLine("Введите имя: ");
        //Name = Console.ReadLine();

    }

    public string Name{get;set;}
    public void RefillHand(Deck deck){      
        playerHand.cards = deck.DrawCards(6-playerHand.numberOfCardsRemaining);
        playerHand.Sort();
        Console.WriteLine("Cards:");
        foreach(var c in playerHand.cards){
            Console.WriteLine(c);
        }
            
    }

    public void Attack(Card attackingCard, GameRiver gameRiver){

    }

    public void Defend(Card defendingCard, GameRiver gameRiver){

    }
}