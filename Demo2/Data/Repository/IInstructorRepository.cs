using Demo2.Models;

namespace Demo2.Data.Repository
{
    public interface IInstructorRepository
    {
        Task<InstructorModel> AddInstructorAsync(InstructorCreateRequestModel request);
        Task<string> DeleteInstructorAsync(Guid id);
        Task<List<InstructorModel>> GetInstructorAsync();
        Task<InstructorModel> GetInstructorByIdAsync(Guid id);
        Task<InstructorModel> GetInstructorBySubjectIdAsync(Guid subjectId);
        Task<InstructorModel> UpdateInstructorAsync(InstructorModel model);
    }
}