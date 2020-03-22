# HwInfoWorker

ASP .NET Core 3.1 Worker Service to store HwInfoElements to an ElasticSearch Database instance.
Can be used in conjunction with [Grafana](https://grafana.com) to display and monitor the stored data in a dashboard.

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

Build the application in Release mode. 
Register the service with these PowerShell commands:

```powershell
$acl = Get-Acl "path\to\HwInfoWorker\HwInfoWorker\HwInfoWorker\bin\Release\netcoreapp3.1"
$aclRuleArgs = "domain\username", "Read,Write,ReadAndExecute", "ContainerInherit,ObjectInherit", "None", "Allow"
$accessRule = New-Object System.Security.AccessControl.FileSystemAccessRule($aclRuleArgs)
$acl.SetAccessRule($accessRule)
$acl | Set-Acl "path\to\HwInfoWorker\HwInfoWorker\HwInfoWorker\bin\Release\netcoreapp3.1"

New-Service -Name HwInfoWorker -BinaryPathName path\to\HwInfoWorker\HwInfoWorker\HwInfoWorker\bin\Release\netcoreapp3.1\HwInfoWorker.exe -Credential domain\username -Description "test service" -DisplayName "HwInfoWorker" -StartupType Manual
```

Start the service like so:

```powershell
Start-Service -Name HwInfoWorker
```

For more information how to register or start a service, please read [this](https://docs.microsoft.com/nl-nl/aspnet/core/host-and-deploy/windows-service?view=aspnetcore-3.1&tabs=visual-studio).

After registering and starting the service, you are able to see application logs in 'Event Viewer'.

Available on [releases](https://github.com/Antiserum420/HwInfoWorker/releases) page.