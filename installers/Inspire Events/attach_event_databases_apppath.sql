USE [master]
GO
CREATE DATABASE [InspireFeedsDB] ON 
( FILENAME = N'<AppPath>\InspireEventsDB.mdf' ),
( FILENAME = N'<AppPath>\InspireEventsDB_log.ldf' )
FOR ATTACH
GO

