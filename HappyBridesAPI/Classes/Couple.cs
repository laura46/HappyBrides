using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HappyBridesAPI.Data;
using HappyBridesAPI.Classes;

namespace HappyBridesAPI.Models
{
    public class Couple : DBConnect
    {
        public Wishlist CoupleList { get; set; }
        public Couple() { CoupleList = new Wishlist(); }
        public string RegisterNewCouple(AccountCreation request) 
        {
            int coupleID = CreateCouple(request);
            return CoupleList.CreateWishlist(coupleID, request);
        }
        private int CreateCouple(AccountCreation request) 
        {
            sql = "CREATE_RECORD_COUPLE";
            parameters = new Dictionary<string, object>
                {
                    { "@user", request.UserName },
                    { "@pass", request.Password }
                };

            return ExecuteWriteSQLCommand();
        }

        public int LoginCouple(LoginRequest loginRequest) 
        {
            sql = "READ_RECORD_COUPLE";
            parameters = new Dictionary<string, object> 
            {
                {"@user",loginRequest.UserName },
                {"@pass",loginRequest.PassWord }
            };
            List<Dictionary<string,object>> dbValues = ExecuteReadSQLCommand();
            if (dbValues.Count != 0 && dbValues.First().ContainsKey("CoupleID"))
            {
                return (int)dbValues.First().GetValueOrDefault<string, object>("CoupleID");
            }
            else {
                return 0;
            }
            //if (dbValues.Count > 0)
            //{
            //    int listId = (int)dbValues.First().GetValueOrDefault<string, object>("ListID");
            //    sql = "READ_RECORD_WISHLISTITEM";
            //    parameters = new Dictionary<string, object> { { "@listId", listId } };
            //    dbValues = ExecuteReadSQLCommand(sql, parameters);
            //    if (dbValues.Count > 0)
            //    {
            //        //cast to listitems and return
            //        return new List<WishlistItem>();
            //    }
            //    else
            //    {
            //        return new List<WishlistItem>();
            //    }
            //}
            //else 
            //{
            //    return false;
            //}
            //then retrieve all the items with the id and return it in a list


            //CRUD.ReadCouple(loginRequest.UserName, loginRequest.PassWord);
        }

        //public void CreateCouple(Couple newCouple, AccountCreation creationRequest)
        //{


        //    CreatePerson(createdID, creationRequest.Name1);
        //    CreatePerson(createdID, creationRequest.Name2);
        //}

        //public bool ReadCouple(string username, string password)
        //{
        //    string sql = "SELECT * FROM Couple WHERE UserName=@user AND PassWord=@pass";
        //    Dictionary<string, object> parameters = new Dictionary<string, object>
        //    {
        //        {"@user",username },
        //        {"@pass",password }
        //    };

        //    return (bool)DBConnection.ExecuteReadSQLCommand(sql, parameters);
        //}
    }
}
