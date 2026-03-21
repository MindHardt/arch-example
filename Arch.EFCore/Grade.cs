namespace Arch.EFCore;

public class Grade
{
    public int Id { get; set; }
    
    public required Mark Mark { get; set; }
    public required string Course { get; set; }
    
    public required int StudentId { get; set; }
    public Student? Student { get; set; }
}

public enum Mark : sbyte
{
    A = 5,
    B = 4,
    C = 3,
    D = 2,
    E = 1,
    F = 0
}