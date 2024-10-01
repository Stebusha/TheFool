namespace TheFool
{
    public class ScoreTable{
        private List<string> winners = new List<string>();
        private List<int> scores = new List<int>();

        private string path = "C:/Users/МиненковаНА/Projects/TheFool/Scores/scores.txt";

        public void Show(){

            if(!File.Exists(path)){
                Console.WriteLine("Рекордов нет.");
                return;
            }
            Console.WriteLine("Таблица рекордов: ");
            foreach(var line in File.ReadLines(path)){
                string[] parts = line.Split('-');
                Console.WriteLine(parts[0].Trim()+" - "+parts[1].Trim());
            }
            // асинхронное чтение
            //using (StreamReader reader = new StreamReader(path))
            //{
            //    string? line;
            //    while ((line = await reader.ReadLineAsync()) != null)
            //       {
            //        Console.WriteLine(line);
            //    }
            //}
        }

        public void WriteToFile(string name, int score){
            List<string> lines = new List<string>();
            if(File.Exists(path)){
                lines.AddRange(File.ReadLines(path));
            }
            bool updated = false;
            for (int i=0;i<lines.Count;i++){
                string[]parts = lines[i].Split('-');
                if (parts[0].Trim()==winners[i]&&parts[0]==name){
                    lines[i] = winners[i]+ " - "+ scores[i].ToString();
                    updated = true;
                    break;
                }
            }
            if(!updated){
                lines.Add(name + " - "+score.ToString());
            }
            File.WriteAllLines(path,lines);
                        // полная перезапись файла 
            //using (StreamWriter writer = new StreamWriter(path, false))
            //{
            //    await writer.WriteLineAsync(text);
            //}
            // добавление в файл
            //using (StreamWriter writer = new StreamWriter(path, true))
            //{
            //    await writer.WriteLineAsync("Addition");
            //   await writer.WriteAsync("4,5");
            //}   
        }
    }
}