using System;
using System.Collections;
using System.Collections.Generic;

namespace TheFool
{
    public class GameController[
        private int playerCount = 1;
        private int AIPlayerCount = 1;

        private List<AIPlayer, Player> players = new List<AIPlayer,Player>(2);
        private ScoreTable scoreTable = new ScoreTable();

        private Deck deck = new Deck();
        private bool finished = false;

        public bool Finished { get; private set; }
        public int PlayerCount { get; set; }
        public int AIPlayerCount { get; set; }

        public void Game(int playerCount,int AIPlayerCount){

        }

        public void Win(){}

    ]
}