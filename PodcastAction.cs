using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public PlayMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the callback URI for your app if you want to be called back after adding.
        /// </summary>
        /// <value>
        /// The callback URI.
        /// </value>
        public string CallbackUri { get; set; }
    }
}
