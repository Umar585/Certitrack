USE [certitrack]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[stpAssignStaff]
		@staff_name = N'Staff10',
		@staff_email = N'staff10@gmail.com',
		@staff_pw = N'staff123',
		@role_title = N'Admin',
		@staff_type = N'Student Therapist'

GO
