SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Behnam Emamian
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[IsEven] 
(
	-- Add the parameters for the function here
	@Number int
)
RETURNS bit
AS
BEGIN
	-- Declare the return variable here
	DECLARE @Result bit = 0

	if(@Number % 2 = 0)
		set @Result = 1

	-- Return the result of the function
	RETURN @Result

END
GO
