$file = new-object System.Xml.XmlDocument
$path = (Get-Item $PSScriptRoot).parent.Fullname

$file.load($path + "\app.config")
$applicationSettingKey = $file.SelectNodes("/configuration/applicationSettings/DanskeSpil.Common.TestFramework.Properties.Settings/setting[@name='BrowserStackKey']")

$process = $PSScriptRoot + "\BrowserStackLocal.exe "
$arguments = $applicationSettingKey[0].value + " --proxy-host 192.168.199.2 --proxy-port 8080 --F --only-automate --verbose 2 --parallel-runs 1 --local-identifier " + [System.Environment]::MachineName

Write-Output $process $arguments
start-process $process $arguments
