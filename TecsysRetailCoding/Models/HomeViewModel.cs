using System.Collections.Generic;
using DataAccessLayer;

namespace TecsysRetailCoding.Models
{
    public class HomeViewModel
    {
        public List<Products> CarProducts { get; set; }
        public SearchProducts SearchProducts { get; set; }
    }
    public class SearchProducts
    {
        public List<Products> Products { get; set; }
        public bool IsSuccess { get; set; }
    }
}
