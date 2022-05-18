using System.ComponentModel.DataAnnotations;

namespace mobi_api.DAO
{
    public class UsersEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string? Name { get; set; }
        public DateTime Created { get; set; }
        public string Email { get; set; }
    }
}
