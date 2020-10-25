using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccessLayer
{
    //to kept the code simple I have'nt used database model and then some business dto seperate.
    public class TecsysRepository : IDisposable
    {
        //we can improve repo methods by writing our own customized method
        //which can help in logging userName and errors as well
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
