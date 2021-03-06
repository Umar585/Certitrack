USE [certitrack]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[stpAssignCertificate]
		-- customer params
		@customer_name = N'customer13',
		@customer_email = N'customer13@gmail.com',
		@customer_phone = N'555-555-5513',
		-- staff params
		@staff_name = N'Admin',
		-- promo params
		@promo_discount = 10,
		-- channel params
		@channel = 'assembly',
		-- order params
		@cert_qty = 4

SELECT * FROM [certificate_link]

GO

