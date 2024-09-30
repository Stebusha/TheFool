namespace TheFool;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GameController game = new GameController();
        
        game.Game(1,1);
        // List<Card> l1= new List<Card>{new Card(SuitType.Diams,RankType.Jack),new Card(SuitType.Diams,RankType.Queen)};
        // List<Card> l2= new List<Card>{new Card(SuitType.Spades,RankType.Jack),new Card(SuitType.Hearts,RankType.Queen)};
        // game.TestListOperation(l1,l2);
        
        //game.TestComparison(new Card(SuitType.Spades,RankType.King),new Card(SuitType.Hearts,RankType.Queen));
    }
}