
namespace EventsAndDelegates
{
    public class Video
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public Video(string title, string description, int duration)
        {
            Title = title;
            Description = description;
            Duration = duration;

        }
    }
}
