using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DataAccessLayer
{
    public class TecsysRepository : IDisposable
    {
        protected DbContext DbContext;
        public List<Products> GetProducts( ){
            TecsysContext tecsysContext = new TecsysContext();
            return tecsysContext.Products.ToList();
        }
        public void AddCartItems(List<CartItems> items)
        {
            TecsysContext tecsysContext = new TecsysContext();
            tecsysContext.CartItems.AddRange(items);
            tecsysContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext?.Dispose();
            DbContext = null;
        }
    }
}
