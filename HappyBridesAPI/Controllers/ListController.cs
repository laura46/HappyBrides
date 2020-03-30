using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyBridesAPI.Classes;
using HappyBridesAPI.Data;
using HappyBridesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HappyBridesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListController : ControllerBase
    {
        public DBConfiguration Config { get; set; }
        public Wishlist Wishlist { get; set; }
        public ListItem ListItem { get; set; }

        public ListController(DBConfiguration config) {
            new DBConfiguration(config);
            Wishlist = new Wishlist();
            ListItem = new ListItem();
        }
        [HttpGet("guest/{uniqueCode}")]
        public ActionResult<int> GetGuestListID(string uniqueCode) 
        {
            return Wishlist.GetListIDByUniqueCode(uniqueCode);
        }
        [HttpGet("guest/list/{listId}")]
        public ActionResult<WishlistDetails<GuestWishListItem>> GetGuestList(int listId)
        {
            return Wishlist.GetWishlistDetailsForGuest(listId);
        }
        [HttpGet("couple/{coupleId}")]
        public ActionResult<WishlistDetails<AddWishlistItem>> GetCoupleList(int coupleId)
        {
            return Wishlist.GetWishlistDetailsForCouple(coupleId);
        }

        [HttpPost("add")]
        public ActionResult<bool> AddNewListItem([FromBody] AddWishlistItem newItem)
        {
            return ListItem.AddNewItem(newItem);
        }
        [HttpPut("claim")]
        public ActionResult<bool> ClaimItem([FromBody] ClaimWishlistItem item) 
        {
            return ListItem.ClaimItem(item);
        }
        [HttpPut("edit")]
        public ActionResult<bool> EditListItem([FromBody] EditWishListItem item)
        {
            return ListItem.EditItem(item);
        }
        [HttpPut("up")]
        public ActionResult<bool> ChangePositionUp([FromBody] EditWishListItem item) 
        {
            return ListItem.MoveItem(true, item);
        }
        [HttpPut("down")]
        public ActionResult<bool> ChangePositionDown([FromBody] EditWishListItem item)
        {
            return ListItem.MoveItem(false, item);
        }
        [HttpDelete("{listId}/{position}")]
        public ActionResult<bool> Delete(int listId, int position)
        {
            return ListItem.DeleteItem(listId,position);
        }
    }
}
