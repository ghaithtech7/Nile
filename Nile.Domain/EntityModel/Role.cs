using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Nile.Domain.Enums.Enums;

namespace Nile.Domain.EntityModel
{
    [Index(nameof(RoleName), IsUnique = true)]
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public EnumRoles RoleName { get; set; }
        public string RoleDescription { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
