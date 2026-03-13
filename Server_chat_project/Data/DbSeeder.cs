using Microsoft.EntityFrameworkCore;
using Server_chat_project.Models;
using System.Data;

namespace Server_chat_project.Data
{
    public class DbSeeder
    {
        public static async Task SeedAsync(AppDbContext _dbcontext)
        {
            await _dbcontext.Database.MigrateAsync();

            if (!_dbcontext.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { RoleName = "Admin" },
                    new Role { RoleName = "Developer" },
                    new Role { RoleName = "Manager" }
                };
                await _dbcontext.AddRangeAsync(roles);
                await _dbcontext.SaveChangesAsync();
            }
            //seed user

            if (!_dbcontext.Users.Any())
            {
                var admin = new User
                {
                    Username = "admin",
                    UserEmail = "admin@system.com"

                };
                await _dbcontext.AddAsync(admin);

                var adminRole = await _dbcontext.Roles.FirstOrDefaultAsync(role => role.RoleName == "Admin");

                var newRole = new UserRole
                {
                    User = admin,
                    Role = adminRole,
                };
                await _dbcontext.UserRoles.AddAsync(newRole);
                await _dbcontext.SaveChangesAsync();
            }
        }
    }
}