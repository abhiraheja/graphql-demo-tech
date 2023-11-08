using Demo1.Data.Entities;
using Demo1.Data;
using Demo1.Data.Repository;
using Demo1.Models;
using Demo1.Helpers.Attributes;

namespace Demo1.Graphql.Queries
{
    public partial class Query
    {

        ///Demo
        ///

        [UseOffsetPaging(DefaultPageSize = 2, IncludeTotalCount = true)]
        public async Task<List<StudentModel>> CursorStudents([Service] IStudentRepository studentRepository)
        {
            var a = await studentRepository.GetStudentsAsync();
            return a;
        }

        //[UseOffsetPaging(IncludeTotalCount = true, DefaultPageSize = 10)]
        //public Task<List<StudentModel>> OffsetStudents([Service] IStudentRepository studentRepository)
        //{
        //    return studentRepository.GetStudentsAsync();
        //}


        //With DATABASE ----------------------------------------

        [UseDbContext(typeof(AppDbContext))]
        [UsePaging(DefaultPageSize = 2)]
        [GraphQLName("studentDb")]
        public IQueryable<StudentEntity> GetStudents([ScopedService] AppDbContext context)
        {
            return context.StudentEntities.AsQueryable();
        }


        // Pagination

        //[UseDbContext(typeof(AppDbContext))]
        //[UsePaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        //[GraphQLName("paginatedStudentDb")]
        //public IQueryable<StudentEntity> GetPaginatedStudents([ScopedService] AppDbContext context)
        //{
        //    return context.StudentEntities.AsQueryable();
        //}

        // Filter

        [UseDbContext(typeof(AppDbContext))]
        [UsePaging(IncludeTotalCount = true, DefaultPageSize = 3)]
        [UseProjection]
        [UseFiltering]
        [UseSorting(typeof(StudentSortType))]

        [GraphQLName("filterStudentDb")]
        public IQueryable<StudentEntity> GetFilterStudents([ScopedService] AppDbContext context)
        {
            return context.StudentEntities.AsQueryable();
        }


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
