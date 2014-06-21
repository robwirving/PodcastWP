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

## Subscribe to a Podcast ##
The PodcastHelper clas can also send commands to subscribe to a Podcast rss feed:
```c#
PodcastHelper.SubscribeToPodcast(new Uri("<rss feed url>"));
```
If you want to subscribe to a podcast without the PodcastHelper library you can also use the URI directly:
```c#
Launcher.LaunchUriAsync(new Uri("wp-podcast://Subscribe/?feedUrl=<rss feed url>"));
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

## Used by these wonderful apps:

[![BringCast](http://cdn.marketplaceimages.windowsphone.com/v8/images/ab0bf9d4-a999-46dd-b0ad-f68ea2f94407?imageType=ws_icon_tiny)](http://www.windowsphone.com/s?appid=e5abef38-d413-e011-9264-00237de2db9e) | [![Car Dash](http://cdn.marketplaceimages.windowsphone.com/v8/images/cae4e4ab-9c6b-4c79-853a-b826f61e8c89?imageType=ws_icon_tiny)](http://www.windowsphone.com/s?appid=5c8c34e1-34c4-4e3e-87b5-bbb7d4a8c652) | [![P Cast](http://cdn.marketplaceimages.windowsphone.com/v8/images/54d503f3-4444-4522-a199-e54268995037?imageType=ws_icon_tiny)](http://www.windowsphone.com/s?appid=4ddd2958-3a58-491f-963e-3a19dd205b1c) |
|---|---|---|
| [BringCast](http://www.windowsphone.com/s?appid=e5abef38-d413-e011-9264-00237de2db9e) | [Car Dash](http://www.windowsphone.com/s?appid=5c8c34e1-34c4-4e3e-87b5-bbb7d4a8c652) | [P Cast](http://www.windowsphone.com/s?appid=4ddd2958-3a58-491f-963e-3a19dd205b1c)

