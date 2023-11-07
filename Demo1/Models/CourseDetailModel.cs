namespace Demo1.Models
{
    public class CourseDetailModel
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<SubjectDetailModel> Subjects { get; set; }
    }
}
