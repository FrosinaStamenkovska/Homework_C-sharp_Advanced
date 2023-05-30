
namespace TimeTracking.Models
{
    public abstract class Activity
    {
        public TimeSpan TotalTime { get; set; }

        public Activity()
        {
            TotalTime = TimeSpan.Zero;
        }

    }
}
