using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBridesAPI.Models
{
    public class WishListItem
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Position { get; set; }
    }
}
