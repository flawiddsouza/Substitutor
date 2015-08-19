using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;

namespace Substitutor
{
    public static class Snippets
    {
        public static BindingList<Snippet> List = new BindingList<Snippet>();
        private static string storageFileName = "snippets.json";

        public static void Deserialize()
        {
            if (File.Exists(storageFileName))
            {
                string json = File.ReadAllText(storageFileName);
                List = JsonConvert.DeserializeObject<BindingList<Snippet>>(json);
            }
        }

        public static void Serialize()
        {
            string json = JsonConvert.SerializeObject(List, Formatting.Indented);
            File.WriteAllText(storageFileName, json);
        }
    }
}