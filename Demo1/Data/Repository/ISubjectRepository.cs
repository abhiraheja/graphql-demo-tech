using Demo1.Models;

namespace Demo1.Data.Repository
{
    public interface ISubjectRepository
    {
        Task<SubjectModel> AddSubjectAsync(string name);
        Task<string> DeleteSubjectAsync(Guid id);
        Task<SubjectModel> GetSubjectByIdAsync(Guid id);
        Task<List<SubjectModel>> GetSubjectsAsync();
        Task<List<SubjectDetailModel>> GetSubjectsWithInstructorAsync();
        Task<SubjectModel> UpdateSubjectAsync(SubjectModel model);
    }
}