using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Entities;

namespace Domain.DbContexts
{
    public class HairDresserDbContext : IdentityDbContext
    {
        public HairDresserDbContext(DbContextOptions<HairDresserDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}