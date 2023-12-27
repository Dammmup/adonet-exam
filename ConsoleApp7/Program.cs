using ConsoleApp7;
using Microsoft.EntityFrameworkCore;
using System;

class Program
{
    static void Main()
    {
        using (var context = new YourDbContext())
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var author = new Author { LastName = "Тестовый автор Фамилия", FirstName = "Тестовый автор Имя" };
                    var category = new Category { Name = "Тестовая категория" };
                    var book = new Book
                    {
                        Title = "Sample Book",
                        Author = author,  // Используем свойство навигации
                        Category = category,  // Используем свойство навигации
                        Pages = 300,
                        Cost = 19.99m
                    };

                    context.Book.Add(book);
                    context.SaveChanges();

                    // 4.3: Добавление книг с транзакцией
                    var book1 = new Book { Title = "Словарь", Author = author, Category = category, Pages = 200, Cost = 15000.00m };
                    var book2 = new Book { Title = "Книга рецептов", Author = author, Category = category, Pages = 1200, Cost = 12000.00m };
                    var book3 = new Book { Title = "Уголовный кодекс РК", Author = author, Category = category, Pages = 500000, Cost = 20000.00m };

                    context.Book.AddRange(book1, book2, book3);
                    context.SaveChanges();

                    transaction.Commit();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine("DbUpdateException: " + ex.Message);

                    // Если есть внутреннее исключение, выведите его сообщение
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine("Inner Exception: " + ex.InnerException.Message);
                    }

                    // Откатываем транзакцию в случае ошибки
                    transaction.Rollback();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);

                    // Откатываем транзакцию в случае ошибки
                    transaction.Rollback();
                }
            }
        }
    }
}
