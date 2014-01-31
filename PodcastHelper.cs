using System;
using PodcastWP.Extensions;

namespace PodcastWP
{
    public static class PodcastHelper
    {
        private const string PodcastScheme = "wp-podcast://";

        /// <summary>
        /// Launches a podcast app w/ a specified command
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="playMode">The mode of playback</param>
        /// <param name="uiMode">The mode of the UI</param>
        /// <param name="callbackUri">The callback URI for your app if you want to be called back after the podcast app finishes its command.</param>
        public static async void CommandPodcastApp(PodcastCommand command, PlayMode playMode = PlayMode.None, UiMode uiMode = UiMode.Standard, string callbackUri = "")
        {
            var url = string.Format("{0}{1}/", PodcastScheme, command.ToString());

            var queryString = ((playMode != PlayMode.None) ? string.Format("playMode={0}", playMode) : string.Empty);
            if (!string.IsNullOrEmpty(queryString))
                queryString += "&";
            queryString += ((uiMode != UiMode.Standard) ? string.Format("uiMode={0}", uiMode) : string.Empty);
            queryString += (!string.IsNullOrEmpty(callbackUri) ? string.Format("callbackuri={0}", callbackUri) : string.Empty);

            url += (!string.IsNullOrEmpty(queryString) ? string.Format("?{0}", queryString) : string.Empty);

            await Windows.System.Launcher.LaunchUriAsync(new Uri(url));
        }

        /// <summary>
        /// Determines whether the specified URI uses the podcast URI scheme
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>True if pocket data is present</returns>
        public static bool HasPodcastUri(Uri uri)
        {
            var escapedProtocol = Uri.EscapeDataString(PodcastScheme);
            return uri.ToString().Contains(escapedProtocol);
        }
        
        /// <summary>
        /// Retrieves the podcast action.
        /// </summary>
        /// <param name="uri">The URI.</param>
        /// <returns>The deserialised podcast action</returns>
        public static PodcastAction RetrievePodcastAction(Uri uri)
        {
            var podcastUri = uri.ToString().Replace("/Protocol?encodedLaunchUri=", string.Empty);
            podcastUri = Uri.UnescapeDataString(podcastUri);

            var commandString = new Uri(podcastUri, UriKind.Absolute).CommandString();
            var queryString = new Uri(podcastUri, UriKind.Absolute).QueryString();

            PodcastCommand command = (PodcastCommand)Enum.Parse(typeof(PodcastCommand), commandString, true);

            var playMode = queryString.ContainsKey("playMode") ? (PlayMode)Enum.Parse(typeof(PlayMode), queryString["playMode"], true) : PlayMode.None;
            var uiMode = queryString.ContainsKey("uiMode") ? (UiMode)Enum.Parse(typeof(UiMode), queryString["uiMode"], true) : UiMode.Standard;
            var callbackUri = queryString.ContainsKey("callbackuri") ? queryString["callbackuri"] : string.Empty;

            PodcastAction action = new PodcastAction
            {
                Command = command,
                PlayMode = playMode,
                UiMode = uiMode,
                CallbackUri = callbackUri
            };

            return action;
        }
    }
}