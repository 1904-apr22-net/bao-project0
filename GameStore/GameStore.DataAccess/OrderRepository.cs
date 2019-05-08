using GameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameStore.DataAccess
{
    public class OrderRepository
    {
        private readonly GameStoreContext _dbContext;

        public OrderRepository(GameStoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public string GetCustomer(string firstName, string lastName)
        {
            var db = _dbContext;
            
            foreach (var name in db.Customer)
            {
                if (name.FirstName.ToUpper().Equals(firstName.ToUpper()) && name.LastName.ToUpper().Equals(lastName.ToUpper()))
                {
                    return firstName + " " +lastName;
                }
            }
            return null;
        }

        public int GetCustomerId(string firstName, string lastName)
        {
            var db = _dbContext;

            foreach (var name in db.Customer)
            {
                if (name.FirstName.ToUpper().Equals(firstName.ToUpper()) && name.LastName.ToUpper().Equals(lastName.ToUpper()))
                {
                    return name.CustomerId;
                }
            }
            return 0;
        }

        //public int getOrderId()
        //{
        //    var db = _dbContext;
        //    int orderId = db.GameOrder;
        //}
        public string GetStore(string name)
        {
            var db = new GameStoreContext();

            foreach (var n in db.GameStore)
            {
                if (n.Name == name)
                {
                    return name;
                }
            }
            return null;
        }

        public List<Game> GetGames()
        {
            var db = _dbContext;
            List<Game> games = db.Game.ToList();
            return games;
        }

        public void AddGameToOrder(int gameId)
        {

        }

        public int GetCustomerDefaultStoreId(int customerId)
        {
            var db = _dbContext;
            foreach (var id in db.Customer)
            {
                if (customerId == id.CustomerId)
                {
                    return (int)id.DefaultStore;
                }
            }
            return 0;
        }

        public void AddCustomerToOrder(int customerId)
        {
            var db = _dbContext;
            var storeId = GetCustomerDefaultStoreId(customerId);
            db.GameOrder.Add(new GameOrder { CustomerId = customerId, StoreId = storeId, OrderTime = DateTime.Now});
        }
    }
}
