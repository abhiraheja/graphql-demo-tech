using Demo1.Helpers.DataLoaders;
using Demo1.Models;
using HotChocolate.Resolvers;

namespace Demo1.Helpers.Resolvers
{
    //public class SubjectDetailModel3Resolver : ObjectType<SubjectDetailModel3>
    //{
    //    protected override void Configure(IObjectTypeDescriptor<SubjectDetailModel3> descriptor)
    //    {
    //        descriptor.Field("instructor").Resolve(InstructorResponse);
    //        base.Configure(descriptor);
    //    }

    //    Task<InstructorModel1> InstructorResponse(IResolverContext context)
    //    {
    //        var instructorDataLoader = context.DataLoader<InstructorModel1DataLoader>();
    //        var parent = context.Parent<SubjectDetailModel3>();
    //        return instructorDataLoader.LoadAsync(parent.Id);
    //    }
    //}
}
