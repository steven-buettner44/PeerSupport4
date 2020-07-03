using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PeerSupport4.Models;

namespace PeerSupport4.Data
{
    public class PeerSupport4Context : DbContext
    {
        public PeerSupport4Context (DbContextOptions<PeerSupport4Context> options)
            : base(options)
        {
        }

        public DbSet<PeerSupport4.Models.Support> Support { get; set; }
    }
}
