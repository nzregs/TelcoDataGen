$executingScriptDirectory = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent
$DatagenPath = "c:\datagen"
$SpawnCount = 10

if (![System.IO.Directory]::Exists($DatagenPath ))
{
     New-Item -ItemType Directory -Force -Path $DatagenPath
}

copy-item $executingScriptDirectory\* $DatagenPath -force

Start-Process -FilePath $DatagenPath -ArgumentList 'run'

For ($i=0; $i -le $SpawnCount; $i++) {
    Start-Process -FilePath $DatagenPath\TelcoDataGen.exe -ArgumentList 'run'
    }