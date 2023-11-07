using Demo1.Models;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace Demo1.Graphql.Subscription
{
    public class Subscription
    {
        [Subscribe]
        public CourseModel CourseCreated([EventMessage] CourseModel course)
        {
            return course;
        }


        // Specific name
        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseModel>> CourseUpdated(Guid courseId, [Service] ITopicEventReceiver topicEventReceiver)
        {
            var topicName = $"{courseId}_{nameof(Subscription.CourseUpdated)}";
            return topicEventReceiver.SubscribeAsync<CourseModel>(topicName);
        }
    }
}
