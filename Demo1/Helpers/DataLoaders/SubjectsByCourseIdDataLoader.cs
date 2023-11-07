using Demo1.Data;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Helpers.DataLoaders
{
    public class SubjectsByCourseIdDataLoader : BatchDataLoader<Guid, List<SubjectDetailModel>>
    {
        readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public SubjectsByCourseIdDataLoader(IDbContextFactory<AppDbContext> dbContextFactory, IBatchScheduler batchScheduler, DataLoaderOptions options = null) : base(batchScheduler, options)
        {
            _dbContextFactory = dbContextFactory;
        }

        protected override async Task<IReadOnlyDictionary<Guid, List<SubjectDetailModel>>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.CourseSubjectEntities.Where(x => keys.Contains(x.CourseId)).Select(x => new
            {
                x.CourseId,
                Subject = new SubjectDetailModel
                {
                    Id = x.SubjectId,
                    Name = x.Subject.Name
                }
            }).GroupBy(x=>x.CourseId).ToDictionaryAsync(x => x.Key, x => x.Select(x=>x.Subject).ToList());
        }
    }
}
