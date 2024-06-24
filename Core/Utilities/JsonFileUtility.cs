using System.Reflection;
using System.Text.Json;
using Practice.Core.Extensions;

namespace Practice.Core.Utilities;

public class JsonFileUtility
{
    public static string ReadJsonFile(string path)
    {
        var filePath = StringExtensions.GetAbsolutePath(path);
        return File.ReadAllText(filePath);
    }
    public static Dictionary<string, T> ReadAndParse<T>(string filePath)
    {
        var jsonData = File.ReadAllText(filePath);
        var data = JsonSerializer.Deserialize<Dictionary<string, T>>(jsonData);
        return data ?? new Dictionary<string, T>();
    }
}