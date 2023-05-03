
namespace EventsAndDelegates
{
    public class Channel
    {
        public string Name { get; set; }
        public CategoryEnum Category { get; set; }
        public List<Video> Videos { get; set; }
        public Channel(string name, CategoryEnum category) 
        {   
            Name = name;
            Category = category;
            Videos = new List<Video>();
        }

        public delegate void ChannelDelegate(Video video);
        public event ChannelDelegate Subscribers;

        public void Subscribing(ChannelDelegate subscribeMethod)
        {
            Subscribers += subscribeMethod;
        }

        public void Unsubscribing(ChannelDelegate subscribeMethod)
        {
            Subscribers -= subscribeMethod;
        }

        public void AddVideo(Video video)
        {
            Videos.Add(video);
            if(Subscribers != null && Subscribers.GetInvocationList().Length > 0)
            {
                Subscribers(video);
            }
            else
            {
                Console.WriteLine($"The channel {Name} has no subscribers");
            }
        }
    }
}
