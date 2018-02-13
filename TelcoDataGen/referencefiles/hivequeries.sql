-- Create External Tables
-- WASB Windows Azure Storage Blob 'wasb://<container name>@<storage account name>.blob.core.windows.net/<blob file name>'.

CREATE EXTERNAL TABLE IF NOT EXISTS cdrdataraw (jsonentry string) 
		PARTITIONED BY (year INT, month INT, day INT, hour INT)
		STORED AS TEXTFILE LOCATION "wasb://towerdata@difinitytel.blob.core.windows.net/";

ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=03) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/03';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=04) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/04';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=05) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/05';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=06) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/06';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=07) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/07';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=08) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/08';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=09) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/09';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=10) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/10';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=11) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/11';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=12) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/12';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=13) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/13';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=14) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/14';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=15) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/15';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=16) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/16';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=17) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/17';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=18) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/18';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=19) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/19';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=20) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/20';
ALTER TABLE cdrdataraw ADD IF NOT EXISTS PARTITION (year=2018, month=02, day=11, hour=21) LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/2018/02/11/21';
		
SELECT COUNT(*) FROM cdrdataraw;

-- CREATE STRUCTURED TABLES
CREATE TABLE IF NOT EXISTS cdrdata (
		eventdate string,
		fromnumber string,
		tonumber string,
		billingtype string,
  		subscriberid string,
  		firstname string,
  		lastname string,
  		uri string,
  		towerid string,
  		towername string,
  		toweraddress string,
  		towercity string,
  		towerlongitude string,
  		towerlatitude string,
 		bytes int,
  		dataplan string,
  		offer string,
		costpermb double,
  		duration int
	) PARTITIONED BY (year int, month int, day int, hour int) 
	ROW FORMAT DELIMITED FIELDS TERMINATED BY ',' LINES TERMINATED BY '\n'
	STORED AS TEXTFILE LOCATION 'wasb://towerdata@difinitytel.blob.core.windows.net/structureddata';

