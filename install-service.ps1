$serviceName = "HwInfoWorker"

if (![bool](([System.Security.Principal.WindowsIdentity]::GetCurrent()).groups -match "S-1-5-32-544")) 
{
	Write-Host "Script requires admin privileges to run."
}
elseif (Get-Service $serviceName -ErrorAction SilentlyContinue)
{
	Write-Host "Service is already installed."
}
else 
{
	$AppPath = "$PSScriptRoot\HwInfoWorker"

	if (!(Test-Path "$AppPath\build\HwInfoWorker"))
	{
		Write-Host "$AppPath\build\HwInfoWorker path does not exist. Please run 'build-service.ps1' script first."
	}
	else 
	{
		Write-Host "Installing service ..."

		$DestinationPath = "C:\Program Files (x86)"
		if ((Get-WmiObject win32_operatingsystem | select osarchitecture).osarchitecture -like "64*")
		{
			$DestinationPath = "C:\Program Files"
		}

		Copy-Item "$AppPath\build\HwInfoWorker" -Destination $DestinationPath -Recurse

		New-Service -Name $serviceName -BinaryPathName $DestinationPath\HwInfoWorker\HwInfoWorker.exe -Description "Stores HwInfoElements to an ElasticSearch Database instance" -DisplayName $serviceName -StartupType Automatic

		if (![System.Diagnostics.EventLog]::Exists($serviceName)) 
		{
			New-EventLog -source $serviceName -LogName $serviceName
		}
	}
}
Write-Host "Press any key to continue ..."
Start-Process PowerShell {[void][System.Console]::ReadKey($true)} -Wait -NoNewWindow