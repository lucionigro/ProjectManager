using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models
{
    public class User
    {
        [Column("ID")]
        public int UserId { get; set; }
        [Column("USERNAME")]
        [MaxLength(50)]
        public string Username { get; set; }
        [Column("FIRSTNAME")]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Column("LASTNAME")]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Column("EMAIL")]
        [MaxLength(50)]
        public string Email { get; set; }
        [Column("PASSWORD")]
        [MaxLength(30)]
        public string Password { get; set; }
        [Column("USER_CREATED")]
        public DateTime UserCreated { get; set; }
        public List<Project>? OwnedProjects { get; set; }
        public List<Issue>? ReportedIssues { get; set; }
    }
}
