SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Behnam Emamian
-- Create date: 29/08/2016
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SequenceNumber_Delete] 
	@SequenceNumberId int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DELETE FROM SequenceNumbers
WHERE        (SequenceNumberId = @SequenceNumberId)

END
GO
