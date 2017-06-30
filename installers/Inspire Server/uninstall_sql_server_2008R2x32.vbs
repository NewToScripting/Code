Option Explicit
 

Dim WshShell
Set WshShell = CreateObject("WScript.Shell")
WshShell.Run """C:\Program Files\Microsoft SQL Server\100\Setup Bootstrap\SQLServer2008R2\setup.exe"" Setup /qs /ACTION=uninstall /FEATURES=SQLEngine /INSTANCENAME=INSPIRE /IACCEPTSQLSERVERLICENSETERMS"
WSCript.Sleep 300000
