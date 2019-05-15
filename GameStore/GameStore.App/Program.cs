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
                            //display all games
                            displayGames(orderRepository);
                            break;
                        }

                        Console.WriteLine("Name does not exist. Type 1 to continue or 2 to exit to main menu.");
                        string str = Console.ReadLine();
                        if (checkIfInteger(str))
                        {
                            int option = int.Parse(str);
                            //do
                            //{
                            //    if (option <= 0 || option > 2)
                            //    {
                            //        Console.WriteLine("Invalid input. Going back to main menu." + "\n");
                            //    }
                            //} while (option <= 0 || option > 2);
                            if (option.Equals(2))
                            {
                                break;
                            }
                        }
                    }
                }

                //search history
                //if (response == 2)
                //{
                    
                //}

                //exit
                else if (response == 2)
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

        //check if name exists
        static bool checkName(string firstName, string lastName, OrderRepository orderRepository)
        {
            var customerName = orderRepository.GetCustomer2(firstName, lastName);
            if (customerName.FirstName.Equals(firstName) && customerName.LastName.Equals(lastName))
            {
                return true;
            }
            return false;
        }

        //display list of games
        static void displayGames(OrderRepository orderRepository)
        {
            var games = orderRepository.GetGames();
            foreach (var game in games)
            {
                Console.WriteLine($"{game.GameId}: {game.Name}, ${game.Price}");
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
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input." + "\n");
                }
            } while (int.TryParse(response, out checkIfInt));
            
        }

        static bool checkIfInteger(string str)
        {
            int checkIfInt;
            return int.TryParse(str, out checkIfInt);
        }

        //static void addGamesToOrder()
        //{

        //}

        static int WhatDoesCustomerWantToDo()
        {
            int checkIfInt;
            string response;
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1: Make an order or 2: Exit");
                response = Console.ReadLine();

                //this will check if response is a number and if the number is numbers 1-3
                if (!int.TryParse(response, out checkIfInt) || int.Parse(response) <= 0 || int.Parse(response) > 2)
                {
                    Console.WriteLine($"{response} does not exist" + "\n");
                }
            } while ((!int.TryParse(response, out checkIfInt) || int.Parse(response) <= 0 || int.Parse(response) > 2));
            //same check. If it's not a number or a number from 1-3, ask for user to enter a response again
            Console.WriteLine();
            checkIfInt = int.Parse(response);
            return checkIfInt;
        }
    }
}
