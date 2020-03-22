# HwInfoWorker

ASP .NET Core 3.1 Worker Service to store HwInfoElements to an ElasticSearch Database instance.
Can be used in conjunction with [Grafana](https://grafana.com) to display the stored data in a dashboard.

# Release notes

version 1.0.0:
- Initial release

# Setup

Change the properties in 'appsettings.json' to satisfy your configuration:

| Property  | Description |
| ------------- | ------------- |
| ElasticSearchStore.EndpointAddress  | endpoint url of the ElasticSearch instance (e.g http://localhost:9200) |
| ElasticSearchStore.IndexName  | name of the ElasticSearch index (e.g hwinfo) |
| ElasticSearchStore.TimeoutMs  | default timeout in milliseconds for each request to ElasticSearch (e.g 1000) |
| ElasticSearchStore.MaxRetries  | the maximum number of retries for a given request (e.g 2) |
| BackgroundWorkers.StoreHwInfoElementWorker.DelayMs  | delay in milliseconds for the background worker (e.g 10000) |

# Usage

Build the application in Release mode. Register the service with PowerShell commands found [here](https://docs.microsoft.com/nl-nl/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-3.1&tabs=visual-studio).

After registering and starting the service, you are able to see logs in 'Event Viewer'. 