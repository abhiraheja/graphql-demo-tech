using Demo1.Data.Repository;
using Demo1.Helpers.DataLoaders;

namespace Demo1.Models
{
    public class SubjectDetailModel2
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }
        public string Name { get; set; }

        //public async Task<InstructorModel1> Instructor([Service] InstructorModel1DataLoader dataLoader)
        //{
        //    var a= await dataLoader.LoadAsync(Id);
        //    return a;
        //}
    }
}
