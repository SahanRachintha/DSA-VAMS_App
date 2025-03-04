using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAMS_app
{
     public class Vehicle_Data : VehicleBase
    {
        public float Reserved_Price { get; set; }
        public List<BidNode> Bids { get; set; }

        public Vehicle_Data(int id, string brand, string model, int year, int mileage, float reserved_Price)
            : base(id, brand, model, year, mileage)
        {
            Reserved_Price = (float)(1.25 * reserved_Price);
            Bids = new List<BidNode>();
        }

        public void AddBid(string bidderName, int amount)
        {
            if (amount >= Reserved_Price)
            {
                Bids.Add(new BidNode(bidderName, amount));
                Console.WriteLine($"Bid of {amount} placed by {bidderName}");
            }
            else
            {
                Console.WriteLine($"Bid rejected! Exceed the bid above Reserved Price");
            }
        }

        public BidNode? HighestBid()
        {
            if (Bids.Count == 0) return null;
            return Bids.OrderByDescending(b => b.Amount).FirstOrDefault();
        }
    }

}
