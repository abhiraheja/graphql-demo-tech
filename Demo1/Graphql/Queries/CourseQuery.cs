using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Graphql.Queries
{
    public partial class Query
    {
        public Task<List<CourseModel>> GetCourses([Service] ICourseRepository courseRepository)
        {
            return courseRepository.GetCoursesAsync();
        }

        public Task<CourseModel> GetCoursesById(Guid id, [Service] ICourseRepository courseRepository)
        {
            return courseRepository.GetCourseByIdAsync(id);
        }
    }
}
