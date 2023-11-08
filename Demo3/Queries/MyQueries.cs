using Demo3.Models;

namespace Demo3.Queries
{
    public class MyQueries
    {
        public MyModel GetMyModel()
        {
            return new MyModel("Abhishek Raheja", DateTime.Now);
        }
    }
}