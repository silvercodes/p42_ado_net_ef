using System;
using System.Collections.Generic;

namespace _01_db_first.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public override string ToString()
    {
        return $"id: {Id}, title: {Title}";
    }
}
