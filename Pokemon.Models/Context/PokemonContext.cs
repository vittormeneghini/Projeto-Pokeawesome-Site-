using Microsoft.EntityFrameworkCore;
using Pokemon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokemon.Models.Context
{
    public class PokemonContext : DbContext
    {
        public PokemonContext()
        {
            #if DEBUG
                DbConnection = "devpokeawesomedb";
            #else
                DbConnection = "pokeawesomedb";
            #endif
        }

        //Db connection
        private string DbConnection { get; }


        public DbSet<Account> Account { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<ErrorEmail> ErrorEmail { get; set; }
        public DbSet<PlayerItems> PlayerItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql($"Server=31.220.57.45;Database={DbConnection};Uid=awesomedeveloper;Password=awesomedev@2000");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerItems>()
                .HasKey(c => new { c.Player_Id, c.Sid });
                
        }
    }
}
