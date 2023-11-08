using Demo2.Data.Repository;
using Demo2.Graphql.Subscriptions;
using Demo2.Models;
using HotChocolate.Subscriptions;

namespace Demo2.Graphql.Mutation
{
    public class CourseMutation
    {
        public async Task<CourseModel> CreateCourseWithEvent(string courseName, [Service] ICourseRepository courseRepository,
            [Service] ITopicEventSender topicEventSender)
        {

            var result = await courseRepository.AddCoursesAsync(courseName);
            await topicEventSender.SendAsync(nameof(CourseSubscription.CourseCreated), result);
            return result;
        }
    }
}
