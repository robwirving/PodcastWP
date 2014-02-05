using System;
using System.Collections.Generic;
using PodcastWP.Extensions;

namespace PodcastWP
{
    public static class PodcastHelper
    {
        private const string PodcastScheme = "wp-podcast://";

        private const string PlayModeArgument = "playMode";
        private const string UiModeArgument = "uiMode";
        private const string CallbackUriArgument = "callbackUri";
        private const string CallbackNameArgument = "callbackName";

        /// <summary>
        /// Launches a podcast app w/ a specified command
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="playMode">The mode of playback</param>
        /// <param name="uiMode">The mode of the UI</param>
        /// <param name="callbackUri">The callback URI for your app if you want to be called back after the podcast app finishes its command.</param>
        /// <param name="callbackName">The name of your app which could be displayed in the target podcast app</param>
        public static async void CommandPodcastApp(PodcastCommand command, PlayMode playMode = PlayMode.None, UiMode uiMode = UiMode.Standard, string callbackUri = "", string callbackName = "")
        {
            var url = string.Format("{0}{1}/", PodcastScheme, command.ToString());

            var queryParams = new List<string>();
            if (playMode != PlayMode.None)
            {
                queryParams.Add(string.Format("{1}={0}", playMode, PlayModeArgument));
            }
            if (uiMode != UiMode.Standard)
                queryParams.Add(string.Format("{1}={0}", uiMode, UiModeArgument));
            if (!string.IsNullOrEmpty(callbackUri))
            {
                queryParams.Add(string.Format("{1}={0}", callbackUri, CallbackUriArgument));
            }
            if (!string.IsNullOrEmpty(callbackUri))
            {
                queryParams.Add(string.Format("{1}={0}", callbackName, CallbackNameArgument));
            }

            var queryString = string.Join("&", queryParams);

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

            var playMode = queryString.ContainsKey(PlayModeArgument) ? (PlayMode)Enum.Parse(typeof(PlayMode), queryString[PlayModeArgument], true) : PlayMode.None;
            var uiMode = queryString.ContainsKey(UiModeArgument) ? (UiMode)Enum.Parse(typeof(UiMode), queryString[UiModeArgument], true) : UiMode.Standard;
            var callbackUri = queryString.ContainsKey(CallbackUriArgument) ? queryString[CallbackUriArgument] : string.Empty;
            var callbackName = queryString.ContainsKey(CallbackNameArgument) ? queryString[CallbackNameArgument] : string.Empty;

            PodcastAction action = new PodcastAction
            {
                Command = command,
                PlayMode = playMode,
                UiMode = uiMode,
                CallbackUri = callbackUri,
                CallbackName = callbackName
            };

            return action;
        }
    }
}