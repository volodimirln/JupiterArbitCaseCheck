using System;
using System.Collections.Generic;

namespace JupiterWebAPI.Models;

public partial class Role
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<User> Users { get; } = new List<User>();
}
