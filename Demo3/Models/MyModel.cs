namespace Demo3.Models
{
    public class MyModel
    {
        public MyModel(string myName, DateTime date)
        {
            MyName = myName;
            Timestamp = date;
        }
        public string MyName { get; }
        public DateTime Timestamp { get; }
    }
}
