using Microsoft.EntityFrameworkCore;

namespace Server_chat_project.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


    }
}
