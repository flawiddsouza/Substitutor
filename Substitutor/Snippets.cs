using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Substitutor
{
    public static class Snippets
    {
        public static BindingList<Snippet> List = new BindingList<Snippet>();

        public static void Deserialize()
        {
            if (File.Exists("snippets.dat"))
            {
                IFormatter formatter = new BinaryFormatter();
                using (FileStream stream = File.OpenRead("snippets.dat"))
                {
                    List = (BindingList<Snippet>)formatter.Deserialize(stream);
                }
            }
        }

        public static void Serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            using (FileStream stream = File.Create("snippets.dat"))
            {
                formatter.Serialize(stream, List);
            }
        }
    }
}
