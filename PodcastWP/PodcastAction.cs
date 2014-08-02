namespace PodcastWP
{
    public class PodcastAction
    {
        /// <summary>
        /// Gets or sets the command that was requested from the calling app
        /// </summary>
        /// <value>
        /// The command to perform.
        /// </value>
        public PodcastCommand Command { get; set; }

        /// <summary>
        /// Gets or sets the play mode that was requested from the calling app
        /// </summary>
        /// <value>
        /// The mode of play.
        /// </value>
        public PlayMode PlayMode { get; set; }

        /// <summary>
        /// Gets or sets the UI mode that was requested from the calling app
        /// </summary>
        /// <value>
        /// The mode of the UI.
        /// </value>
        public UiMode UiMode { get; set; }

        /// <summary>
        /// Gets or sets the url of the podcast feed you want the podcast app to subscribe to
        /// </summary>
        /// <value>
        /// The URl of the podcast feed
        /// </value>
        public System.Uri FeedUrl { get; set; }

        /// <summary>
        /// Gets or sets the callback URI for your app if you want to be called back after adding.
        /// </summary>
        /// <value>
        /// The callback URI.
        /// </value>
        public string CallbackUri { get; set; }

        /// <summary>
        /// Gets or sets the callback name of your app
        /// </summary>
        /// <value>
        /// The callback apps name
        /// </value>
        public string CallbackName { get; set; }
    }
}