using AutoMapper;
using Demo2.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Data.Repository
{

    public class CourseRepository : ICourseRepository
    {
        readonly IDbContextFactory<AppDbContext> _contextFactory;
        readonly IMapper _mapper;

        public CourseRepository(IDbContextFactory<AppDbContext> contextFactor, IMapper mapper)
        {
            _contextFactory = contextFactor;
            _mapper = mapper;
        }

        public Task<List<CourseModel>> GetCoursesAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return context.CourseEntities.Select(x => _mapper.Map<CourseModel>(x)).ToListAsync();
        }

        public async Task<CourseModel> GetCourseByIdAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedCourse = await context.CourseEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedCourse == null)
            {
                throw new GraphQLException("Course not available");
            }
            return _mapper.Map<CourseModel>(selectedCourse);
        }

        public async Task<CourseModel> AddCoursesAsync(string name)
        {
            using var context = _contextFactory.CreateDbContext();
            Guid guid = Guid.NewGuid();
            var entity = new Entities.CourseEntity
            {
                Id = guid,
                Name = name,
            };
            context.CourseEntities.Add(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<CourseModel>(entity);
        }

        public async Task<CourseModel> UpdateCoursesAsync(CourseModel model)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedCourse = await context.CourseEntities.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (selectedCourse == null)
            {
                throw new GraphQLException("Course not available");
            }
            selectedCourse.Name = model.Name;
            context.CourseEntities.Update(selectedCourse);
            await context.SaveChangesAsync();
            return _mapper.Map<CourseModel>(selectedCourse);
        }

        public async Task<string> DeleteCoursesAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedCourse = await context.CourseEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedCourse == null)
            {
                throw new GraphQLException("Course not available");
            }
            context.CourseEntities.Remove(selectedCourse);
            await context.SaveChangesAsync();
            return "Course deleted successfully";
        }
    }
}

