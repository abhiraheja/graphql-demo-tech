namespace Demo2.Models
{
    public class StudentDetailModel
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public int RollNumber { get; set; }

        public List<CourseDetailModel> Courses { get; set; }
    }


}
