namespace PodcastWP
{
    public enum PodcastCommand
    {
        Launch,
        Play,
        Pause,
        SkipNext,
        SkipPrevious,
        Subscribe
    }

    public enum PlayMode
    {
        None,
        Recent,
        Random
    }

    public enum UiMode
    {
        Standard,
        Car
    }
}