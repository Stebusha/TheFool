using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;

namespace TheFool
{
    public class GameController{
        private List<Player> players;
        private ScoreTable scoreTable = new ScoreTable();

        private Deck deck;
        private bool finished = false;

        public bool Finished { get; private set; }
        public int PlayerCount { get; set; }
        public int BotPlayerCount { get; set; }

        public void Game(int playerCount,int AIPlayerCount){
            deck = new Deck();
            Console.WriteLine(deck.CardsAmount);
            //Console.WriteLine(deck.GetTrumpSuit());
            deck.Shuffle();
            deck.Trump();
            //Console.WriteLine(deck.GetTrumpSuit());
            players = new List<Player>();
            for(int i = 0;i<playerCount+AIPlayerCount; i++){
                Player player = new Player();
                players.Add(player);
            }
            deck.DealCardsToPlayers(players);
            //Console.WriteLine(deck.CardsAmount);
            
        }

        public void Win(){}


    }
        
}