namespace AzureMon.Api.Models;

public class Pokemon
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";
    public string Species { get; set; } = "";

    public int Level { get; set; }
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }

    public string Move1 { get; set; } = "";
    public string Move2 { get; set; } = "";
}