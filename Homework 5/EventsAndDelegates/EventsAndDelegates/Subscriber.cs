namespace EventsAndDelegates
{
    public class Subscriber
    {
        public string Username { get; set; }

        public Subscriber(string userName)
        {
            Username = userName;
        }

        public void NewVideoEvent(Video video)
        {
            Console.WriteLine($"{Username} received an event that new Video({video.Title} - {video.Duration} seconds) has been uploaded to the subscribed channel");
        }
    }
}
