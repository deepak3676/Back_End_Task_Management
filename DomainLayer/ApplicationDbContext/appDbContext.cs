using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ApplicationDbContext
{
    public class appDbContext:DbContext
    {
        public appDbContext(DbContextOptions<appDbContext> options) : base(options) { }
        public DbSet<taskStruct> taskTable { get; set; }
    }
}
