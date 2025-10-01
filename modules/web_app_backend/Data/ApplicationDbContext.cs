using BackendAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Data
{
    /// <summary>
    /// The Entity Framework Core DbContext. It exposes DbSet properties for each
    /// entity that needs to be persisted in SQL Server. EF Core uses this class
    /// to map C# classes to database tables.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Collection of users stored in the database. When EF Core runs, it will
        /// create a table called Users with columns based on the User model.
        /// </summary>
        public DbSet<User> Users => Set<User>();
    }
}