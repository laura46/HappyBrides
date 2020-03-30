using HappyBridesAPI.Data;
using HappyBridesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBridesAPI.Classes
{
    public class ListItem : Wishlist
    {
        public ListItem() {}

        public bool ClaimItem(ClaimWishlistItem item) {
            sql = "CREATE_RECORD_CONTRIBUTOR";
            parameters = new Dictionary<string, object>
            {
                {"@name", item.Name },
                {"@mess", item.Message }
            };
            int contributorID = ExecuteWriteSQLCommand();

            sql = "UPDATE_RECORD_LIST_ITEM_CLAIM";
            parameters = new Dictionary<string, object> 
            {
                {"@desc", item.Description },
                {"@pos", item.Position },
                {"@con", contributorID },
                {"@list", item.ListID }
            };

            int updated = ExecuteWriteSQLCommand();
            return (updated != 0) ? true : false;
        }
        public bool MoveItem(bool up, EditWishListItem item) 
        {
            List<AddWishlistItem> items = GetListItemsForCouple(item.ListID);

            foreach (var listItem in items)
            {

                int newPosition = (up) ? item.Position - 1 : item.Position + 1;
                int position;
                if (listItem.Position == newPosition || listItem.Position == item.Position)
                {
                    if (listItem.Position == newPosition) {
                        position = (up) ? listItem.Position + 1 : listItem.Position - 1;
                    } else {
                        position = newPosition;
                    }

                    sql = "UPDATE_RECORD_LISTITEM_ORDER";
                    parameters = new Dictionary<string, object>
                    {
                        {"@desc", listItem.Description },
                        {"@price", listItem.Price },
                        {"@pos", position },
                        {"@list", item.ListID }
                    };
                    ExecuteWriteSQLCommand();
                }
            }
            return true;
        }
        public bool DeleteItem(int listId, int position)
        {
            sql = "DELETE_RECORD_LISTITEM";
            parameters = new Dictionary<string, object>
            {
                {"@list", listId },
                {"@pos", position }
            };
            ExecuteWriteSQLCommand();
            return true;
        }

        public bool EditItem(EditWishListItem item)
        {
            sql = "UPDATE_RECORD_LISTITEM";
            parameters = new Dictionary<string, object> {
                {"@desc", item.Description },
                {"@price", item.Price },
                {"@pos", item.Position },
                {"@list", item.ListID }
            };
            ExecuteWriteSQLCommand();
            return true;
        }

        public bool AddNewItem(AddWishlistItem item)
        {
            int listId = GetWishListIDByCoupleID(item.CoupleID);
            sql = "CREATE_RECORD_LISTITEM";
            parameters = new Dictionary<string, object> {
                {"@desc", item.Description },
                {"@price", item.Price },
                {"@pos", item.Position },
                {"@list", listId }
            };
            ExecuteWriteSQLCommand();
            return true;
        }
    }
}
