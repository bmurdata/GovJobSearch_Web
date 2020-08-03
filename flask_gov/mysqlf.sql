
-- Create the stored procedure in the specified schema
DELIMITER $$
CREATE PROCEDURE Sp_csv_nyc_gov(

     tbl_name VARCHAR(300),
     of_name VARCHAR(300)
)
    
BEGIN
 SELECT *  INTO OUTFILE '/home/pi/GovJobSearch_Web/flask_gov/export.csv'
FIELDS TERMINATED BY ','
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
FROM tbl_name;
END
$$
DELIMITER $$
