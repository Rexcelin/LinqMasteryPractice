
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace RestaurantManagementSystem.Utilities
{
    public class JsonFileHandler
    {
        public static void SaveData<T>(string fileName, List<T> data)
        {
            string json = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, json);
        }

        public static List<T> LoadData<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                List<T>? data = JsonSerializer.Deserialize<List<T>>(json);

                if (data != null)
                {
                    return data;
                }
            }

            return new List<T>();
        }

        public static void SaveText<T>(string fileName, List<T> data)
        {
            string text = JsonSerializer.Serialize(data,
                new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(fileName, text);
        }
    }
}
