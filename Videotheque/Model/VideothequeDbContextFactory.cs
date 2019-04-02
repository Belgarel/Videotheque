using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Videotheque.Model
{
    class VideothequeDbContextFactory : IDesignTimeDbContextFactory<VideothequeDbContext>
    {
        public VideothequeDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VideothequeDbContext>();
            optionsBuilder.UseSqlite("Date Source=database.db");

            return new VideothequeDbContext(optionsBuilder.Options);
        }
    }
}
