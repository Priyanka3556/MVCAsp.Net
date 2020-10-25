using System;
using System.Collections.Generic;
using System.Linq;
using DataAccessLayer.Enums;
using Core;

namespace DataAccessLayer
{
    public class ProductsManager
    {
        private Helper helper = new Helper();
        private readonly TecsysRepository repo = new TecsysRepository();
        public List<Products> GetProducts(Category category)
        {
            return repo.GetProducts().Where(p=>p.CategoryID == (int)category).ToList();
        }
        public List<Products> SearchProducts(string criteria)
        {
            return repo.GetProducts().Where(p => p.ProductName.ToLower().Contains(criteria.ToLower())).ToList();
        }

        /// <summary>
        /// This method converts Products Ids sent from front end to database model.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public List<CartItems> ProcessCartItems(List<int> items)
        {
            Guid g = Guid.NewGuid();
            List <CartItems> cartItems =  new List<CartItems>();
            foreach (var item in items)
            {
                var cart = new CartItems
                {
                    CartId = g.ToString(),
                    DateCreated = DateTime.Now,
                    ProductId = item,
                    ItemId = helper.GenerateUnqiueItemId(item, g.ToString()),//we can generate unqiue Id as business required I am generating it for test purpose
                    Quantity = 1
                };
                //Default value can be added in table in database or A trigger can be added in database which will update this field 
                cartItems.Add(cart);
            }

            return cartItems;
        }
        public bool AddCartItems(List<CartItems> items)
        {
            try
            {
                using (var repo = new TecsysRepository())
                {
                    repo.AddCartItems(items);
                }
            }
            catch (Exception ex)
            {
                //Log Exception we can use log4net
                return false;
            }

            return true;
        }
        public bool ValidateSearchCriteria(string searchCriteria)
        {
            return helper.ValidateSearchCriteria(searchCriteria);
        }
    }
   
}
