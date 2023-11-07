using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Data.Entities
{
    [Table("StudentCourseTbl")]
    public class StudentCourseEntity
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Guid CourseId { get; set; }
        public virtual StudentEntity StudentEntity { get; set; }
        public virtual CourseEntity CourseEntity { get; set; }
    }
}
