using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Library.Operations
{
    public class Writer<TModel>
    {
        protected string FileName { get; set; }

        public Writer(string fileName)
        {
            FileName = fileName;
        }

        protected void Write(List<TModel> books)
        {
            string jsonString = JsonSerializer.Serialize(books);
            File.WriteAllText(FileName, jsonString);
        }
    }
}
