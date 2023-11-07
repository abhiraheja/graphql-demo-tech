using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Data.Entities
{
    [Table("StudentTbl")]
    public class StudentEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int RollNumber { get; set; }

        public virtual ICollection<StudentCourseEntity> StudentCourseEntities { get; set; }
    }
}
