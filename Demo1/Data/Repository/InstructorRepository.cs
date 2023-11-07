﻿using AutoMapper;
using Demo1.Data.Entities;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Data.Repository
{

    public class InstructorRepository : IInstructorRepository
    {
        readonly IDbContextFactory<AppDbContext> _contextFactory;
        readonly IMapper _mapper;

        public InstructorRepository(IDbContextFactory<AppDbContext> contextFactor, IMapper mapper)
        {
            _contextFactory = contextFactor;
            _mapper = mapper;
        }

        public Task<List<InstructorModel>> GetInstructorAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return context.InstructorEntities.Select(x => _mapper.Map<InstructorModel>(x)).ToListAsync();

        }

        public async Task<InstructorModel> GetInstructorByIdAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedInstructor = await context.InstructorEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedInstructor == null)
            {
                throw new GraphQLException("Instructor not available");
            }
            return _mapper.Map<InstructorModel>(selectedInstructor);
        }

        public async Task<InstructorModel> GetInstructorBySubjectIdAsync(Guid subjectId)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedInstructor = await context.InstructorSubjectEntities.Where(x => x.SubjectId == subjectId).Select(x => x.InstructorEntity).FirstOrDefaultAsync();
            if (selectedInstructor == null)
            {
                throw new GraphQLException("Instructor not available");
            }
            return _mapper.Map<InstructorModel>(selectedInstructor);
        }

        public async Task<InstructorModel> AddInstructorAsync(InstructorCreateRequestModel request)
        {
            using var context = _contextFactory.CreateDbContext();
            Guid guid = Guid.NewGuid();
            var entity = _mapper.Map<InstructorEntity>(request);
            entity.Id = guid;
            context.InstructorEntities.Add(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<InstructorModel>(entity);
        }

        public async Task<InstructorModel> UpdateInstructorAsync(InstructorModel model)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedInstructor = await context.InstructorEntities.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (selectedInstructor == null)
            {
                throw new GraphQLException("Instructor not available");
            }
            selectedInstructor.Name = model.Name;
            context.InstructorEntities.Update(selectedInstructor);
            await context.SaveChangesAsync();
            return _mapper.Map<InstructorModel>(selectedInstructor);
        }

        public async Task<string> DeleteInstructorAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedInstructor = await context.InstructorEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedInstructor == null)
            {
                throw new GraphQLException("Instructor not available");
            }
            context.InstructorEntities.Remove(selectedInstructor);
            await context.SaveChangesAsync();
            return "Instructor deleted successfully";
        }

        public async Task<IReadOnlyDictionary<Guid, InstructorModel1>> GetInstructorBySubjectKeys(IReadOnlyList<Guid> keys)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.InstructorSubjectEntities.Where(x => keys.Contains(x.SubjectId)).Select(x => new { x.SubjectId, data = _mapper.Map<InstructorModel1>(x.InstructorEntity) })
                .ToDictionaryAsync(x => x.SubjectId, x => x.data);
        }
    }
}

