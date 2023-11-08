using Demo1.Models;

namespace Demo1.Data.Repository
{
    public interface IInstructorRepository
    {
        Task<InstructorModel> AddInstructorAsync(InstructorCreateRequestModel request);
        Task<string> DeleteInstructorAsync(Guid id);
        Task<List<InstructorModel>> GetInstructorAsync();
        Task<InstructorModel> GetInstructorByIdAsync(Guid id);
        Task<InstructorModel> GetInstructorBySubjectIdAsync(Guid subjectId);
        Task<IReadOnlyDictionary<Guid, InstructorModel>> GetInstructorBySubjectKeys(IReadOnlyList<Guid> keys);
        Task<InstructorModel> UpdateInstructorAsync(InstructorModel model);
    }
}