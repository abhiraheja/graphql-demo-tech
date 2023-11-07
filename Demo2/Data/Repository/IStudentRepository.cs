using Demo2.Models;

namespace Demo2.Data.Repository
{
    public interface IStudentRepository
    {
        Task<StudentModel> AddStudentAsync(StudentCreateRequestModel request);
        Task<string> DeleteStudentAsync(Guid id);
        Task<StudentModel> GetStudentByIdAsync(Guid id);
        Task<List<StudentModel>> GetStudentsAsync();
        Task<List<StudentDetailModel>> GetStudentsDetails();
        Task<StudentModel> UpdateStudentAsync(StudentModel model);
    }
}