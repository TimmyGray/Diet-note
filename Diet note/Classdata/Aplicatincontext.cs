using System;
using System.Collections.Generic;
using Microsoft.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Diet_note
{
    
      partial class Aplicatincontext : DbContext
    {  
        public Aplicatincontext()
        {
           
           Database.EnsureCreated();
        }
       public DbSet<User> Users { get; set; }
       public DbSet<Edgeelements> Edges { get; set; }
       public DbSet<Energoelements> Elements { get; set; }
       public DbSet<History> Histories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"DietDB.sqlite")}");
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<History>()
                 .HasOne(s => s.user)
                 .WithMany(m => m.Histories)
                 .HasForeignKey(s => s.UserId);
            modelBuilder.Entity<Edgeelements>()
                .HasOne(s => s.user)
                .WithOne(m => m.Edges);
                
            //modelBuilder.Entity<User>()
            //    .HasOne(m => m.Edges)
            //    .WithOne(m => m.user);
                
                

        }


    }

}
