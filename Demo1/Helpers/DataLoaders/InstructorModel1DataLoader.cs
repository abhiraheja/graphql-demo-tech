using Demo1.Data.Repository;
using Demo1.Models;

namespace Demo1.Helpers.DataLoaders
{
    public class InstructorModel1DataLoader : BatchDataLoader<Guid, InstructorModel>
    {
        readonly IInstructorRepository _instructorRepository;
        public InstructorModel1DataLoader(IInstructorRepository instructorRepository, IBatchScheduler batchScheduler, DataLoaderOptions options = null) : base(batchScheduler, options)
        {
            _instructorRepository = instructorRepository;
        }

        protected override Task<IReadOnlyDictionary<Guid, InstructorModel>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            return _instructorRepository.GetInstructorBySubjectKeys(keys);
        }
    }
}
