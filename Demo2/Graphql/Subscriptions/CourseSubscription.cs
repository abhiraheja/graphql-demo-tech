using Demo2.Models;

namespace Demo2.Graphql.Subscriptions
{
    public class CourseSubscription
    {

        [Subscribe]
        public CourseModel CourseCreated([EventMessage] CourseModel course)
        {
            return course;
        }
    }
}
