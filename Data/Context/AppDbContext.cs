﻿using Architecture.Domain.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
   public class AppDbContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public override int SaveChanges()
        {
            AddAuitInfo();
            return base.SaveChanges();
        }
        public async Task<int> SaveChangesAsync()
        {
            AddAuitInfo();
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        private void AddAuitInfo()
        {
            var entries = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).Created = DateTime.UtcNow;
                }
                ((BaseEntity)entry.Entity).Modified = DateTime.UtcNow;
            }
        }
        internal  bool IsTracked<T>(T key) where T:BaseEntity
        {
                return this.Set<T>().Local.Any(x => x.Id == key.Id);
        }
    }
}
