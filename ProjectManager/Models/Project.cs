using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models
{
    public class Project
    {
        [Column("ID")]
        public int ProjectId { get; set; }
        [Column("TITLE")]
        [MaxLength(70)]
        public string Title { get; set; }

        public List<Issue> Issues { get; set; }

        [Column("OWNER_ID")]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        [Column("CREATED")]
        public DateTime Created { get; set; }
        [Column("UPDATED")]
        public DateTime Updated { get; set; }
    }
}
