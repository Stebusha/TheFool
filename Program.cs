using System;
namespace TheFool;

class Program
{
    static void Main(string[] args)
    {
        //Console.Clear();
        GameController game = new GameController();  
        Console.WriteLine("Введите количество реальных игроков");
        string players = Console.ReadLine();
        Console.WriteLine("Введите количество ботов");
        string aiplayers = Console.ReadLine();
        if(int.TryParse(players, out var playerCount)&&int.TryParse(aiplayers, out var AIplayerCount)){
            if(playerCount+AIplayerCount==2){
                game.Game(playerCount,AIplayerCount);
            }
            else{
                Console.WriteLine("Сумаррное количество игроков не равно 2.");
            }
        }
        else{
            Console.WriteLine("Некорректный ввод");
        }

        Console.ReadLine();
        
    }
        
}