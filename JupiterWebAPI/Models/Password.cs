using System;
using System.Collections.Generic;

namespace JupiterWebAPI.Models;

public partial class Password
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string HashPassword { get; set; } = null!;

    public bool Status { get; set; }

    public DateOnly DateAdd { get; set; }
}
