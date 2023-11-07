using Demo1.Data.Repository;

namespace Demo1.Models
{
    public class SubjectDetailModel1
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public async Task<InstructorModel> Instructor([Service] IInstructorRepository repository)
        {
            var a= await repository.GetInstructorBySubjectIdAsync(Id);
            return a;
        }
    }
}
