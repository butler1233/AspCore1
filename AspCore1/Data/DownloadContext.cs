using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AspCore1.Models
{
    public class DownloadContext : DbContext
    {
        public DownloadContext (DbContextOptions<DownloadContext> options)
            : base(options)
        {
        }

        public DbSet<AspCore1.Models.Download> Download { get; set; }
    }
}
