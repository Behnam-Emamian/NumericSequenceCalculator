SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Behnam Emamian
-- Create date: 29/08/2016
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SequenceNumber_Insert] 
	@Number int = 0 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

INSERT INTO SequenceNumbers
                         (Number, IsOdd, IsEven, IsMultipleBy3, IsMultipleBy5, IsFibonacci)
VALUES        (@Number, dbo.IsOdd(@Number), dbo.IsEven(@Number), dbo.IsMultipleBy3(@Number), dbo.IsMultipleBy5(@Number), dbo.IsFibonacci(@Number))

END
GO
