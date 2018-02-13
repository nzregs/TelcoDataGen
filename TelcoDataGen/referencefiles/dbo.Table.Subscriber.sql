CREATE TABLE [dbo].[Subscriber]
(
	[SubscriberID] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [SubscriberNumber] VARCHAR(15) NOT NULL, 
    [FirstName] VARCHAR(50) NULL, 
    [LastName] VARCHAR(50) NULL, 
    [AddressLine1] VARCHAR(255) NULL, 
    [AddressLine2] VARCHAR(255) NULL, 
    [AddressCity] VARCHAR(50) NULL, 
    [AddressCountry] VARCHAR(50) NULL
)
