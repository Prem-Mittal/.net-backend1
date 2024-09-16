using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Data
{
    public class NZWalkAuthDBContext : IdentityDbContext //IdentityDbContext: This base class is part of ASP.NET Core Identity and includes DbSets for identity-related entities (Users, Roles, Claims, etc.).
    {
        public NZWalkAuthDBContext(DbContextOptions<NZWalkAuthDBContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "b221c6b2-b62c-4bd8-89f6-258bfac67195";
            var writerRoleId = " 72994283-f58b-442c-995c-bf4eb3509298";

            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                     Id= readerRoleId,
                    ConcurrencyStamp= readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                     Id= writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                },

            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
