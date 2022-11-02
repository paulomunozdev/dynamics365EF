using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace D365.DOMAIN
{
    public class MigrationContext : IDesignTimeDbContextFactory<Contextdbazure>
    {
        public Contextdbazure CreateDbContext(string[] args)
        {
            var _sqlconectionString = ConfigurationManager.AppSettings["sqlConectionString"];
            var connection = _sqlconectionString;
            //var connection = "Data Source=tcp:server,1433;Initial Catalog=dbname;Persist Security Info=False;User ID=user;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
            //var connection = _sqlconectionString;
            var optionsBuilder = new DbContextOptionsBuilder<Contextdbazure>();
            optionsBuilder.UseSqlServer(connection, opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds));
            return new Contextdbazure(optionsBuilder.Options);
        }
    }
}
