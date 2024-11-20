
using Microsoft.AspNetCore.Identity;
using KoiFishManager.Api.Entities;
using Task = System.Threading.Tasks.Task;

namespace KoiFishManager.Api.Data
{
    public class KoiFishManagerDbContextSeed
    {
        private readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public async Task SeedAsync(KoiFishManagerDbContext context, ILogger<KoiFishManagerDbContextSeed> logger)
        {
            if (!context.Users.Any())
            {
                var user = new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Mr",
                    LastName = "A",
                    Email = "admin1@gmail.com",
                    NormalizedEmail = "ADMIN1@GMAIL.COM",
                    PhoneNumber = "032132131",
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                user.PasswordHash = _passwordHasher.HashPassword(user, "Admin@123$");
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
