$serviceName = "HwInfoWorker"

if (![bool](([System.Security.Principal.WindowsIdentity]::GetCurrent()).groups -match "S-1-5-32-544")) 
{
	Write-Host "Script requires admin privileges to run."
}
elseif (!(Get-Service $serviceName -ErrorAction SilentlyContinue))
{
	Write-Host "Service does not exist."
}
elseif ((Get-Service $serviceName).Status -eq "Running")
{
	Write-Host "Service is running. Please run 'stop-service.ps1' script first."
}
else
{
	Write-Host "Uninstalling service ..."

	sc.exe delete $serviceName

	$DestinationPath = "C:\Program Files (x86)"
	if ((Get-WmiObject win32_operatingsystem | select osarchitecture).osarchitecture -like "64*")
	{
		$DestinationPath = "C:\Program Files"
	}

	Remove-Item "$DestinationPath\HwInfoWorker" -Recurse

	if ([System.Diagnostics.EventLog]::Exists($serviceName)) 
	{
		Remove-EventLog -LogName $serviceName
	}
}
Write-Host "Press any key to continue ..."
Start-Process PowerShell {[void][System.Console]::ReadKey($true)} -Wait -NoNewWindow