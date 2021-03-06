﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotheque.Model
{
    class VideothequeDbContext : DbContext
    {
        public string DatabasePath { get; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<GenreMedia> GenreMedias { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonMedia> PersonMedias { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GenreMedia>().HasKey(gm => new {gm.MediaId, gm.GenreId});
        }


        internal VideothequeDbContext(DbContextOptions options) : base(options) { }
        private static VideothequeDbContext _context;
        public static async Task<VideothequeDbContext> getInstance()
        {
            if (_context == null)
            {
                _context = new VideothequeDbContext(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }
        private VideothequeDbContext(string databasePath) : base()
        {
            DatabasePath = databasePath;
        }
    }
}
