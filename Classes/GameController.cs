using System;
using System.Collections;
using System.Collections.Generic;

namespace TheFool
{
    public class GameController{
        private List<IPlayer> players;
        private ScoreTable scoreTable = new ScoreTable();

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

            //deck.DealCardsToPlayers(players);
            Console.WriteLine(deck.CardsAmount);
            
        }

        public void Win(){
            finished = true;
            scoreTable.WriteToFile();
            scoreTable.Show();
        }


    }
        
}