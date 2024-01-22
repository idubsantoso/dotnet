using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BookAuthor> BookAuthors => Set<BookAuthor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>().HasKey(m => new { m.BookId, m.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(m => m.Book)
                .WithMany(m => m.BookAuthors)
                .HasForeignKey(m=>m.BookId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(m => m.Author)
                .WithMany(m => m.BookAuthors)
                .HasForeignKey(m=>m.AuthorId);
        }
    }
}