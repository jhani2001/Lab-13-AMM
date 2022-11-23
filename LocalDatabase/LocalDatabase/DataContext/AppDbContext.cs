using LocalDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LocalDatabase.DataContext
{
    public class AppDbContext : AppDbContext
    {
        string DbPath = string.Empty;

        public AppDbContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albumes { get; set; }
        public object Database { get; internal set; }

        protected override void OnConfiguring(AppDbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");

        }
    }
}

