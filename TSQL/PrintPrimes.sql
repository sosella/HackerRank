DECLARE @str VARCHAR(MAX) = '';
DECLARE @i INT = 1;
WHILE @i <= 1000
BEGIN
	DECLARE @retVal BIT = 1;
	DECLARE @x INT = 1;
	DECLARE @y INT = 0;

	WHILE (@x <= @i )
	BEGIN

		IF (( @i % @x) = 0 )
		BEGIN
			SET @y = @y + 1;
		END

		IF (@y > 2 )
		BEGIN
			SET @retVal = 0;
			BREAK
		END

		SET @x = @x + 1;
	END

	IF (@retVal = 1)
	BEGIN
		SET @str += CONVERT(VARCHAR(10),@i) + '&';
	END

	SET @i = @i + 1;
END

PRINT SUBSTRING(@str, 1, LEN(@str) - 1);
