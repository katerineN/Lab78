using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Hero_power
{
    public int? hero_id { get; set; }
    public int? power_id { get; set; }
    public Superhero Superhero { get; set; } = null!;
}