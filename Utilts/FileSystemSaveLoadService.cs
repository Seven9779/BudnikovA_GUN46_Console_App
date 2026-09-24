namespace SaveLoadSystem;

public class FileSystemSaveLoadService : ISaveLoadService<string>
{
    private readonly string _path;

    public FileSystemSaveLoadService(string path)
    {
        _path = path;
        Directory.CreateDirectory(_path);
    }

    public void SaveData(string data, string identifier)
    {
        string filePath = Path.Combine(_path, $"{identifier}.txt");
        File.WriteAllText(filePath, data);
    }

    public string LoadData(string identifier)
    {
        string filePath = Path.Combine(_path, $"{identifier}.txt");
        if (!File.Exists(filePath))
        {
            return null;
        }
        return File.ReadAllText(filePath);
    }
}