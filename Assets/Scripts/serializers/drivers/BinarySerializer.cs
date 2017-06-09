using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Cariacity.game
{
    public class BinarySerializer
    {
        private const string fileName = "test.bin";

        public static bool HasSave()
        {
            return File.Exists(Path.Combine(Application.persistentDataPath, fileName));
        }

        public static void Save(object data)
        {
            var file_path = Path.Combine(Application.persistentDataPath, fileName);
            var bf = new BinaryFormatter();
            var stream = new FileStream(file_path, FileMode.Create);

            bf.Serialize(stream, data);
            stream.Close();
        }

        public static object Get()
        {
            var file_path = Path.Combine(Application.persistentDataPath, fileName);

            if (File.Exists(file_path))
            {
                var bf = new BinaryFormatter();
                var stream = new FileStream(file_path, FileMode.Open);
                var data = bf.Deserialize(stream);

                stream.Close();
                return data;
            }

            return null;
        }
    }
}