using System.ComponentModel.DataAnnotations.Schema;

namespace Demo2.Data.Entities
{
    [Table("InstructorTbl")]
    public class InstructorEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public double Salary { get; set; }
        public virtual InstructorSubjectEntity InstructorSubjectEntity { get; set; }

    }
}
