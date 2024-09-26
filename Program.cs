namespace TheFool;

class Program
{
    static void Main(string[] args)
    {
        GameController game = new GameController();
        game.Game(1,1);
        //game.TestComparison(new Card(SuitType.Diams,RankType.Jack),new Card(SuitType.Diams,RankType.Queen));
    }
}