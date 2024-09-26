using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace TheFool
{
    public class GameController{
        private List<IPlayer> players;
        private ScoreTable scoreTable = new ScoreTable();

        private Table gameTable = new Table();

        private Deck deck;
        private bool finished = false;

        public bool Finished { get; private set; }
        public int PlayerCount { get; set; }
        public int BotPlayerCount { get; set; }

        public void Game(int playerCount,int AIPlayerCount){
            deck = new Deck();
            Console.WriteLine(deck.CardsAmount);
            Console.WriteLine(deck.GetTrumpSuit());
            deck.Shuffle();
            deck.Trump();
            Console.WriteLine(deck.GetTrumpSuit());
            players = new List<IPlayer>();
            for(int i = 0;i<playerCount; i++){
                Player player = new Player();
                player.RefillHand(deck);
                players.Add(player);
            }
            for(int i = 0;i<AIPlayerCount; i++){
                Random random = new Random();
                if(random.Next(0,2)==0){
                    AIPlayer aIPlayer = new AIPlayer();
                    aIPlayer.RefillHand(deck);
                    players.Add(aIPlayer);
                }
                else{
                    AINoobPlayer aINoob = new AINoobPlayer();
                    aINoob.RefillHand(deck);
                    players.Add(aINoob);
                }
                
            }
            List<Card> firstTrumps = new List<Card>();
            foreach(var p in players){
               firstTrumps.Add(GetFirstTrump(p.GetCards()));
            }
            int first = firstTurnNumbers(firstTrumps);
            Console.WriteLine(first.ToString());
            players[first].TurnNumber=1;
            // foreach(var p in players){
            //     Console.WriteLine(p.TurnNumber.ToString());
            // }
            if(players.Count==2){
                foreach(var p in players){
                    if(p.TurnNumber==0){
                        p.TurnNumber=2;
                        break;
                    }
                }
            }
            if(players.Count==3){
                switch(first){
                    case 0:
                        for(int i=1;i<players.Count;i++){
                            players[i].TurnNumber = i+1;
                        }
                        break;
                    case 1:
                        players[0].TurnNumber = players.Count;
                        players[2].TurnNumber = first+1;
                        break;
                    case 2:
                        players[0].TurnNumber = players.Count-1;
                        players[1].TurnNumber = players.Count;
                        break;
                }

            }else{
                switch(first){
                    case 0:
                        for(int i=1;i<players.Count;i++){
                            players[i].TurnNumber = i+1;
                        }
                        break;
                    case 1:
                        players[0].TurnNumber = players.Count;
                        for(int i=2;i<players.Count;i++){
                            players[i].TurnNumber = i;
                        }
                        break;
                    case 2:
                        players[0].TurnNumber = players.Count-1;
                        players[1].TurnNumber = players.Count;
                        players[3].TurnNumber = first;
                        break;
                    case 3:
                        for(int i=0;i<players.Count-1;i++){
                            players[i].TurnNumber = i+2;
                        }
                        break;
                }
          
            }
            
            // foreach(var p in players){
            //     Console.WriteLine(p.TurnNumber.ToString());
            // }
            

            //deck.DealCardsToPlayers(players);
            Console.WriteLine(deck.CardsAmount);
            
        }

        public Card GetFirstTrump(List<Card> cards){
            Card firstTrumpCard = new Card();
            foreach (var c in cards){
                if(c.Suit==Deck.trumpSuit){
                    firstTrumpCard = c;
                    break;
                }
            }
            return firstTrumpCard;
        }

        public int firstTurnNumbers(List<Card> firstTrumpCards){
            int number = 0;
            for(int i=1;i<firstTrumpCards.Count;i++){
                if(firstTrumpCards[i].Rank<firstTrumpCards[i-1].Rank){
                    number++;
                }
            }
            return number;
        }
        public void Win(){
            finished = true;
            int score = 1;
            scoreTable.WriteToFile(players[0].Name, score);
            scoreTable.Show();
        }


    }
        
}