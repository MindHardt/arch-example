namespace Arch.WebApi.Data;

public class Note
{
    public int Id { get; set; }
    public required string Text { get; set; }
    public required DateTimeOffset CreatedAt { get; set; }
    public required DateTimeOffset UpdatedAt { get; set; }
}