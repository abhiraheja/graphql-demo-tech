using Demo1.Helpers.DataLoaders;
using Demo1.Models;
using HotChocolate.Resolvers;

namespace Demo1.Helpers.Resolvers
{
    public class StudentDetailModelResolver : ObjectType<StudentDetailModel>
    {
        protected override void Configure(IObjectTypeDescriptor<StudentDetailModel> descriptor)
        {
            descriptor.Field("courses").Resolve(CoursesResponse);
            base.Configure(descriptor);
        }

        Task<CourseDetailModel> CoursesResponse(IResolverContext context)
        {
            var courseByStudentId = context.DataLoader<CoursesByStudentIdDataLoader>();
            var parent = context.Parent<StudentDetailModel>();
            return courseByStudentId.LoadAsync(parent.Id);
        }
    }
}
