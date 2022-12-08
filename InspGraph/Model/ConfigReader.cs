namespace InspGraph.Model
{
    public class ConfigReader
    {
        public static List<string[]> ReadCommaStrings(string filePath) 
        {
            StreamReader sr;
            string? line;
            List<string[]> result = new List<string[]>();

            if(File.Exists(filePath))
            {
                sr = new StreamReader(filePath);

                while(sr.Peek() != -1)
                {
                    line = sr.ReadLine();
                    if (line is not null)
                    {
                        string[] arr = line.Split(",");
                        result.Add(arr);
                    }
                }
            }
            return result;
        }
    }
}
