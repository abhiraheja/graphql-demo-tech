using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Data.Entities
{
    
    [Table("CourseSubjectTbl")]
    public class CourseSubjectEntity
{
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public Guid SubjectId { get; set; }
        public virtual CourseEntity Course { get; set; }
        public virtual SubjectEntity Subject { get; set; }
    }
}
