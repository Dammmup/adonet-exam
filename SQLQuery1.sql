select * from category
-- Добавление книги
CREATE PROCEDURE AddBook
    @Title NVARCHAR(255),
    @AuthorId INT,
    @CategoryId INT,
    @Pages INT,
    @Cost DECIMAL(18, 2)
AS
BEGIN
    INSERT INTO Book (Title, AuthorId, CategoryId, Pages, Cost)
    VALUES (@Title, @AuthorId, @CategoryId, @Pages, @Cost);
END;

-- Изменение книги
CREATE PROCEDURE UpdateBook
    @Id INT,
    @Title NVARCHAR(255),
    @AuthorId INT,
    @CategoryId INT,
    @Pages INT,
    @Cost DECIMAL(18, 2)
AS
BEGIN
    UPDATE Book
    SET Title = @Title,
        AuthorId = @AuthorId,
        CategoryId = @CategoryId,
        Pages = @Pages,
        Cost = @Cost
    WHERE Id = @Id;
END;


CREATE PROCEDURE DeleteBook
    @Id INT
AS
BEGIN
    DELETE FROM Book WHERE Id = @Id;
END;

-- Извлечение всех записей
CREATE PROCEDURE GetAllBooks
AS
BEGIN
    SELECT * FROM Book;
END;

-- Извлечение записи по Id
CREATE PROCEDURE GetBookById
    @Id INT
AS
BEGIN
    SELECT * FROM Book WHERE Id = @Id;
END;


CREATE PROCEDURE GetAuthorDetails
    @AuthorId INT,
    @TotalPages INT OUTPUT,
    @BookCount INT OUTPUT,
    @MostExpensiveBookTitle NVARCHAR(255) OUTPUT
AS
BEGIN
    SELECT @TotalPages = SUM(Pages),
           @BookCount = COUNT(*),
           @MostExpensiveBookTitle = MAX(Title)
    FROM Book
    WHERE AuthorId = @AuthorId;
    
    SELECT 
        A.LastName + ' ' + A.FirstName AS AuthorName,
        B.Title AS BookTitle,
        C.Name AS CategoryName
    FROM Author A
    JOIN Book B ON A.Id = B.AuthorId
    JOIN Category C ON B.CategoryId = C.Id
    WHERE A.Id = @AuthorId;
END;


