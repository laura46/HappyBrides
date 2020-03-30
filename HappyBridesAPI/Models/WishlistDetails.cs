using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBridesAPI.Models
{
    public class WishlistDetails<T>
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int WishListID { get; set; }
        public List<T> WishlistItems { get; set; }
    }
}
