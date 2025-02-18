DECLARE @i INT = 1;
DECLARE @number VARCHAR(10);
DECLARE @status VARCHAR(10);
DECLARE @issueDate DATE;
DECLARE @dueDate DATE;
DECLARE @serviceName VARCHAR(50);
DECLARE @unitPrice DECIMAL(18, 2);
DECLARE @quantity INT;
DECLARE @clientName VARCHAR(50);
DECLARE @clientAddress VARCHAR(100);
DECLARE @clientEmail VARCHAR(100);
DECLARE @clientPhoneNumber VARCHAR(20);

WHILE @i <= 100
BEGIN
    SET @number = 'INV' + CONVERT(VARCHAR(10), @i);
    SET @status = CASE WHEN @i % 2 = 0 THEN 'Paid' ELSE 'Pending' END;
    SET @issueDate = DATEADD(DAY, @i, '2022-01-01');
    SET @dueDate = DATEADD(DAY, @i + 30, '2022-01-01');
    SET @serviceName = 'Service ' + CONVERT(VARCHAR(10), @i);
    SET @unitPrice = @i * 100.00;
    SET @quantity = @i;
    SET @clientName = 'Client ' + CONVERT(VARCHAR(10), @i);
    SET @clientAddress = 'Address ' + CONVERT(VARCHAR(10), @i);
    SET @clientEmail = 'client' + CONVERT(VARCHAR(10), @i) + '@example.com';
    SET @clientPhoneNumber = '123-456-' + CONVERT(VARCHAR(10), @i);

    INSERT INTO [dbo].[Invoices] ([Number], [Status], [IssueData], [DueDate], [ServiceName], [UnitPrice], [Quantity], [ClientName], [ClientAddress], [ClientEmail], [ClientPhoneNumber])
    VALUES (@number, @status, @issueDate, @dueDate, @serviceName, @unitPrice, @quantity, @clientName, @clientAddress, @clientEmail, @clientPhoneNumber);

    SET @i = @i + 1;
END;