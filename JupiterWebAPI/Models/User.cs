using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace JupiterWebAPI.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int RoleId { get; set; }

    public DateOnly? DateRegistration { get; set; }

    public DateOnly? DataChange { get; set; }

    public virtual Role Role { get; set; } = null!;

}
