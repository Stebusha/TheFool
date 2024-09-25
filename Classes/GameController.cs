using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Security.Principal;

namespace TheFool
{
    public class GameController{
        private List<IPlayer> players;
        private ScoreTable scoreTable = new ScoreTable();

        private GameRiver gameRiver = new GameRiver();

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
                player.TurnNumber = i+1;
                player.RefillHand(deck);
                players.Add(player);
            }
            for(int i = 0;i<AIPlayerCount; i++){
                Random random = new Random();
                if(random.Next(0,2)==0){
                    AIPlayer aIPlayer = new AIPlayer();
                    aIPlayer.TurnNumber=i+2;
                    aIPlayer.RefillHand(deck);
                    players.Add(aIPlayer);
                }
                else{
                    AINoobPlayer aINoob = new AINoobPlayer();
                    aINoob.TurnNumber = i+3;
                    aINoob.RefillHand(deck);
                    players.Add(aINoob);
                }
                
            }
            
           
                for(int i =0; i<players.Count; i++){
                    if(players[i].TurnNumber==i+1){
                        

                    }
                }


            //deck.DealCardsToPlayers(players);
            Console.WriteLine(deck.CardsAmount);
            
        }

        public void Win(){
            finished = true;
            int score = 1;
            scoreTable.WriteToFile(players[0].Name, score);
            scoreTable.Show();
        }


    }
        
}