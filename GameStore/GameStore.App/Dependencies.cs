using GameStore.DataAccess;
using GameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.App
{
    public static class Dependencies
    {
        public static OrderRepository CreateRestaurantRepository()
        {
            var optionsBuilder = new DbContextOptionsBuilder<GameStoreContext>();
            optionsBuilder.UseSqlServer(SecretConfiguration.ConnectionString);

            var dbContext = new GameStoreContext(optionsBuilder.Options);

            return new OrderRepository(dbContext);
        }
    }
}
