using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameStore.DataAccess
{
    public static class Mapper
    {
        public static Library.StoreLocation Map(Entities.GameStore store) => new Library.StoreLocation
        {
            Id = store.StoreId,
            Name = store.Name,
            State = store.State
        };
        public static Entities.GameStore Map(Library.StoreLocation store) => new Entities.GameStore
        {
            StoreId = store.Id,
            Name = store.Name,
            State = store.State
        };

        public static Library.Customer Map(Entities.Customer customer) => new Library.Customer
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DefaultStore = Map(customer.DefaultStoreNavigation)
        };
        public static Entities.Customer Map(Library.Customer customer) => new Entities.Customer
        {
            CustomerId = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            DefaultStoreNavigation = Map(customer.DefaultStore)
        };


        public static IEnumerable<Library.StoreLocation> Map(IEnumerable<Entities.GameStore> stores)
        {
            return stores.Select(Map);
        }

        public static IEnumerable<Entities.GameStore> Map(IEnumerable<Library.StoreLocation> stores) =>
            stores.Select(Map);

        public static IEnumerable<Library.Customer> Map(IEnumerable<Entities.Customer> customers)
        {
            return customers.Select(Map);
        }

        public static IEnumerable<Entities.Customer> Map(IEnumerable<Library.Customer> customers) =>
            customers.Select(Map);

    }
}
