using Microsoft.EntityFrameworkCore;

namespace MusicTracks.Models
{
    public class MusicTracksContext : DbContext
    {
        public MusicTracksContext (DbContextOptions<MusicTracksContext> options)
            : base(options)
        {
        }

        public DbSet<MusicTrack> MusicTrack { get; set; }
    }
}