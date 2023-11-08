using AutoMapper;
using Demo1.Data.Entities;
using Demo1.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo1.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        readonly IDbContextFactory<AppDbContext> _contextFactory;
        readonly IMapper _mapper;

        public StudentRepository(IDbContextFactory<AppDbContext> contextFactor, IMapper mapper)
        {
            _contextFactory = contextFactor;
            _mapper = mapper;
        }

        public Task<List<StudentModel>> GetStudentsAsync()
        {
            using var context =
           _contextFactory.CreateDbContext();

            return context.StudentEntities.Select(x => _mapper.Map<StudentModel>(x)).ToListAsync();
        }

        public async Task<StudentModel> GetStudentByIdAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedStudent = await context.StudentEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedStudent == null)
            {
                throw new GraphQLException("Student not available");
            }
            return _mapper.Map<StudentModel>(selectedStudent);
        }

        public async Task<StudentModel> AddStudentAsync(StudentCreateRequestModel request)
        {
            using var context = _contextFactory.CreateDbContext();
            Guid guid = Guid.NewGuid();
            var entity = _mapper.Map<StudentEntity>(request);
            entity.Id = guid;
            context.StudentEntities.Add(entity);
            await context.SaveChangesAsync();
            return _mapper.Map<StudentModel>(entity);
        }

        public async Task<StudentModel> UpdateStudentAsync(StudentModel model)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedStudent = await context.StudentEntities.Where(x => x.Id == model.Id).FirstOrDefaultAsync();
            if (selectedStudent == null)
            {
                throw new GraphQLException("Student not available");
            }
            selectedStudent.Name = model.Name;
            context.StudentEntities.Update(selectedStudent);
            await context.SaveChangesAsync();
            return _mapper.Map<StudentModel>(selectedStudent);
        }

        public async Task<string> DeleteStudentAsync(Guid id)
        {
            using var context = _contextFactory.CreateDbContext();
            var selectedStudent = await context.StudentEntities.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (selectedStudent == null)
            {
                throw new GraphQLException("Student not available");
            }
            context.StudentEntities.Remove(selectedStudent);
            await context.SaveChangesAsync();
            return "Student deleted successfully";
        }


        public async Task<List<StudentDetailModel>> GetStudentsDetails()
        {
            using var context = _contextFactory.CreateDbContext();
            var result = await context.StudentEntities
                .Include(x => x.StudentCourseEntities)
                .ThenInclude(x => x.CourseEntity)
                .ThenInclude(x => x.CourseSubjects)
                .ThenInclude(x => x.Subject)
                .ThenInclude(x => x.InstructorSubjectEntity)
                .ThenInclude(x => x.InstructorEntity)
                .Select(x => new StudentDetailModel
                {
                    Id = x.Id,
                    FatherName = x.FatherName,
                    RollNumber = x.RollNumber,
                    Name = x.Name,
                    Courses = x.StudentCourseEntities.Select(y => new CourseDetailModel
                    {
                        Id = y.CourseEntity.Id,
                        Name = y.CourseEntity.Name,
                        Subjects = y.CourseEntity.CourseSubjects.Select(z => new SubjectDetailModel
                        {
                            Id = z.Subject.Id,
                            Name = z.Subject.Name,
                           
                        }).ToList()
                    }).ToList(),


                }).ToListAsync();

            return result;
        }
    }
}
