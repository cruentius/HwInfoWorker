# HwInfoWorker

ASP .NET Core 3.1 Worker Service to store HwInfoElements to an ElasticSearch Database instance.
Can be used in conjunction with [Grafana](https://grafana.com) to display and monitor the stored data in a dashboard.

# Release notes

version 1.0.1:
- Added service scripts to solution
- Did some code refactoring
- Updated nuget packages

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
Open a PowerShell window with admin privileges. Run this command and type 'Yes' to temporarily enable execution of scripts on the system:

```powershell
Set-ExecutionPolicy RemoteSigned
```

Open a new PowerShell window with admin privileges and change directory to the root folder of the solution. 
Run the scripts like so to build and install the service (order does matter!):

```powershell
.\build-service.ps1
.\install-service.ps1
```

Service can be started with this script:

```powershell
.\start-service.ps1
```

And stopped by this script:

```powershell
.\stop-service.ps1
```

After starting the service, you are able to see application logs in 'Event Viewer'.

If you wish to uninstall the service, use the .\uninstall-service.ps1 script.

After installation, do not forget to disable execution of scripts on the system:

```powershell
Set-ExecutionPolicy Restricted
```

Available on [releases](https://github.com/Antiserum420/HwInfoWorker/releases) page.