using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library.Operations
{
    public class Reader<TModel>
    {
        protected string FileName { get; set; }

        public Reader(string fileName)
        {
            FileName = fileName;
        }

        protected IEnumerable<TModel> GetAll()
        {
            if (!File.Exists(FileName) || new FileInfo(FileName).Length <= 2)
            {
                return new List<TModel>();
            }

            string jsonString = File.ReadAllText(FileName);
            IEnumerable<TModel> objects = JsonSerializer.Deserialize<IEnumerable<TModel>>(jsonString);
            return objects;
        }
    }
}
