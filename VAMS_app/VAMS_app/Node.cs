using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAMS_app
{
    public class Node
    {
        public Vehicle_Data CarData { get; set; }
        public Node Next { get; set; }

        public Node(Vehicle_Data carData)
        {
            CarData = carData;
            Next = null;
        }
    }
}

