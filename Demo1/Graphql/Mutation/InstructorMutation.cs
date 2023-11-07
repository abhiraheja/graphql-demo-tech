using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Graphql.Mutation
{
    public partial class Mutation
    {
        public Task<InstructorModel> CreateInstructor(InstructorCreateRequestModel request, [Service] IInstructorRepository instructorRepository)
        {
            return instructorRepository.AddInstructorAsync(request);
        }

        public Task<InstructorModel> UpdateInstructor(InstructorModel request, [Service] IInstructorRepository instructorRepository)
        {
            return instructorRepository.UpdateInstructorAsync(request);
        }

        public Task<string> DeleteInstructor(Guid id, [Service] IInstructorRepository instructorRepository)
        {
            return instructorRepository.DeleteInstructorAsync(id);
        }
    }
}
