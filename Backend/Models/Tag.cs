using System.Text.Json.Serialization;
using Backend.Models;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    [JsonIgnore]
    public List<Goal> Goals { get; set; } = null!;
}