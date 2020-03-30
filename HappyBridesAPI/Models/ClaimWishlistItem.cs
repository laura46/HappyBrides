using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBridesAPI.Models
{
    public class ClaimWishlistItem : WishListItem
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public int ListID { get; set; }
    }
}
