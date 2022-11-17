using System.Text.Json.Serialization;

namespace Domain;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int SecurityLevel { get; set; }
    
    [JsonIgnore]
    public ICollection<Post> Posts { get; set; }
}