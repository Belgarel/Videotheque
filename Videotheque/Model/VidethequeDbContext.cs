using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    class VidethequeDbContext : DbContext
    {
        public string DatabasePath { get; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<GenreMedia> GenreMedias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }
//        protected override void OnModelCreating()


        private static VidethequeDbContext _context;
        public async Task<VidethequeDbContext> getInstance()
        {
            if (_context == null)
            {
                _context = new VidethequeDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }
        private VidethequeDbContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }
    }
}
