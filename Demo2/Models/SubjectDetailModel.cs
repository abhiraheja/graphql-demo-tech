namespace Demo2.Models
{
    public class SubjectDetailModel
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public InstructorModel Instructor { get; set; }
    }
}
