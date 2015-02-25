using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDM.Models
{
    class DataBase : DbContext
    {
        public DataBase() : base("DataBase") { }
        
        public DbSet<User> Users { get; set; }
    }
}
