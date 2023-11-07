using Demo1.Data.Entities;
using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Graphql.Queries
{
    public partial class Query
    {
        public Task<List<SubjectModel>> GetSubjects([Service] ISubjectRepository subjectRepository)
        {
            return subjectRepository.GetSubjectsAsync();
        }

        public Task<SubjectModel> GetSubjectById(Guid id, [Service] ISubjectRepository subjectRepository)
        {
            return subjectRepository.GetSubjectByIdAsync(id);
        }


        [GraphQLName("subjectWithInstructorProblem")]
        public Task<List<SubjectDetailModel>> GetSubjectWithInstructorProblem([Service] ISubjectRepository subjectRepository)
        {
            return subjectRepository.GetSubjectsWithInstructorAsync();

        }



        // N+1 Problem
        [GraphQLName("subjectWithInstructorN1Problem")]
        public async Task<List<SubjectDetailModel1>> GetSubjectWithInstructorN1Problem([Service] ISubjectRepository subjectRepository)
        {
            var result = await subjectRepository.GetSubjectsAsync();
            return result.Select(x => new SubjectDetailModel1
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        // N+1 Solution
        [GraphQLName("subjectWithInstructorN1Solution")]
        public async Task<List<SubjectDetailModel3>> GetSubjectWithInstructorN1Solution([Service] ISubjectRepository subjectRepository)
        {
            var result = await subjectRepository.GetSubjectsAsync();
            return result.Select(x => new SubjectDetailModel3
            {
                Id = x.Id,
                Name = x.Name,
            }).ToList();
        }


    }
}
