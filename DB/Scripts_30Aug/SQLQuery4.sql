SELECT * FROM Tbl_ResourceLibrary_ModuleTrack 
where UserId not in 
(select UserId FROM tbl_Registration where Password='jO1xo12i5vAN0Qoxu4xygQ==' and EmailID not in ('demo1@gmail.com','demo3@gmail.com','demo11@gmail.com'))


BEGIN transaction

DELETE Tbl_ResourceLibrary_ModuleTrack 
--where UserId is null
where AccessDateTime <='2012-06-27'


DELETE tbl_ModuleTrack  
where AccessDateTime <='2012-06-27'



ROLLBACK transaction

begin transaction
--there are two records need to update with another category
UPDATE Tbl_ResourceLibrary_ModuleTrack set CategoryId='2' where CategoryId in (73,74, 79,80)

rollback transaction


SELECT * FROM Tbl_ResourceLibrary_ModuleTrack where Description='Business Plan Template'



SELECT * FROM Tbl_ResourceLibrary_ModuleTrack where CategoryId in (73,74, 79,80)



