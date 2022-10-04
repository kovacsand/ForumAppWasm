using System.Text.Json;
using Domain;

namespace FileData;

public class FileContext
{
    private const string FilePath = "data.json";
    private DataContainer? dataContainer;

    public ICollection<Post> Posts
    {
        get
        {
            LoadData();
            return dataContainer.Posts;
        }
    }

    public ICollection<User> Users
    {
        get
        {
            LoadData();
            return dataContainer.Users;
        }
    }

    public void SaveChanges()
    {
        string serialized = JsonSerializer.Serialize(dataContainer, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(FilePath, serialized);
        dataContainer = null;
    }
    
    private void LoadData()
    {
        if (dataContainer != null)
            return;
        if (!File.Exists(FilePath))
        {
            dataContainer = new()
            {
                Posts = new List<Post>(),
                Users = new List<User>()
            };
            return;
        }

        string content = File.ReadAllText(FilePath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
    }
}