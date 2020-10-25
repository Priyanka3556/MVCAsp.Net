using System;
using System.Security.Cryptography;
using System.Text;
namespace Core
{
    public class Helper
    {
        public bool ValidateSearchCriteria(string searchCriteria)
        {
            return !string.IsNullOrEmpty(searchCriteria) && searchCriteria.Length >= 2;
        }
        public string GenerateUnqiueItemId(int id, string key)
        {
            SHA256 hashstring = SHA256Managed.Create();

            byte[] hash =
                hashstring.ComputeHash(Encoding.UTF8.GetBytes(id + key));

            key = BitConverter.ToString(hash).Replace("-", "");
            return key;
        }
    }
}
