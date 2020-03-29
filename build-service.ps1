$AppPath = "$PSScriptRoot\HwInfoWorker"

Write-Host "Building service ..."

dotnet restore $AppPath
dotnet build $AppPath -c Release -o $AppPath\build\HwInfoWorker

Write-Host "Press any key to continue ..."
Start-Process PowerShell {[void][System.Console]::ReadKey($true)} -Wait -NoNewWindow