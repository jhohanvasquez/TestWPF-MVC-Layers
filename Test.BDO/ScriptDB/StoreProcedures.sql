




CREATE PROCEDURE [dbo].[RegisterOrSaveUserUsers]	
	  @IdUser integer,
	  @NameUser varchar(50),
      @BirthDate datetime,
      @IdGenderUser integer,
	  @Sex varchar(1)
AS
BEGIN

	declare @UserId int	
	
	SET NOCOUNT ON;
    
	IF  NOT EXISTS (SELECT * FROM TbUsers 
WHERE IdUser=@IdUser)
	begin
		
		SET @UserId = 0;

		insert into TbUsers(
				  NameUser,
				  BirthDate,
				  IdGenderUser,
				  Sex)
		values(	  @NameUser,
				  @BirthDate,
				  @IdGenderUser,
				  @Sex)
		
	end
	else
	begin

		SET @UserId = @IdUser
		
		update TbUsers
		set 			
			NameUser		= @NameUser,			
			BirthDate	= @BirthDate,
			IdGenderUser	= @IdGenderUser,
			Sex	= @Sex
		where IdUser = @UserId

	end

	SELECT top 1 * from TbUsers where IdUser = @UserId

END



SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListorDetailUser]
	-- Add the parameters for the stored procedure here
	 @IdUser integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
	if (@IdUser = 0)
	begin
     -- Insert statements for procedure here
SELECT TbUsers.IdUser, TbUsers.NameUser, TbUsers.BirthDate, TbUsers.IdGenderUser, TbUserGenders.GenderDescription, TbUsers.Sex
  FROM [dbo].[TbUsers] inner join TbUserGenders on TbUsers.IdGenderUser=TbUserGenders.IdGenderUser
END
	else
	begin
	SELECT TbUsers.IdUser, TbUsers.NameUser, TbUsers.BirthDate, TbUsers.IdGenderUser, TbUserGenders.GenderDescription, TbUsers.Sex
     FROM [dbo].[TbUsers] inner join TbUserGenders on TbUsers.IdGenderUser=TbUserGenders.IdGenderUser where IdUser=@IdUser;
  END
   END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	 @IdUser integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	delete from TbUsers where IdUser=@IdUser

END
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ListorDetailUserGenders]
	-- Add the parameters for the stored procedure here
	 @IdGenderUser integer
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
    
	if (@IdGenderUser = 0)
	begin
    -- Insert statements for procedure here
SELECT *
  FROM [dbo].[TbUserGenders]
END
	else
	begin
	SELECT *
     FROM [dbo].[TbUserGenders] where IdGenderUser=@IdGenderUser;
  END
   END

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET IDENTITY_INSERT [dbo].[TbUserGenders] ON 
GO
INSERT [dbo].[TbUserGenders] ([IdGenderUser], [GenderDescription]) VALUES (1, N'Heterosexual')
GO
INSERT [dbo].[TbUserGenders] ([IdGenderUser], [GenderDescription]) VALUES (2, N'Bisexual')
GO
INSERT [dbo].[TbUserGenders] ([IdGenderUser], [GenderDescription]) VALUES (3, N'Transgenero')
GO
INSERT [dbo].[TbUserGenders] ([IdGenderUser], [GenderDescription]) VALUES (4, N'Otros')
GO
SET IDENTITY_INSERT [dbo].[TbUserGenders] OFF
GO