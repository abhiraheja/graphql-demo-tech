using System.ComponentModel.DataAnnotations.Schema;

namespace Demo1.Data.Entities
{
    [Table("CourseTbl")]
    public class CourseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<CourseSubjectEntity> CourseSubjects { get; set; }
        public virtual ICollection<StudentCourseEntity> StudentCourseEntities { get; set; }
    }
}