using Demo1.Data.Entities;
using Demo1.Data;

namespace Demo1.Graphql.Queries
{
    public partial class Query
    {

        ///Demo
        ///

        //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        //public Task<List<StudentModel>> CursorStudents([Service] IStudentRepository studentRepository)
        //{
        //    return studentRepository.GetStudentsAsync();
        //}

        //[UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        //public Task<List<StudentModel>> OffsetStudents([Service] IStudentRepository studentRepository)
        //{
        //    return studentRepository.GetStudentsAsync();
        //}


        //With DATABASE ----------------------------------------

        //[UseDbContext(typeof(AppDbContext))]
        //[GraphQLName("studentDb")]
        //public IQueryable<StudentEntity> GetStudents([ScopedService] AppDbContext context)
        //{
        //    return context.StudentEntities.AsQueryable();
        //}


        // Pagination

        //[UseDbContext(typeof(AppDbContext))]
        //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        //[GraphQLName("paginatedStudentDb")]
        //public IQueryable<StudentEntity> GetPaginatedStudents([ScopedService] AppDbContext context)
        //{
        //    return context.StudentEntities.AsQueryable();
        //}

        // Filter

        //[UseDbContext(typeof(AppDbContext))]
        //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        //[UseFiltering]
        //[GraphQLName("filterStudentDb")]
        //public IQueryable<StudentEntity> GetFilterStudents([ScopedService] AppDbContext context)
        //{
        //    return context.StudentEntities.AsQueryable();
        //}


        // Sorting

        //[UseDbContext(typeof(AppDbContext))]
        //[UseSorting(typeof(StudentSortType))]
        //[GraphQLName("sortStudentDb")]
        //public IQueryable<StudentEntity> GetSortStudents([ScopedService] AppDbContext context)
        //{
        //    return context.StudentEntities.AsQueryable();
        //}


        // Projection

        [UseDbContext(typeof(AppDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLName("sortStudentDb")]
        public IQueryable<StudentEntity> GetSortStudents([ScopedService] AppDbContext context)
        {
            return context.StudentEntities.AsQueryable();
        }
    }
}
