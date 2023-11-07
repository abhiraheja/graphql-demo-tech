using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Data.Entities
{
    [Table("InstructorSubjectTbl")]
    public class InstructorSubjectEntity
    {
        public Guid Id { get; set; }
        public Guid InstratuctorId { get; set; }
        public Guid SubjectId { get; set; }
        public virtual InstructorEntity InstructorEntity { get; set; }
        public virtual SubjectEntity SubjectEntity { get; set; }
    }
}
