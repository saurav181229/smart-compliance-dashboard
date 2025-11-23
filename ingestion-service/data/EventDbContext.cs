using ingestion_service.models;
using Microsoft.EntityFrameworkCore;


namespace ingestion_service.data
{
    public class EventDbContext: DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Events => Set<Event>();
    }
    
    
}