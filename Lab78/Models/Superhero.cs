﻿using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Superhero
{
    [Key]
    public int? Id { get; set; }
    public string? superhero_name { get; set; }
    public string? full_name { get; set; }
    public int? gender_id { get; set; }
    public int? eye_colour_id { get; set; }
    public int? hair_colour_id { get; set; }
    public int? skin_colour_id { get; set; }
    public int? race_id { get; set; }
    public int? publisher_id { get; set; }
    public int? alignment_id { get; set; }
    public int? height_cm { get; set; }
    public int? weight_kg { get; set; }
}