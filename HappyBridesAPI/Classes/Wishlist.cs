using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyBridesAPI.Data;
using HappyBridesAPI.Models;

namespace HappyBridesAPI.Classes
{
    public class Wishlist : DBConnect
    {

        public Wishlist(){ }

        public int GetWishListIDByCoupleID(int coupleId) 
        {
            sql = "READ_RECORD_LISTID_BY_COUPLEID";
            parameters = new Dictionary<string, object> { {"@couple",coupleId } };
            var result = ExecuteReadSQLCommand();
            return (result.Count > 0) ? (int)result.First().GetValueOrDefault("WishListID") : 0;
        }
        public WishlistDetails<AddWishlistItem> GetWishlistDetailsForCouple(int coupleId) 
        {
            WishlistDetails<AddWishlistItem> wishlist = new WishlistDetails<AddWishlistItem>();
            sql = "READ_RECORD_LIST_COUPLE";
            parameters = new Dictionary<string, object> { {"@couple", coupleId} };
            List<Dictionary<string,object>> result = ExecuteReadSQLCommand();
            if (result.Count > 0) 
            {
                wishlist.FirstName = (string)result.First().GetValueOrDefault<string, object>("FirstName");
                wishlist.SecondName = (string)result.First().GetValueOrDefault<string, object>("SecondName");
                wishlist.WishListID = (int)result.First().GetValueOrDefault<string, object>("WishListID");
            }
            wishlist.WishlistItems = GetListItemsForCouple(wishlist.WishListID);
            return wishlist;
        }
        public List<AddWishlistItem> GetListItemsForCouple(int listID) 
        {
            sql = "READ_RECORD_LIST_ITEM_COUPLE";
            parameters = new Dictionary<string, object> { { "@list", listID } };
            var result = ExecuteReadSQLCommand();
            List<AddWishlistItem> wishlist = new List<AddWishlistItem>();
            if (result.Count > 0)
            {
                foreach (var item in result)
                {
                    AddWishlistItem listItem = new AddWishlistItem
                    {
                        Description = (string)item.GetValueOrDefault("Description"),
                        Price = (decimal)item.GetValueOrDefault("Price"),
                        Position = (int)item.GetValueOrDefault("Position")
                    };
                    wishlist.Add(listItem);
                }
            }
            return wishlist;
        }
        public List<GuestWishListItem> GetGuestWishListItems(int listID) 
        {
            sql = "READ_RECORD_LIST_ITEM_GUEST";
            parameters = new Dictionary<string, object> { { "@list", listID } };
            var result = ExecuteReadSQLCommand();
            if (result.Count > 0) 
            {
                List<GuestWishListItem> guestList = new List<GuestWishListItem>();
                foreach (var item in result)
                {
                    GuestWishListItem listItem = new GuestWishListItem
                    {
                        Description = (string)item.GetValueOrDefault("Description"),
                        Price = (decimal)item.GetValueOrDefault("Price"),
                        Position = (int)item.GetValueOrDefault("Position"),
                        IsClaimed = (item.GetValueOrDefault("IsClaimed") != DBNull.Value) ? (bool)item.GetValueOrDefault("IsClaimed") : false
                    };
                    if (!listItem.IsClaimed) { guestList.Add(listItem); }
                }
                return guestList;
            }
            return null;
        }
        public int GetListIDByUniqueCode(string uniqueCode)
        {
            sql = "READ_RECORD_LIST_CODE";
            parameters = new Dictionary<string, object> { { "@code", uniqueCode } };
            var result = ExecuteReadSQLCommand();
            return (result.Count != 0) ? (int)result.First().GetValueOrDefault("WishListID") : 0;
        }
        public WishlistDetails<GuestWishListItem> GetWishlistDetailsForGuest(int listID)
        {
            sql = "READ_RECORD_LIST_GUEST";
            parameters = new Dictionary<string, object> { {"@list", listID } };
            var result = ExecuteReadSQLCommand();
            if (result.Count > 0) 
            {
                WishlistDetails<GuestWishListItem> wishlist = new WishlistDetails<GuestWishListItem>
                {
                    WishListID = listID,
                    FirstName = (string)result.First().GetValueOrDefault("FirstName"),
                    SecondName = (string)result.First().GetValueOrDefault("SecondName")
                };
                wishlist.WishlistItems = GetGuestWishListItems(listID);
                return wishlist;
            }

            return null;
        }
        public string CreateWishlist(int coupleId, AccountCreation request)
        {
            string uniqueCode = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            sql = "CREATE_RECORD_LIST";
            parameters = new Dictionary<string, object> {
                {"@code", uniqueCode },
                {"@coupleId", coupleId },
                {"@name1", request.Name1 },
                {"@name2", request.Name2 }
            };
            ExecuteWriteSQLCommand();
            return uniqueCode;
        }
    }
}
