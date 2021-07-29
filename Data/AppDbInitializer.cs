using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Models;
using System;
using System.Linq;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            var serviceScope = app.ApplicationServices.CreateScope();

            using (serviceScope) 
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                // Authors seed
                if (!context.Authors.Any())
                {
                    var author1 = new Author()
                    {
                        FullName = "1st Author's name"
                    };

                    var author2 = new Author()
                    {
                        FullName = "2nd Author's name"
                    };

                    context.Authors.AddRange(author1, author2);
                    context.SaveChanges();
                }
                
                // Publishers seed
                if (!context.Publishers.Any())
                {
                    var publisher1 = new Publisher()
                    {
                        Name = "1st Publisher's name"
                    };
                    
                    var publisher2 = new Publisher()
                    {
                        Name = "2nd Publisher's name"
                    };

                    context.Publishers.AddRange(publisher1, publisher2);
                    context.SaveChanges();
                }

                // Books seed
                if (!context.Books.Any())
                {
                    var book1 = new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                        PublisherId = 1
                    };
                    
                    var book2 = new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        IsRead = false,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https...",
                        DateAdded = DateTime.Now,
                        PublisherId = 2
                    };
                    
                    context.Books.AddRange(book1, book2);
                    context.SaveChanges();
                }
            }
        }
    }
}
