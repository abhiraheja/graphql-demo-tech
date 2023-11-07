using Demo1.Helpers.DataLoaders;
using Demo1.Models;
using HotChocolate.Resolvers;

namespace Demo1.Helpers.Resolvers
{
    public class SubjectDetailModelResolver : ObjectType<SubjectDetailModel>
    {
        protected override void Configure(IObjectTypeDescriptor<SubjectDetailModel> descriptor)
        {
            descriptor.Field("instructor").Resolve(InstructorResponse);
            base.Configure(descriptor);
        }

        Task<InstructorModel1> InstructorResponse(IResolverContext context)
        {
            var instructorDataLoader = context.DataLoader<InstructorModel1DataLoader>();
            var parent = context.Parent<SubjectDetailModel>();
            return instructorDataLoader.LoadAsync(parent.Id);
        }
    }
}
