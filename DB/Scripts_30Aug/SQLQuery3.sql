
begin transaction
update tbl_ModuleTrack set AccessBy='Test1', UserId='9CA1901B-19DA-4231-A618-D5F136038081', IndustryId='2' where CategoryId=1 AND UserId is null
ROLLBACK transaction

select * from tbl_ModuleTrack where UserId is null



begin transaction
update Tbl_ResourceLibrary_ModuleTrack set AccessBy='Test1', UserId='9CA1901B-19DA-4231-A618-D5F136038081', IndustryId='2'where UserId is null and AccessDateTime >='2012-07-25 11:21:11.783'
ROLLBACK transaction

select * from Tbl_ResourceLibrary_ModuleTrack where UserId is null and AccessDateTime >='2012-07-25 11:21:11.783'