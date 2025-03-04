using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAMS_app
{
    public class VehicleBase
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }

        public VehicleBase(int id, string brand, string model, int year, int mileage)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Year = year;
            Mileage = mileage;
        }
    }
}
