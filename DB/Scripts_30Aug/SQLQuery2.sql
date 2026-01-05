SELECT * FROM Tbl_ResourceLibrary_ModuleTrack 
where UserId in 
(select UserId FROM reg_Delete)

SELECT * FROM tbl_ModuleTrack 
where UserId in 
(select UserId FROM reg_Delete)


BEGIN transaction
delete Tbl_ResourceLibrary_ModuleTrack 
where UserId in 
(select UserId FROM reg_Delete)

delete  tbl_ModuleTrack 
where UserId in 
(select UserId FROM reg_Delete)

ROLLBACK transaction





 






