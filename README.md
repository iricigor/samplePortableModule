# Sample Portable Module

Based on https://docs.microsoft.com/en-us/powershell/scripting/dev-cross-plat/writing-portable-modules?view=powershell-7

## How to use it

```
dotnet publish -o publish
cd .\publish

Import-Module .\myModule.dll
gcm -Module myModule
Test-SampleCmdlet
```

It works in PowerShell core, but not in Windows PowerShell.
