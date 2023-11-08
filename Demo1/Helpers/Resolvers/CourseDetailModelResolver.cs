using Demo1.Helpers.DataLoaders;
using Demo1.Models;
using HotChocolate.Resolvers;

namespace Demo1.Helpers.Resolvers
{
    //public class CourseDetailModelResolver : ObjectType<CourseDetailModel>
    //{
    //    protected override void Configure(IObjectTypeDescriptor<CourseDetailModel> descriptor)
    //    {
    //        descriptor.Field("subjects").Resolve(SubjectResponse);
    //        base.Configure(descriptor);
    //    }

    //    Task<List<SubjectDetailModel>> SubjectResponse(IResolverContext context)
    //    {
    //        var subjectsByStudentId = context.DataLoader<SubjectsByCourseIdDataLoader>();
    //        var parent = context.Parent<CourseDetailModel>();
    //        return subjectsByStudentId.LoadAsync(parent.Id);
    //    }
    //}
}
