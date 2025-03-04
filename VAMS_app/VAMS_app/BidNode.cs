using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAMS_app
{
    public class BidNode
    {
        public string BidName { get; set; }
        public int Amount { get; set; }
        public BidNode(string bidName, int amount)
        {
            BidName = bidName;
            Amount = amount;
        }
    }
}