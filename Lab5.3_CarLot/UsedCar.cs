using System;
using System.Collections.Generic;
using System.Text;

namespace Lab53_CarLot
{
    class UsedCar : Car
    {
        #region fields
        private double mileage;
        #endregion fields


        #region constructors
        public UsedCar() {}

        public UsedCar(string make, string model, int year, double price, double mileage)
            : base (make, model, year, price)
        {
            this.mileage = mileage;
        }
        #endregion constructors


        #region methods
        public override string ToString()
        {
            return $"| {base.Id, -5} | {base.Make, -18} | {base.Model, -18} | {base.Year, -18} | ${string.Format("{0:n2}", base.Price), 10} {"|", 9} {string.Format("{0:n0}", mileage), 7} {"(used) |", 9}";
        }
        #endregion methods
    }
}
