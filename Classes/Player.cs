
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
        Console.WriteLine(ToString(playerHand.cards,turnNumber));
            
    }

    public void Attack(){
        Console.WriteLine("Выберите порядковый номер карты, которой хотите походить: ");
        int index = Convert.ToInt32(Console.Read())+1;
        Card attackingCard = playerHand.cards.ElementAt(index);
        Console.WriteLine(attackingCard.ToString());
    }

    public void Defend(Card defendingCard, GameRiver gameRiver){

    }

    public string ToString(List<Card> cards, int turnNumber)
    {
        string cardDrawnString = "";
        cardDrawnString = "\nКарты игрока "+ turnNumber.ToString()+"\n";
        for(int i = 0;i<cards.Count;i++){
            Card tempCard = playerHand.GetCard(i);
            cardDrawnString+=tempCard.ToString()+"\t";
        } 
        return cardDrawnString;
    }
}