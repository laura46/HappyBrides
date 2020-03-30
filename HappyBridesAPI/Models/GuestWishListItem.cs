using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBridesAPI.Models
{
    public class GuestWishListItem : WishListItem
    {
        public bool IsClaimed { get; set; }
    }
}
