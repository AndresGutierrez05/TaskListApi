using Microsoft.EntityFrameworkCore;

namespace BD
{
    public class ToDoListContext : DbContext
    {
        public ToDoListContext(DbContextOptions<ToDoListContext> options)
            : base(options)
        {
        }
        public DbSet<Tasks> Tasks { get; set; }
    }
}