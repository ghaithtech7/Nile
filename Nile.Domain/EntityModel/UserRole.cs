
using System.ComponentModel.DataAnnotations;

namespace Nile.Domain.EntityModel
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }
        public int? RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
