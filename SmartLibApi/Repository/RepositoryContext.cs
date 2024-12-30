using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartLibApi.Models.Entity;
using SmartLibApi.Repository.Configuration;

namespace SmartLibApi.Repository;

public class RepositoryContext : IdentityDbContext<User>
{
    public RepositoryContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
        // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
        foreach (var entityType in modelBuilder.Model.GetEntityTypes()) {
            var tableName = entityType.GetTableName();
            if (tableName != null && tableName.StartsWith ("AspNet")) {
                entityType.SetTableName(tableName.Substring(6));
            }
        }
        
        modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        modelBuilder.ApplyConfiguration(new BookConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
    }

    public DbSet<Author>? Authors { get; set; }
    public DbSet<Book>? Books { get; set; }
    
    
}