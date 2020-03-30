USE [HappyBrides]
GO
DROP PROCEDURE IF EXISTS [CREATE_RECORD_COUPLE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Create couple record
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_RECORD_COUPLE] 
	@user nvarchar(150), 
	@pass nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Couple(UserName,PassWord) OUTPUT inserted.CoupleID VALUES (@user, @pass);
END
GO
DROP PROCEDURE IF EXISTS [CREATE_RECORD_LIST]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Create wishlist record
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_RECORD_LIST] 
	@code nvarchar(8), 
	@coupleId int, 
	@name1 nvarchar(50), 
	@name2 nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO WishList(UniqueCode,CoupleID,FirstName,SecondName) OUTPUT inserted.WishListID VALUES
	(@code, @coupleId, @name1, @name2);
END
GO
DROP PROCEDURE IF EXISTS [CREATE_RECORD_LISTITEM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Create wishlist item record
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_RECORD_LISTITEM] 
	@desc nvarchar(250), 
	@price money, 
	@pos int, 
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO WishListItem(Description,Price,Position,ListID) OUTPUT inserted.ItemID VALUES
	(@desc, @price, @pos, @list);
END
GO
DROP PROCEDURE IF EXISTS [CREATE_RECORD_CONTRIBUTOR]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Create contributor record
-- =============================================
CREATE PROCEDURE [dbo].[CREATE_RECORD_CONTRIBUTOR] 
	@name nvarchar(50), 
	@mess nvarchar(500)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Contributor(ContributorName, ContributorMessage) OUTPUT inserted.ContributorID VALUES
	(@name, @mess);
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_COUPLE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_COUPLE] 
	@user nvarchar(150), 
	@pass nvarchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT (CoupleID) FROM Couple WHERE UserName = @user AND PassWord = @pass;
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LIST_COUPLE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LIST_COUPLE] 
	@couple int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT FirstName, SecondName, WishListID FROM WishList WHERE CoupleID = @couple
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LIST_CODE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LIST_CODE] 
	@code nvarchar(8)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT FirstName, SecondName, WishListID FROM WishList WHERE UniqueCode = @code
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LIST_ITEM_COUPLE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LIST_ITEM_COUPLE] 
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Description, Price, Position FROM WishListItem WHERE ListID = @list
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LISTID_BY_COUPLEID]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LISTID_BY_COUPLEID] 
	@couple int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT WishListID FROM Wishlist WHERE CoupleID = @couple;
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LISTID_BY_CODE]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LISTID_BY_CODE] 
	@code int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT WishListID FROM Wishlist WHERE UniqueCode = @code;
END
GO
DROP PROCEDURE IF EXISTS [UPDATE_RECORD_LISTITEM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_RECORD_LISTITEM] 
	@desc nvarchar(250),
	@price money,
	@pos int,
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE WishListItem SET Description = @desc, Price = @price OUTPUT inserted.ItemID WHERE Position = @pos AND ListID = @list;
END
GO
DROP PROCEDURE IF EXISTS [DELETE_RECORD_LISTITEM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[DELETE_RECORD_LISTITEM]
	@pos int,
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM WishListItem OUTPUT deleted.ItemID WHERE ListID = @list AND Position = @pos;
END
GO
DROP PROCEDURE IF EXISTS [UPDATE_RECORD_LISTITEM_ORDER]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_RECORD_LISTITEM_ORDER]
	@desc nvarchar(250),
	@price money,
	@pos int,
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE WishListItem SET Position = @pos OUTPUT inserted.ItemID WHERE Description = @desc AND Price = @price AND ListID = @list
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LIST_GUEST]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LIST_GUEST]
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT FirstName, SecondName FROM Wishlist WHERE WishListID = @list
END
GO
DROP PROCEDURE IF EXISTS [READ_RECORD_LIST_ITEM_GUEST]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[READ_RECORD_LIST_ITEM_GUEST]
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT Description, Price, Position, IsClaimed FROM WishListItem WHERE ListID = @list
END
GO
DROP PROCEDURE IF EXISTS [UPDATE_RECORD_LIST_ITEM_CLAIM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Laura
-- Create date: 11-3-20
-- Description:	Get couple record with username and password
-- =============================================
CREATE PROCEDURE [dbo].[UPDATE_RECORD_LIST_ITEM_CLAIM]
	@desc nvarchar(250),
	@pos int,
	@con int,
	@list int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE WishListItem SET IsClaimed = 1, ContributorID = @con OUTPUT inserted.ItemID WHERE Description = @desc AND Position = @pos AND ListID = @list
END
GO