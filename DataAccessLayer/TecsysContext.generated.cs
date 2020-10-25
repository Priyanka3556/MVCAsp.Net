using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class TecsysContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
    }
}
