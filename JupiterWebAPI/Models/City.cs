using System;
using System.Collections.Generic;

namespace JupiterWebAPI.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Court { get; set; } = null!;

    public string? Description { get; set; }
}
