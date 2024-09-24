namespace TheFool
{
    public class ScoreTable{
        private List<string> winners = new List<string>();
        private List<int> scores = new List<int>();

        //private string path = "C:/Users/МиненковаНА/Projects/TheFool/Scores/scores.txt";

        public void Show(){
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

        public void WriteToFile(){
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