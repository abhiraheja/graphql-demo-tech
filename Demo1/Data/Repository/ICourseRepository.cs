using Demo1.Models;

namespace Demo1.Data.Repository
{
    public interface ICourseRepository
    {
        Task<CourseModel> AddCoursesAsync(string name);
        Task<string> DeleteCoursesAsync(Guid id);
        Task<List<CourseModel>> GetCoursesAsync();
        Task<CourseModel> GetCourseByIdAsync(Guid id);
        Task<CourseModel> UpdateCoursesAsync(CourseModel model);
    }
}