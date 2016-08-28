SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
-- =============================================
-- Author:		Behnam Emamian
-- Create date: 
-- Description:	
-- =============================================
CREATE FUNCTION [dbo].[IsFibonacci] 
(
	@Number int
)
RETURNS bit
AS
BEGIN
	DECLARE @Result bit = 0

	if(@Number = 0)
		RETURN 1

	declare @a bigint=0, @b bigint=1, @fib bigint=0, @counter int=0, @end int = 50
	 	
	while @counter < @end
	begin
		set @fib = @a + @b
		if(@fib = @Number)
			RETURN 1
		set @a = @b
		set @b = @fib
	
		set @counter = @counter + 1 
	end

	RETURN @Result

END
GO
