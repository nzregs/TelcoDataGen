WITH processeddata AS (
    SELECT 
	    a.eventdate,
	    a.fromnumber,
        a.tonumber,
        a.type as billingtype,
        c.subscriberid,
	    c.firstname,
	    c.lastname,
	    a.uri,
        t.towerId as towerid,
        t.Name as towername,
        t.Address as toweraddress,
        t.City as towercity,
        t.Longitude as towerlongitude,
        t.Latitude as towerlatitude,
	    CAST(a.bytes AS float) as bytes,
        CASE  
		WHEN b.name is null THEN 'STANDARD DATA'
		ELSE b.name
	END as dataplan,
	CASE
		WHEN b.offer is null THEN 'NONE'
		ELSE b.offer
	END as offer,
	CASE 
		WHEN b.costpermb is null THEN 10
		ELSE CAST(b.costpermb AS float)
	END as costpermb,	
        a.duration
    FROM
	    streamdata a TIMESTAMP BY eventdate
        LEFT OUTER JOIN subscriberdata c
		    ON a.fromNumber = c.subscriberNumber
        LEFT OUTER JOIN towerdata t
            ON a.TowerId = t.TowerId
        LEFT OUTER JOIN dataspecialdata b
		    ON a.uri = b.uri        
)

SELECT
    MIN(eventdate) as windowstart,
    MAX(eventdate) as windowend,
    billingtype,
    fromnumber,
    firstname,
    lastname,
    tonumber,
    uri,
    SUM(bytes) as bytes,
    SUM(bytes)/1024 as kilobytes,
    SUM(bytes)/1024/1024 as megabytes,
    SUM(costpermb * (bytes/1024/1024)) as datacost,
    sum(duration) as minutes
INTO
    [towerstream-subscribersummary]
FROM
    processeddata
GROUP BY
    billingtype,
    fromnumber,
    firstname,
    lastname,
    tonumber,
    uri,
    TumblingWindow(minute, 5);


SELECT
    MIN(eventdate) as windowstart,
    MAX(eventdate) as windowend,
    uri,
    SUM(bytes) as bytes,
    SUM(bytes)/1024 as kilobytes,
    SUM(bytes)/1024/1024 as megabytes,
    SUM(costpermb * (bytes/1024/1024)) as datacost,
    count(tonumber) as numberrequests,
    count(DISTINCT tonumber) as numbersubscriberrequests
INTO
    [towerstream-datathroughput]
FROM
    processeddata
WHERE
    billingtype = 'data'
GROUP BY
    towername,
    toweraddress,
    towercity,
    towerlongitude,
    towerlatitude,
    uri,
    TumblingWindow(second, 30);

SELECT
    MIN(eventdate) as windowstart,
    MAX(eventdate) as windowend,
    towername,
    toweraddress,
    towercity,
    towerlongitude,
    towerlatitude,
    sum(duration) as minutes,
    count(tonumber) as numbercalls,
    count(DISTINCT tonumber) as numbersubscribercalls
INTO
    [towerstream-callthroughput]
FROM
    processeddata
WHERE
    billingtype = 'call'
GROUP BY
    towername,
    toweraddress,
    towercity,
    towerlongitude,
    towerlatitude,
    TumblingWindow(minute, 5);

SELECT
    MIN(eventdate) as windowstart,
    MAX(eventdate) as windowend,
    towername,
    toweraddress,
    towercity,
    towerlongitude,
    towerlatitude,
    count(tonumber) as numbercalls,
    count(DISTINCT tonumber) as numbersubscribercalls
INTO
    [towerstream-smsthroughput]
FROM
    processeddata
WHERE
    billingtype = 'sms'
GROUP BY
    towername,
    toweraddress,
    towercity,
    towerlongitude,
    towerlatitude,
    TumblingWindow(minute, 5);
    
SELECT * INTO cdrtowerlake FROM processeddata;
SELECT * INTO cdrtowerblob FROM processeddata;