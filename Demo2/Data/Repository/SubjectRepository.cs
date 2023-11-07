using AutoMapper;
using Demo2.Data.Entities;
using Demo2.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo2.Data.Repository
{

    public class SubjectRepository : ISubjectRepository
    {
        readonly IDbContextFactory<AppDbContext> _contextFactory;
        readonly IMapper _mapper;

        public SubjectRepository(IDbContextFactory<AppDbContext> contextFactor, IMapper mapper)
        {
            _contextFactory = contextFactor;
            _mapper = mapper;
        }

        public Task<List<SubjectModel>> GetSubjectsAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return context.SubjectEntities.Select(x => _mapper.Map<SubjectModel>(x)).ToListAsync();
        }

        public async Task<List<SubjectDetailModel>> GetSubjectsWithInstructorAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            var a = await context.SubjectEntities.Include(x => x.InstructorSubjectEntity)
                .ThenInclude(x => x.InstructorEntity)
                .Select(x => new SubjectDetailModel
            {
                Id = x.Id,
                Name = x.Name,
                Instructor = new InstructorModel
                {
                    Id = x.InstructorSubjectEntity.InstructorEntity.Id,
                    Name = x.InstructorSubjectEntity.InstructorEntity.Name,
                    FatherName = x.InstructorSubjectEntity.InstructorEntity.FatherName,
                    Salary = x.InstructorSubjectEntity.InstructorEntity.Salary,
                }
            }).ToListAsync();
            return a;
        }


        public async Task<SubjectModel> GetSubjectByIdAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedSubject = await context.SubjectEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedSubject == null)
            {
                throw new GraphQLException("Subject not available");
            }
            return _mapper.Map<SubjectModel>(selectedSubject);
        }

        public async Task<SubjectModel> AddSubjectAsync(string name)
        {
            using var context = _contextFactory.CreateDbContext();
            Guid guid = Guid.NewGuid();
            var entity = new Entities.SubjectEntity
            {
                Id = guid,
                Name = name,
            };
            context.SubjectEntities.Add(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<SubjectModel>(entity);
        }

        public async Task<SubjectModel> UpdateSubjectAsync(SubjectModel model)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedSubject = await context.SubjectEntities.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (selectedSubject == null)
            {
                throw new GraphQLException("Subject not available");
            }
            selectedSubject.Name = model.Name;
            context.SubjectEntities.Update(selectedSubject);
            await context.SaveChangesAsync();
            return _mapper.Map<SubjectModel>(selectedSubject);
        }

        public async Task<string> DeleteSubjectAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedSubject = await context.SubjectEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedSubject == null)
            {
                throw new GraphQLException("Subject not available");
            }
            context.SubjectEntities.Remove(selectedSubject);
            await context.SaveChangesAsync();
            return "Subject deleted successfully";
        }
    }
}

