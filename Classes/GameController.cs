using System;
using System.Collections;
using System.Collections.Generic;

namespace TheFool
{
    public class GameController{
        private List<IPlayer> players = new List<IPlayer>();
        private ScoreTable scoreTable = new ScoreTable();
        private Table gameTable = new Table();
        private const int MAX_CARDS_TO_ATTACK = 6;
        private Deck deck = new Deck();
        private bool Finished { get;  set; }
        private bool TurnFinished { get; set; }
        private bool FirtsTurn { get; set; }

        public int PlayerCount{get;set;}
        public int BotPlayerCount{get;set;}
        
        //turn logic
        private void Turn(int turn){
            TurnFinished = false;
            players[turn%players.Count].Taken = false;
            players[(turn+1)%players.Count].Taken = false;
            Card attackingCard = new Card();
            // players[(turn+1)%players.Count].SuccesfulDefended = false;
            while(!TurnFinished){
                if(FirtsTurn){
                    //Console.Clear();
                    Console.WriteLine("Начало партии");
                    Console.WriteLine($"Козырная масть - {Deck.trumpSuit}");
                    for(int i=0;i<MAX_CARDS_TO_ATTACK-1;i++){
                        if(players[(turn+1)%players.Count].Taken|players[turn%players.Count].Taken){
                            TurnFinished=true;
                            FirtsTurn=false;
                            //Console.WriteLine(players[(turn+1)%players.Count].Taken.ToString(),players[turn%players.Count].Taken.ToString());
                            break;       
                        }
                        attackingCard = players[turn%players.Count].GetCardsForAttack(gameTable).ElementAt(0);
                        players[turn%players.Count].Attack(gameTable);
                        if(players[turn%players.Count].GetCardsForAttack(gameTable).Count!=0){
                            
                            //Console.WriteLine(attackingCard.ToString());
                            players[(turn+1)%players.Count].Defend(attackingCard,gameTable);
                        }
                        else{
                            players[(turn+1)%players.Count].Defend(attackingCard,gameTable);
                            TurnFinished = true;
                            FirtsTurn=false;
                            break;
                        }
                    }
                    if(!TurnFinished){                      
                        TurnFinished = true;
                    }
                }
                else{
                    Console.WriteLine($"Начало хода: ");
                    for(int i=0;i<MAX_CARDS_TO_ATTACK;i++){
                        if(players[(turn+1)%players.Count].Taken|players[turn%players.Count].Taken){
                            TurnFinished=true;
                            //Console.WriteLine(players[(turn+1)%players.Count].Taken.ToString(),players[turn%players.Count].Taken.ToString());
                            break;       
                        }
                       
                        if(players[(turn+1)%players.Count].GetCards().Count!=0){
                            attackingCard = players[turn%players.Count].GetCardsForAttack(gameTable).ElementAt(0);
                            players[turn%players.Count].Attack(gameTable);
                        }
                        else{                      
                            TurnFinished = true;
                            break;
                        }
                        if(players[turn%players.Count].GetCardsForAttack(gameTable).Count!=0){
                            //Console.WriteLine(attackingCard.ToString());
                            players[(turn+1)%players.Count].Defend(attackingCard,gameTable);
                        }
                        else if(gameTable.Length()!=12&&players[(turn+1)%players.Count].GetCards().Count!=0){
                            players[(turn+1)%players.Count].Defend(attackingCard,gameTable);
                            TurnFinished = true;
                            break;
                        }
                    }   
                }   
            }
            gameTable.ClearTable();
            Console.WriteLine("Конец хода");
            Console.ReadLine();
            Console.Clear();
        }
        
        //launch game, set start info, set trump, player's turns, check the winning condition
        public void Game(int playerCount,int AIPlayerCount, bool repeat){
            //Console.Clear();
            deck = new Deck();
            FirtsTurn = true;
            Finished = false;
            deck.Shuffle();
            deck.Trump();
            
            if(!repeat){
                players = new List<IPlayer>();
            if(playerCount+AIPlayerCount==2&&playerCount==0){
                AIPlayer aIPlayer = new AIPlayer();
                aIPlayer.RefillHand(deck);
                players.Add(aIPlayer);
                players[0].Name = "Бот 1";
                AIPlayer aIPlayer1 = new AIPlayer();
                aIPlayer1.RefillHand(deck);
                players.Add(aIPlayer1);    
                players[1].Name = "Бот 2";           
            }
            else if(playerCount+AIPlayerCount==2&&playerCount==1){
                Player player = new Player();
                if(scoreTable.IsNameExist(player.Name)){
                    Console.WriteLine("Имя {0} уже существует, выбрать другое? (да/нет)",player.Name);
                    if(Console.ReadLine().ToLower()=="да"){
                        player.Name = Console.ReadLine();
                    }
                }
                player.RefillHand(deck);
                players.Add(player);
                AIPlayer aIPlayer1 = new AIPlayer();
                aIPlayer1.RefillHand(deck);
                players.Add(aIPlayer1);    
                players[1].Name = "Бот 1";
            }
            else{
                for(int i = 0;i<playerCount; i++){
                    Player player = new Player();
                    if(scoreTable.IsNameExist(player.Name)){
                        Console.WriteLine("Имя {0} уже существует, выбрать другое? (да/нет)",player.Name);
                        if(Console.ReadLine().ToLower()=="да"){
                            player.Name = Console.ReadLine();
                        }
                    }
                    player.RefillHand(deck);
                    players.Add(player);
                }
                for(int i = 0;i<AIPlayerCount; i++){
                    //Random random = new Random();
                    // if(random.Next(0,2)==0){
                    AIPlayer aIPlayer = new AIPlayer();
                    aIPlayer.RefillHand(deck);
                    players.Add(aIPlayer);
                    players[i].Name = $"Бот {i+1}";
                    // }
                    // else{
                    //     AINoobPlayer aINoob = new AINoobPlayer();
                    //     aINoob.RefillHand(deck);
                    //     players.Add(aINoob);
                    // }
                }   
            }
            }
            List<Card> firstTrumps = new List<Card>();
            foreach(var p in players){
               firstTrumps.Add(GetFirstTrump(p.GetCards()));
            }
            //players[0].IsFool=true;
            int first = firstTurnNumbers(firstTrumps);
            Console.WriteLine($"Первым ходит игрок {players[first].Name}");
            players[first].TurnNumber=1;
            
            if(players.Count==2){
                foreach(var p in players){
                    if(p.TurnNumber==0){
                        p.TurnNumber=2;
                        break;
                    }
                }
            }
            else{
                int counter = 0;
                for(int i=first+1; i<players.Count;i++){
                    counter++;
                    if(players[i].TurnNumber==0){
                        players[i].TurnNumber = players[first].TurnNumber+counter;
                    }
                }
                for (int i=0; i<first;i++){
                    counter++;
                    if(players[i].TurnNumber==0){
                        players[i].TurnNumber = players[first].TurnNumber+counter;
                    }
                }
            }
            // foreach(var p in players){
            //     Console.WriteLine(p.TurnNumber.ToString());
            // }
            players = players.OrderBy(p=>p.TurnNumber).ToList();
            foreach(var p in players){
                p.IsFool=false;
            }
            int turns = 0;
            while(!Finished){
                Console.WriteLine($"Козырная масть - {Deck.trumpSuit}");
                Console.WriteLine($"Карт в колоде: {deck.CardsAmount}");
                foreach(var p in players){
                    Console.WriteLine($"Количество карт игрока {p.Name} : {p.GetCards().Count}");
                }
                // Console.WriteLine($"Количество карт игрока {players[0].Name} : {players[0].GetCards().Count}");
                // Console.WriteLine($"Количество карт игрока {players[1].Name} : {players[1].GetCards().Count}");
                Turn(turns);
                if(deck.CardsAmount!=0){
                    players[turns%players.Count].RefillHand(deck);
                    players[(turns+1)%players.Count].RefillHand(deck);
                    Console.WriteLine("Игроки взяли карты");
                }
                if(!players[(turns+1)%players.Count].Taken&&!players[turns%players.Count].Taken){
                    turns++;   
                }
                else{
                    turns+=2;
                    players[(turns+1)%players.Count].Taken=false;
                    players[turns%players.Count].Taken=false;
                }
                Win();
            }   
        }
        
        //get first trump card in player's hand
        private Card GetFirstTrump(List<Card> cards){
            Card firstTrumpCard = new Card();
            foreach (var c in cards){
                if(c.Suit==Deck.trumpSuit){
                    firstTrumpCard = c;
                    break;
                }
            }
            return firstTrumpCard;
        }
        
        //set first turn number of players use checking min trumps in players' hand or choosing next player after fool
        private int firstTurnNumbers(List<Card> firstTrumpCards){
            int number = 0;
            foreach(var player in players){
                number++;
                if(player.IsFool==true){
                    return number%players.Count;
                }
                else if(number==players.Count){
                    number=0;
                    for(int i=1;i<firstTrumpCards.Count;i++){
                        if(firstTrumpCards[i].Rank<firstTrumpCards[i-1].Rank){
                            number++;
                        }
                    }   
                }
            }
            return number;
        }
        
        //check the winner, update and display score table
        private void Win(){
            if(deck.CardsAmount==0){
                int lefts = 0;
                foreach(var player in players){
                    if(player.GetCards().Count==0){
                        lefts++;
                    }
                    else{
                        break;
                    }
                }
                if(lefts==players.Count){
                    Finished = true;
                    Console.WriteLine($"Колода закончилась. Конец партии. Ничья.");
                    scoreTable.DisplayScores();
                }
                else if(players.Count==2){
                    
                    if (players[1].GetCards().Count==0){
                    Finished = true;
                    Console.WriteLine($"Колода закончилась. Конец партии. Победил игрок {players[1].Name}."); 
                    players[0].IsFool = true;
                    int score = 1;
                    scoreTable.AddScore(players[1].Name,score);
                    scoreTable.DisplayScores();
                    }
                    else if(players[0].GetCards().Count==0){
                        Console.WriteLine($"Колода закончилась. Конец партии. Победил игрок {players[0].Name}.");
                        Finished = true;
                        players[1].IsFool = true;
                        int score = 1;
                        scoreTable.AddScore(players[0].Name,score);
                        scoreTable.DisplayScores();
                    }
                }
                else{
                    if(players.Count > 1){
                        for(int p=0; p<players.Count;p++){
                            if (players[p].GetCards().Count==0){
                                Console.WriteLine($"Карты закончились. Игрок {players[p].Name} вышел.");
                                players[p].IsFool = false;
                                players.Remove(players[p]);
                            }
                        }
                    }
                    else{
                        Console.WriteLine($"Колода закончилась. Конец партии. Проиграл игрок {players[0].Name}.");
                        Finished = true;
                        int score = 1;
                        players[0].IsFool = true;
                        scoreTable.AddScore(players[0].Name,score);
                        scoreTable.DisplayScores();
                    }
                    
                    
                }   
            }
        }
    }      
}