using System;
using System.Collections.Generic;
using System.Text;

namespace Lab53_CarLot
{
    class CarLot
    {
        private List<Car> cars;
        public int index;
        public List<Car> Cars { get => cars; set => cars = value; }
        public CarLot() { cars = new List<Car>(); }

        #region methods
        public void AddCar(Car c)
        {
            cars.Add(c);
        }


        public void RemoveCar(Car c)
        {
           cars.Remove(c);
        }


        public void ListCars(int index)
        {
            if (index < cars.Count && index >= 0)
            {
                for (int i = index; i < index + 7; i++)
                {
                    if (i < cars.Count)
                    {
                        Console.WriteLine(cars[i]);
                    }
                }
            }
        }
        #endregion methods
    }
}
