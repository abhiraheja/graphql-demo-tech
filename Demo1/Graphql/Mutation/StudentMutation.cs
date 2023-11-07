using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Graphql.Mutation
{
    public partial class Mutation
    {

        public Task<StudentModel> CreateStudent(StudentCreateRequestModel request, [Service] IStudentRepository studentRepository)
        {
            return studentRepository.AddStudentAsync(request);
        }

        public Task<StudentModel> UpdateStudent(StudentModel request, [Service] IStudentRepository studentRepository)
        {
            return studentRepository.UpdateStudentAsync(request);
        }

        public Task<string> DeleteStudent(Guid id, [Service] IStudentRepository studentRepository)
        {
            return studentRepository.DeleteStudentAsync(id);
        }
    }
}
