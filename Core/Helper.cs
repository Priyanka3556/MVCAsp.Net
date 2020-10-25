using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
            long ts =
                (long)
                (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds /
                1000;

            SHA256 hashstring = SHA256Managed.Create();

            byte[] hash =
                hashstring.ComputeHash(Encoding.UTF8.GetBytes(id + key + ts));

            key = BitConverter.ToString(hash).Replace("-", "");
            return key;
        }
    }
}
