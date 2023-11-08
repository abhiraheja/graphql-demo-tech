using Demo1.Data.Repository;
using Demo1.Graphql.Subscription;
using Demo1.Models;
using HotChocolate.Subscriptions;

namespace Demo1.Graphql.Mutation
{
    public partial class Mutation
    {


        public Task<CourseModel> CreateCourse(string courseName, [Service] ICourseRepository courseRepository)
        {
            return courseRepository.AddCoursesAsync(courseName);
        }

        public async Task<CourseModel> CreateCourseWithEvent(string courseName, [Service] ICourseRepository courseRepository, [Service] ITopicEventSender topicEventSender)
        {

            var result = await courseRepository.AddCoursesAsync(courseName);
            await topicEventSender.SendAsync(nameof(Subscription.Subscription.CourseCreated), result);
            return result;
        }

        public Task<CourseModel> UpdateCourse(CourseModel request, [Service] ICourseRepository courseRepository)
        {
            return courseRepository.UpdateCoursesAsync(request);
        }

        // Particular topic
        public async Task<CourseModel> UpdateCourseWithEvent(CourseModel request, [Service] ICourseRepository courseRepository, [Service] ITopicEventSender topicEventSender)
        {
            var result = await courseRepository.UpdateCoursesAsync(request);
            var topicName = $"{result.Id}_{nameof(Subscription.Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(topicName, result);
            return result;
        }

        public async Task<CourseModel> UpdateCourseWithECOEvent(CourseModel request, [Service] ICourseRepository courseRepository, [Service] ITopicEventSender topicEventSender)
        {
            var result = await courseRepository.UpdateCoursesAsync(request);
            var topicName = $"ECO";
            if (result.Name.Contains("ECO"))
            {
                await topicEventSender.SendAsync(topicName, result);
            }
            return result;
        }

        public Task<string> DeleteCourse(Guid id, [Service] ICourseRepository courseRepository)
        {
            return courseRepository.DeleteCoursesAsync(id);
        }
    }
}
