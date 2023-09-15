using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Models
{
    public class Issue
    {
        [Column("ID")]
        public int IssueId { get; set; }
        [Column("SUMMARY")]
        [MaxLength(150)]
        public string Summary { get; set; }
        [Column("DESCRIPTION")]
        [MaxLength(280)]
        public string Description { get; set; }

        [Column("PROJECT_ID")]
        public int ProjectId { get; set; }
        public Project Project { get; set; }

        [Column("REPORTER_ID")]
        public int ReporterId { get; set; }
        [ForeignKey("ReporterId")]
        public User Reporter { get; set; }

        [Column("CREATED")]
        public DateTime Created { get; set; }
        [Column("UPDATED")]
        public DateTime Updated { get; set; }
        [Column("DUE")]
        public DateTime Due { get; set; }
    }
}
