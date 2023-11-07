using Demo1.Data.Entities;
using HotChocolate.Data.Sorting;

namespace Demo1.Helpers.Attributes
{
    public class StudentSortType : SortInputType<StudentEntity>
    {
        protected override void Configure(ISortInputTypeDescriptor<StudentEntity> descriptor)
        {
            descriptor.Ignore(x => x.Name);
            base.Configure(descriptor);
        }
    }
}
