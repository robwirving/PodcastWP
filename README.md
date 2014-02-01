PodcastWP
=========

A helper class for Windows Phone 8 podcast apps, and apps that want to send commands to WP8 podcast apps.

## Installation ##
PodcastWP can be installed from NuGet:

```
Install-Package PodcastWP
```

## Send Commands to Podcast Apps ##
The PodcastHelper class can send commands to Launch, Play, Pause or skip to the next or previous podcast app using this method:

```c#
PodcastHelper.CommandPodcastApp(PodcastCommand.Launch);
```

## Use in Podcast Apps ##
The PodcastHelper will allow you to easily check a URL for the presence of a PodcastWP command.

Register for the custom URI scheme in your app's manifest file by adding this line in your manifest files <Extensions> tag.
```xml
<Protocol Name="wp-podcast" NavUriFragment="encodedLaunchUri=%s" TaskID="_default" />
```

In your UriMapper, you will have code similar to this:

```c#
if (PodcastHelper.HasPodcastUri(uri))
{
	var action = PodcastHelper.RetrievePodcastAction(uri);
	
	// Perform action in your app
	
	return new Uri("MainPage.xaml", UriKind.Relative);
}
```