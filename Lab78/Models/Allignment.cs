﻿using System.ComponentModel.DataAnnotations;

namespace Lab78.Models;

public class Allignment
{
    [Key]
    public int? Id { get; set; }
    public string? allignment { get; set; }
}