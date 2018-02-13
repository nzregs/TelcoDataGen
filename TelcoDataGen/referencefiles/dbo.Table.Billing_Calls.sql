CREATE TABLE [dbo].[Billing_Calls]
(
	[SubscriberId] VARCHAR(15) NULL, 
    [ADFSliceIdentifier] BINARY(32) NULL, 
    [ToNumber] VARCHAR(15) NULL, 
    [Duration] INT NULL, 
    [CallDate] DATETIME NULL
)
GO

CREATE TABLE [dbo].[Billing_Data]
(
	[SubscriberId] VARCHAR(15) NULL, 
    [ADFSliceIdentifier] BINARY(32) NULL,
    [FromNumber] VARCHAR(15) NULL, 	
    [Uri] VARCHAR(15) NULL, 
    [Bytes] INT NULL, 
    [EventDate] DATETIME NULL
)
GO