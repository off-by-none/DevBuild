using System;
using System.Collections.Generic;
using System.Text;

namespace Lab53_CarLot
{
    class Car
    {
        #region fields
        private int id;
        private string make;
        private string model;
        private int year;
        private double price;
        private static int count = 100;
        #endregion  fields


        #region properties
        public int Id { get => id; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public double Price { get => price; set => price = value; }
        #endregion properties


        #region constructors
        public Car() 
        {
            this.id = count;
            this.make = null;
            this.model = null;
            this.year = 0;
            this.price = 0;
            count++;
        }

        public Car(string make, string model, int year, double price)
        {
            this.id = count;
            this.make = make;
            this.model = model;
            this.year = year;
            this.price = price;
            count++;
        }
        #endregion constructors


        #region methods
        public override string ToString()
        {
            return $"| {Id, -5} | {make, -18} | {model, -18} | {year, -18} | ${string.Format("{0:n2}", price),  10} {"|", 9} {"", -15} |";
        }
        #endregion methods
    }
}
