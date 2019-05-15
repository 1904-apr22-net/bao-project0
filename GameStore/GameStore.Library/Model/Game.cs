using System;
using System.Collections.Generic;
using System.Text;

namespace GameStore.Library
{
    public class Game
    {
        private string _name;
        private double _price;

        public int GameId { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Name must not be empty.", nameof(value));
                }
                _name = value;
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Game must have a price.", nameof(value));
                }
                _price = value;
            }
        }
    }
}
