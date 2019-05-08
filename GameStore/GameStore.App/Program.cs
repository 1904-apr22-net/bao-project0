using GameStore.DataAccess;
using GameStore.DataAccess.Entities;
using GameStore.Library;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.App
{
    public static class Program
    {
        //private static readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {

            RunUI();
        }

        public static void RunUI()
        {
            OrderRepository orderRepository = Dependencies.CreateRestaurantRepository();
            var locations = orderRepository.GetCustomer("John", "Smith");

            Console.WriteLine(locations);

            

            while (true)
            {
                int response = WhatDoesCustomerWantToDo();
                //make an order
                //display list of games and choose games in a loop until user typed "done"
                //add game to order
                //display order and ask to confirm
                //if no, continue adding games
                //if yes, add order to db
                if (response == 1)
                {
                    while(true)
                    {
                        Console.WriteLine("Enter first name:");
                        var firstName = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        var lastName = Console.ReadLine();
                        Console.WriteLine();

                        //check if customer exist in db
                        //if not, ask again
                        if (checkName(firstName, lastName, orderRepository))
                        {
                            addCustomerToOrder(firstName,lastName, orderRepository);
                            Console.WriteLine("\n" + "Here is a list of games:");
                            displayGames(orderRepository);
                            break;
                        }

                        Console.WriteLine("Name does not exist. Type 1 to continue or 2 to exit to main menu.");
                        string str = Console.ReadLine();
                        if (checkIfInteger(str))
                        {
                            if (int.Parse(str).Equals(2))
                            {
                                break;
                            }
                        }
                    }
                }

                //search history
                if (response == 2)
                {
                    
                }

                //exit
                else if (response == 3)
                {
                    Console.WriteLine("Exiting application. Thank you.");
                    break;
                }
            }
        }

        static void addCustomerToOrder(string firstName, string lastName, OrderRepository orderRepository)
        {
            int customerId = orderRepository.GetCustomerId(firstName, lastName);
            orderRepository.AddCustomerToOrder(customerId);
        }
        static bool checkName(string firstName, string lastName, OrderRepository orderRepository)
        {
            string fullName = firstName + " " + lastName;
            if (orderRepository.GetCustomer(firstName, lastName) == fullName)
            {
                return true;
            }
            return false;
        }
        static void displayGames(OrderRepository orderRepository)
        {
            var games = orderRepository.GetGames();
            foreach (var game in games)
            {
                Console.WriteLine($"{game.GameId}: {game.Name}");
            }
            int checkIfInt;
            string response;
            do
            {
                Console.WriteLine("\n" + "Enter Number next to game to add to order: " + "\n");
                response = Console.ReadLine();
                if (int.TryParse(response, out checkIfInt))
                {
                    //checkIfInt becomes gameId
                    checkIfInt = int.Parse(response);
                }
            } while (int.TryParse(response, out checkIfInt));
            
        }

        static bool checkIfInteger(string str)
        {
            int checkIfInt;
            return int.TryParse(str, out checkIfInt);
        }

        static void addGamesToOrder()
        {

        }

        static int WhatDoesCustomerWantToDo()
        {
            int checkIfInt;
            string response;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Make an order, 2: Search history, or 3: Exit");
                response = Console.ReadLine();

                //this will check if response is a number and if the number is numbers 1-3
                if (!int.TryParse(response, out checkIfInt) || int.Parse(response) <= 0 || int.Parse(response) > 3)
                {
                    Console.WriteLine($"{response} does not exist" + "\n");
                }
            } while ((!int.TryParse(response, out checkIfInt) || int.Parse(response) <= 0 || int.Parse(response) > 3));
            //same check. If it's not a number or a number from 1-3, ask for user to enter a response again
            Console.WriteLine();
            checkIfInt = int.Parse(response);
            return checkIfInt;
        }
    }
}
