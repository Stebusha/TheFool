using System;
namespace TheFool;

class Program
{
    static void Main(string[] args)
    {
        GameController game = new GameController();  
        bool repeatGame = false;
        Console.WriteLine("Введите количество реальных игроков");
            string players = Console.ReadLine();
            Console.WriteLine("Введите количество ботов");
            string aiplayers = Console.ReadLine();
            if(int.TryParse(players, out var playerCount)&&int.TryParse(aiplayers, out var AIplayerCount)){
                if(playerCount+AIplayerCount>1&&playerCount+AIplayerCount<=2){
                    game.Game(playerCount,AIplayerCount,false);
                    game.PlayerCount=playerCount;
                    game.BotPlayerCount=AIplayerCount;
                    // repeatGame = false;
                }
                else{
                    Console.WriteLine("Сумаррное количество игроков не равно 2.");
                }
            }
            else{
                Console.WriteLine("Некорректный ввод");
            }
        while(!repeatGame){
            Console.ReadLine();
            Console.WriteLine("Сыграть еще раз? (да/нет)");
            string repeat = Console.ReadLine();
            if(repeat=="да"&&repeat!="нет"){
                Console.Clear();
                game.Game(game.PlayerCount,game.BotPlayerCount,true);
                repeatGame = false;
            }
            else{
                Console.WriteLine("\nВыход");
                repeatGame = true;
                Console.ReadLine();
            }
        }
    }
        
}