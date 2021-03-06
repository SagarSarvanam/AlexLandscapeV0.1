ALTER PROCEDURE [dbo].[sp_Admin]
(
	@flag		CHAR(10)		=	NULL,
	@id			INT				=	NULL,
	@username	NVARCHAR(255)	=	NULL,
	@password	NVARCHAR(255)	=	NULL,
	@email		NVARCHAR(255)	=	NULL,
	@isActive	BIT				=	NULL
)
AS
	SET NOCOUNT ON;
		BEGIN
			IF(@flag='adLogin')
			BEGIN
				BEGIN TRANSACTION
					IF EXISTS(SELECT 'X' FROM tblUser u WHERE u.username = @username AND u.[password] = @password AND u.isActive=1)
					BEGIN
						SELECT * FROM tblUser u WHERE u.username = @username AND u.[password] = @password AND u.isActive=1
					END
				COMMIT TRANSACTION
				RETURN
			END
	END 