using Project_Advanced.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using Humanizer;

namespace Project_Advanced.Models
{
    public class SeedData
    {
       // provides access to the db context  for db connection and application’s dependency injection container
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
               
                if (context.Books.Any())
                {
                    return;
                }

              
                context.Books.AddRange(
                    new Book
                    {
                        Title = "Le Petit Prince",
                        Language = "French",
                        PublishYear = DateTime.Parse("2015-01-15"),
                        Description = "Un classique intemporel pour petits et grands.",
                        price = 120,
                        Pages = 96,
                        Author = "Antoine de Saint-Exupéry",
                        ImageUrl = "/images/book1.jpg"
                    },
                    new Book
                    {
                        Title = "To Kill a Mockingbird",
                        Language = "English",
                        PublishYear = DateTime.Parse("2010-05-23"),
                        Description = "A gripping and heartwarming tale.",
                        price = 150,
                        Pages = 320,
                        Author = "Harper Lee",
                        ImageUrl = "/images/book2.jpg"
                    },
                    new Book
                    {
                        Title = "Les Misérables",
                        Language = "French",
                        PublishYear = DateTime.Parse("2016-11-12"),
                        Description = "Un chef-d'œuvre de Victor Hugo.",
                        price = 180,
                        Pages = 1232,
                        Author = "Victor Hugo",
                        ImageUrl = "/images/book3.jpg"
                    },
                    new Book
                    {
                        Title = "موسم الهجرة إلى الشمال",
                        Language = "Arabic",
                        PublishYear = DateTime.Parse("2012-02-17"),
                        Description = "رواية من الأدب السوداني المعاصر.",
                        price = 90,
                        Pages = 224,
                        Author = "الطيب صالح",
                        ImageUrl = "/images/book4.jpg"
                    },
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        Language = "English",
                        PublishYear = DateTime.Parse("2014-03-14"),
                        Description = "One of Jane Austen's finest works.",
                        price = 130,
                        Pages = 279,
                        Author = "Jane Austen",
                        ImageUrl = "/images/book5.jpg"
                    },
                    new Book
                    {
                        Title = "L'Étranger",
                        Language = "French",
                        PublishYear = DateTime.Parse("2013-06-10"),
                        Description = "Un roman philosophique et existentialiste.",
                        price = 110,
                        Pages = 160,
                        Author = "Albert Camus",
                        ImageUrl = "/images/book6.jpg"
                    },
                    new Book
                    {
                        Title = "الأيام",
                        Language = "Arabic",
                        PublishYear = DateTime.Parse("2011-04-28"),
                        Description = "سيرة ذاتية لطه حسين.",
                        price = 80,
                        Pages = 300,
                        Author = "طه حسين",
                        ImageUrl = "/images/book7.jpg"
                    },
                    new Book
                    {
                        Title = "The Catcher in the Rye",
                        Language = "English",
                        PublishYear = DateTime.Parse("2017-09-12"),
                        Description = "A novel about teenage alienation.",
                        price = 145,
                        Pages = 277,
                        Author = "J.D. Salinger",
                        ImageUrl = "/images/book8.jpg"
                    },
                    new Book
                    {
                        Title = "La Peste",
                        Language = "French",
                        PublishYear = DateTime.Parse("2014-07-05"),
                        Description = "Un roman sur l'humanité face à l'adversité.",
                        price = 140,
                        Pages = 308,
                        Author = "Albert Camus",
                        ImageUrl = "/images/book9.jpg"
                    },
                    new Book
                    {
                        Title = "رجال في الشمس",
                        Language = "Arabic",
                        PublishYear = DateTime.Parse("2015-03-18"),
                        Description = "رواية فلسطينية تحكي عن حياة اللاجئين.",
                        price = 70,
                        Pages = 168,
                        Author = "غسان كنفاني",
                        ImageUrl = "/images/book10.jpg"
                    }
                );

                
                context.SaveChanges();
            }
        }
    }
}
