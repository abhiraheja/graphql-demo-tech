using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Data.Entities
{
    [Table("SubjectTbl")]
    public class SubjectEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseSubjectEntity> CourseSubjects { get; set; }
        public virtual InstructorSubjectEntity InstructorSubjectEntity { get; set; }
    }
}
