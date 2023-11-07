using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Graphql.Mutation
{
    public partial class Mutation
    {
        public Task<SubjectModel> CreateSubject(string SubjectName, [Service] ISubjectRepository subjectRepository)
        {
            return subjectRepository.AddSubjectAsync(SubjectName);
        }

        public Task<SubjectModel> UpdateSubject(SubjectModel request, [Service] ISubjectRepository subjectRepository)
        {
            return subjectRepository.UpdateSubjectAsync(request);
        }

        public Task<string> DeleteSubject(Guid id, [Service] ISubjectRepository subjectRepository)
        {
            return subjectRepository.DeleteSubjectAsync(id);
        }
    }
}
