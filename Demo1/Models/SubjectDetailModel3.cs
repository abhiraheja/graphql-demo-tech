using Demo1.Helpers.DataLoaders;

namespace Demo1.Models
{
    public class SubjectDetailModel3
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public InstructorModel1 Instructor { get; set; }
        
    }
}
