using System;
using System.IO;
using System.Collections.Generic;

namespace TheFool
{
    public class ScoreTable{
        
        private Dictionary<string,int> scores = new Dictionary<string, int>();
        private string path = "C:/Users/МиненковаНА/Projects/TheFool/Scores/scores.txt";
        
        //load score table from files
        private void LoadScoresFromFile(){
            if(File.Exists(path)){
                using(StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while((line = sr.ReadLine())!=null){
                        string[] parts = line.Split(',');
                        scores.Add(parts[0],int.Parse(parts[1]));
                    }
                    scores = scores.OrderByDescending(pair=>pair.Value).ToDictionary();
                }
            }
        }
        public ScoreTable(){
            LoadScoresFromFile();
        }
        
        //save scores to file
        private void SaveScoresToFile(){
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach(var pair in scores)
                {
                    sw.WriteLine("{0},{1}",pair.Key,pair.Value);
                }
            }
        }

        //displwy score table in the console
        public void DisplayScores(){
            Console.WriteLine("\nТаблица рекордов:");
            foreach(var pair in scores){
                Console.WriteLine("{0}: \t{1}", pair.Key,pair.Value);
            }
        }
        
        //check exist name in score table
        public bool IsNameExist(string name){
            if(scores.ContainsKey(name)){
                return true;
            }
            else{
                return false;
            }
        }
        
        //add winner to score table, if name exist - update score of existing winner
        public void AddScore(string name, int score){
            if(IsNameExist(name)){
                int value;
                if(scores.TryGetValue(name, out value)){
                    value++;
                    scores[name]=value;
                }
            }
            else{
                scores.Add(name,score);
            }
            SaveScoresToFile();
        }
    }
}