USE nyc_gov_jobs
DELIMITER $$
CREATE PROCEDURE mixer()
BEGIN
	SELECT * FROM `search_by_agencycode`;
END
$$
DELIMITER ;
