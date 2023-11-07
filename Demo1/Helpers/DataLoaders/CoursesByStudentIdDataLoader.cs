using Demo1.Data;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Helpers.DataLoaders
{
    public class CoursesByStudentIdDataLoader : BatchDataLoader<Guid, CourseDetailModel>
    {
        readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public CoursesByStudentIdDataLoader(IDbContextFactory<AppDbContext> dbContextFactory, IBatchScheduler batchScheduler, DataLoaderOptions options = null) : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<Guid, CourseDetailModel>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.StudentCourseEntities.Where(x => keys.Contains(x.StudentId)).Select(x => new

            {
                x.StudentId,
                courses = new CourseDetailModel
                {
                    Id = x.CourseEntity.Id,
                    Name = x.CourseEntity.Name,
                }
            }).ToDictionaryAsync(x => x.StudentId, x => x.courses);
        }
    }
}
