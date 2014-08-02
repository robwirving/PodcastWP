using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace PodcastWP.Extensions
{
    internal static class UriExtensions
    {
        /// <summary>
        /// Gets a collection of query string values.
        /// </summary>
        /// <param name="uri">The current uri.</param>
        /// <returns>A collection that contains the query string values.</returns>
        internal static IDictionary<string, string> QueryString(this Uri uri)
        {
            var uriString = uri.IsAbsoluteUri ? uri.AbsoluteUri : uri.OriginalString;

            var queryIndex = uriString.IndexOf("?", StringComparison.Ordinal);

            if (queryIndex == -1)
            {
                return new Dictionary<string, string>();
            }

            var query = uriString.Substring(queryIndex + 1);

            return query.Split('&')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Split('='))
                .ToDictionary(x => x[0], x => x.Length == 2 && !string.IsNullOrEmpty(x[1]) ? x[1] : null);
        }

        /// <summary>
        /// Gets the command string value
        /// </summary>
        /// <param name="uri">The current uri.</param>
        /// <returns>A command string.</returns>
        internal static string CommandString(this Uri uri)
        {
            var uriString = uri.IsAbsoluteUri ? uri.AbsoluteUri : uri.OriginalString;

            return uriString.Split('/')
                .Where(x => (!string.IsNullOrEmpty(x) && !x.Contains(':')))
                .First();
        }
    }
}
