using System.ComponentModel.DataAnnotations.Schema;

namespace JupiterWebAPI.Models
{
    public class UserInfo
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int RoleId { get; set; }

        public DateOnly? DateRegistration { get; set; }

        public DateOnly? DataChange { get; set; }


        public string RoleName { set; get; }

    }
}

