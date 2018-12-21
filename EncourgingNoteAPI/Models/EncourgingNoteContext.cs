using Microsoft.EntityFrameworkCore;

namespace EncourgingNoteAPI.Models
{
    public class EncourgingNoteContext : DbContext
    {
        public EncourgingNoteContext(DbContextOptions<EncourgingNoteContext> options)
            : base(options)
        {
        }

        public DbSet<EncourgingNoteItem> EncourgingNoteItems { get; set; }
    }
    
}
