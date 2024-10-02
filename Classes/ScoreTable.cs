namespace TheFool
{
    public class ScoreTable{
        
        private Dictionary<string,int> scores = new Dictionary<string, int>();
        private string path = "C:/Users/МиненковаНА/Projects/TheFool/Scores/scores.txt";
        private void LoadScoreFromFile(){
            if(File.Exists(path)){
                using(StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while((line = sr.ReadLine())!=null){
                        string[] parts = line.Split(',');
                        scores.Add(parts[0],int.Parse(parts[1]));
                    }
                }
            }
        }
        public ScoreTable(){
            LoadScoreFromFile();
        }
        private void SaveScoresToFile(){
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach(var pair in scores)
                {
                    sw.WriteLine("{0},{1}",pair.Key,pair.Value);
                }
            }
        }

        public void DisplayScores(){
            Console.WriteLine("\nТаблица рекордов:");
            foreach(var pair in scores){
                Console.WriteLine("{0}: {1}", pair.Key,pair.Value);
            }
        }
        public bool IsNameExist(string name){
            if(scores.ContainsKey(name)){
                return true;
            }
            else{
                return false;
            }
        }
        public void AddScore(string name, int score){
            if(IsNameExist(name)){
                int value;
                if(scores.TryGetValue(name, out value)){
                    Console.WriteLine(value);
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