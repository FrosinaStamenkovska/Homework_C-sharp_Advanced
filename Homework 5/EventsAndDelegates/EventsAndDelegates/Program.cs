namespace EventsAndDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Channel channel1 = new Channel("Channel 1", CategoryEnum.Education);
            Channel channel2 = new Channel("Channel 2", CategoryEnum.Sport);
            Channel channel3 = new Channel("Channel 3", CategoryEnum.Science);

            Video video1 = new Video("Video 1", "This video is about education.", 360);
            Video video2 = new Video("Video 2", "This video is about sport.", 400);
            Video video3 = new Video("Video 3", "This video is about science.", 560);
            Video video4 = new Video("Video 4", "This video is about something.", 720);

            Subscriber subscriber1 = new Subscriber("Subscriber1");
            Subscriber subscriber2 = new Subscriber("Subscriber2");
            Subscriber subscriber3 = new Subscriber("Subscriber3");

            channel1.Subscribing(subscriber1.NewVideoEvent);
            channel2.Subscribing(subscriber2.NewVideoEvent);
            channel2.Subscribing(subscriber3.NewVideoEvent);
            
            channel1.AddVideo(video1);
            channel2.AddVideo(video2);
            channel3.AddVideo(video3);

            Console.WriteLine("\nAfter unsubscribing Subscriber 3 from Channel 2.");
            channel2.Unsubscribing(subscriber3.NewVideoEvent);
            channel2.AddVideo(video4);


        }
    }
}