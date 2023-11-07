using Demo1.Models;

namespace Demo1.Data.Repository
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