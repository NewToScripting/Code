USE [master]
GO
CREATE DATABASE [InspireServerDB] ON 
( FILENAME = N'<AppPath>\InspireServerDB.mdf' ),
( FILENAME = N'<AppPath>\InspireServerDB_log.ldf' ),
( FILENAME = N'<AppPath>\InspireServerFileStream' )
 FOR ATTACH
GO

