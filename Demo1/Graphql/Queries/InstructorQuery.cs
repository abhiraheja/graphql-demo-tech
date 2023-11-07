using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Graphql.Queries
{
    public partial class Query
    {
        public Task<List<InstructorModel>> GetInstructor([Service] IInstructorRepository instructorRepository)
        {
            return instructorRepository.GetInstructorAsync();
        }

        public Task<InstructorModel> GetInstructorById(Guid id, [Service] IInstructorRepository instructorRepository)
        {
            return instructorRepository.GetInstructorByIdAsync(id);
        }
    }
}
