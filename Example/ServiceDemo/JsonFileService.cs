
namespace Example.ServiceDemo
{
    using System;
    using StarWarsApiCSharp;
    using System.Reflection;
    using System.IO;
    using System.Text;
    public class JsonFileService : IDataService
    {
        public string GetDataResult(string url)
        {
            // Id - 
            // many -

            if (this.IsUrlContinsId(url))
            {
                return this.GetSingle(url);
            }

            return this.GetMany(url);
        }

        private string GetMany(string filePath)
        {
            int slashIndex = filePath.IndexOf("/");
            filePath = filePath.Substring(0, slashIndex);
            filePath += "data.json";

            string result = string.Empty;
            using (StreamReader reader = new StreamReader(filePath))
            {
                result = reader.ReadToEnd();
            }

            return result;
        }

        private string GetSingle(string filePath)
        {
            int slashIndex = filePath.IndexOf("/");
            string id = filePath.Substring(slashIndex + 1);

            filePath = filePath.Substring(0, slashIndex);
            filePath += "data.json";

            StringBuilder result = new StringBuilder(); 
            using (StreamReader reader = new StreamReader(filePath))
            {
                var isInResults = false;
                var countOfBracets = 0;
                var isFound = false;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (isInResults && countOfBracets == 0
                        )
                    {
                        if (isFound)
                        {
                            return result.ToString();
                        }

                        result.Clear();
                    }

                    if (isInResults && line.Contains(" },"))
                    {
                        if (isFound)
                        {
                            result.Append(line.Replace(",", string.Empty));
                        }
                        else
                        {
                            result.AppendLine(line);
                        }

                        countOfBracets--;
                    }

                    if (isInResults && line.Contains(" {"))
                    {
                        countOfBracets++;
                    }

                    if (isInResults && countOfBracets > 0)
                    {
                        result.AppendLine(line);
                        if (line.Contains(id) && line.Contains("\"url\""))
                        {
                            isFound = true;
                        }
                    }

                    if (line.Contains(" \"results\":"))
                    {
                        isInResults = true;
                    }
                }
            }

            return null;
        }

        private bool IsUrlContinsId(string urlToCheck)
        {
            return !urlToCheck.Contains("?");
        }
    }
}
