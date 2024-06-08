//using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.Core.Entities;

namespace web_api.Data
{



    public class DataContext : DbContext// : IDataContext
    {
        private readonly IConfiguration _configuration;

        //public List<Event> Events { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Branch> Branches { get; set; }

        public DataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
            //optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=chavi_library_db");
        }
    }
}
