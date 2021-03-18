--USE nyc_gov_jobs

--Export data from tables

-- Create a new stored procedure called 'sp_csv_nyc_gov ' in database
-- Drop the stored procedure if it already exists
DELIMITER $$

-- Create the stored procedure in the specified schema
CREATE PROCEDURE Sp_csv_nyc_gov(

    IN tbl_name VARCHAR(300)
    IN of_name VARCHAR(300)
)
    
BEGIN
 SELECT * FROM tbl_name INTO OUTFILE of_name $$ 
FIELDS TERMINATED BY ','
ENCLOSED BY '"'
LINES TERMINATED BY '\n'
END


DELIMITER ; $$