using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using D365.MODEL.Entities;
using D365.DOMAIN.Entities;

namespace D365.DOMAIN
{
    public class Contextdbazure : DbContext
    {
        private readonly string _connection;
        private readonly string _sqlconectionString;

        public Contextdbazure()
        {
            _sqlconectionString = ConfigurationManager.AppSettings["sqlConectionString"];
            this._connection = _sqlconectionString;
        }

        public Contextdbazure(string connection)
        {
            this._connection = connection;
        }
        public Contextdbazure(DbContextOptions<Contextdbazure> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection = this._connection;
            if (!optionsBuilder.IsConfigured)
            {
                var migrationsAssembly = typeof(Contextdbazure).GetTypeInfo().Assembly.GetName().Name;

                //optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings[""].ConnectionString, options =>
                //{
                //    options.UseRowNumberForPaging();
                //    options.MigrationsAssembly(migrationsAssembly);
                //});
                optionsBuilder.UseSqlServer(connection, options =>
                {
                    options.UseRowNumberForPaging();
                    options.MigrationsAssembly(migrationsAssembly);
                });

                optionsBuilder.EnableSensitiveDataLogging(true);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreationDateUTC).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModificationDateUTC).HasDefaultValueSql("(getutcdate())");
                // relaciones M:1
                // relaciones 1:1
                // relaciones M:1

            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreationDateUTC).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModificationDateUTC).HasDefaultValueSql("(getutcdate())");
                // relaciones M:1
                // relaciones 1:1
                // relaciones M:1

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CreationDateUTC).IsUnicode(false);
                entity.Property(e => e.ModificationDateUTC).HasDefaultValueSql("(getutcdate())");
            });

        }
    }
}
