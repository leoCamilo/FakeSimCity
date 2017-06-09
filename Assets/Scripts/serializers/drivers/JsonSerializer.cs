using System.IO;
using UnityEngine;

namespace Cariacity.game
{
    public class JsonSerializer
    {
        private const string fileName = "test.json";

        public static bool HasSave()
        {
            return File.Exists(Path.Combine(Application.persistentDataPath, fileName));
        }

        public static void Save(object data)
        {
            var file_path = Path.Combine(Application.persistentDataPath, fileName);
            var json = JsonUtility.ToJson(data);

            File.WriteAllText(file_path, json);
        }

        public static object Get<T>()
        {
            var file_path = Path.Combine(Application.persistentDataPath, fileName);

            if (File.Exists(file_path))
            {
                var json = File.ReadAllText(file_path);
                return JsonUtility.FromJson<T>(json);
            }

            return null;
        }
    }
}