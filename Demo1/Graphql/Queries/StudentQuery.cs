using Demo1.Data;
using Demo1.Data.Entities;
using Demo1.Data.Repository;
using Demo1.Models;
using HotChocolate.Data.Sorting;

namespace Demo1.Graphql.Queries
{
    public partial class Query
    {
        public Query()
        {
            Console.Clear();
        }
        public Task<List<StudentModel>> GetStudents([Service] IStudentRepository studentRepository)
        {
            return studentRepository.GetStudentsAsync();
        }

        public Task<StudentModel> GetStudentById(Guid id, [Service] IStudentRepository studentRepository)
        {
            return studentRepository.GetStudentByIdAsync(id);
        }

        public Task<List<StudentDetailModel>> GetStudentsDetail([Service] IStudentRepository studentRepository)
        {
            return studentRepository.GetStudentsDetails();
        }

        public async Task<List<StudentDetailModel>> GetStudentsDetailN1([Service] IStudentRepository studentRepository)
        {
            var a = await studentRepository.GetStudentsAsync();
            return a.Select(x => new StudentDetailModel
            {
                Id = x.Id,
                FatherName = x.FatherName,
                Name = x.Name,
                RollNumber = x.RollNumber,
            }).ToList();
        }



    }


}
