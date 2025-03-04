using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VAMS_app
{
    public class CarLinkedList
    {
        private Node? head;
        private Node? tail;
        private int currentId;

        public CarLinkedList()
        {
            head = null;
            tail = null;
            currentId = 1;
        }

        public void Insert(string brand, string model, int year, int mileage, int reserved_Price)
        {
            Vehicle_Data newCar = new Vehicle_Data(currentId, brand, model, year, mileage, reserved_Price);
            Node newNode = new Node(newCar);


            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail!.Next = newNode;
                tail = newNode;
            }
            currentId++;
        }

        public CarLinkedList Clone()
        {
            CarLinkedList copy = new CarLinkedList();
            Node temp = head;
            while (temp != null)
            {
                copy.Insert(temp.CarData.Brand, temp.CarData.Model, temp.CarData.Year, temp.CarData.Mileage, temp.CarData.Reserved_Price);
                temp = temp.Next;
            }
            return copy;
        }

      


        public void SortByPrice()
        {
            if (head == null) return;
            head = MergeSort(head);
        }

        private Node MergeSort(Node head)
        {
            if (head == null || head.Next == null)
                return head!;

            Node middle = GetMiddle(head);
            Node nextOfMiddle = middle.Next;
            middle.Next = null;

            Node left = MergeSort(head);
            Node right = MergeSort(nextOfMiddle);

            return Merge(left, right);
        }

        private Node Merge(Node left, Node right)
        {
            if (left == null) return right;
            if (right == null) return left;

            Node result;

            if (left.CarData.Reserved_Price <= right.CarData.Reserved_Price)
            {
                result = left;
                result.Next = Merge(left.Next, right);
            }
            else
            {
                result = right;
                result.Next = Merge(left, right.Next);
            }

            return result;
        }

        private Node GetMiddle(Node head)
        {
            if (head == null) return head;

            Node slow = head, fast = head.Next;
            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            return slow;
        }
        public bool Delete(int id)
        {
            if (head == null)
                return false;

            if (head.CarData.Id == id)
            {
                head = head.Next;
                if (head == null)
                {
                    tail = null;
                }
                return true;
            }

            Node temp = head;
            while (temp.Next != null && temp.Next.CarData.Id != id)
            {
                temp = temp.Next;
            }

            if (temp.Next == null)
                return false;

            if (temp.Next == tail)
            {
                tail = temp;
            }

            temp.Next = temp.Next.Next;
            return true;
        }

        public Vehicle_Data Find(int id)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.CarData.Id == id)
                    return temp.CarData;

                temp = temp.Next;
            }
            return null;
        }
        public List<Vehicle_Data> Findlist(string brand, string model)
        {
            List<Vehicle_Data> Vehicles = new List<Vehicle_Data>();
            Node? temp = head;

            while (temp != null)
            {
                if (temp.CarData.Brand.ToLower() == brand.ToLower() && temp.CarData.Model.ToLower() == model.ToLower())
                {
                    Vehicles.Add(temp.CarData);
                }
                temp = temp.Next;
            }
            return Vehicles;
        }

        //Quick sort


        public void SortByBrandAndModel()
        {
            head = QuickSort(head, GetTail(head));
        }

        private Node QuickSort(Node head, Node tail)
        {
            if (head == null || head == tail)
                return head;

            Node newHead = null, newTail = null;
            Node pivot = Partition(head, tail, ref newHead, ref newTail);

            if (newHead != pivot)
            {
                Node temp = newHead;
                while (temp.Next != pivot)
                {
                    temp = temp.Next;
                }
                temp.Next = null;
                newHead = QuickSort(newHead, temp);
                temp = GetTail(newHead);
                temp.Next = pivot;
            }

            pivot.Next = QuickSort(pivot.Next, newTail);
            return newHead;
        }

        private Node Partition(Node head, Node tail, ref Node newHead, ref Node newTail)
        {
            Node pivot = tail, prev = null, current = head, tailNode = pivot;
            while (current != pivot)
            {
                if (string.Compare(current.CarData.Brand + current.CarData.Model, pivot.CarData.Brand + pivot.CarData.Model, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    if (newHead == null)
                        newHead = current;
                    prev = current;
                    current = current.Next;
                }
                else
                {
                    if (prev != null)
                        prev.Next = current.Next;
                    Node temp = current.Next;
                    current.Next = null;
                    tailNode.Next = current;
                    tailNode = current;
                    current = temp;
                }
            }
            if (newHead == null)
                newHead = pivot;
            newTail = tailNode;
            return pivot;
        }

        private Node GetTail(Node head)
        {
            while (head != null && head.Next != null)
                head = head.Next;
            return head;
        }

        public void DisplaySortedByBrandAndModel()
        {
            CarLinkedList sortedList = Clone(); 
            sortedList.SortByBrandAndModel();

            Console.WriteLine("----Sorted Vehicle List (By Brand and Model - Alphabetical Order)----");
            Node temp = sortedList.head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.CarData.Id}. {temp.CarData.Brand} {temp.CarData.Model} ({temp.CarData.Year}) - ${temp.CarData.Reserved_Price}");
                temp = temp.Next;
            }
        }



        //insertion sort

        public void SortByYear()
        {
            if (head == null || head.Next == null)
                return; 

            Node sorted = null;
            Node current = head;

            while (current != null)
            {
                Node next = current.Next;
                sorted = SortedInsert(sorted, current);
                current = next;
            }

            head = sorted; 
        }

        private Node SortedInsert(Node sorted, Node newNode)
        {
            if (sorted == null || sorted.CarData.Year > newNode.CarData.Year)
            {
                newNode.Next = sorted;
                return newNode;
            }

            Node current = sorted;
            while (current.Next != null && current.Next.CarData.Year < newNode.CarData.Year)
            {
                current = current.Next;
            }

            newNode.Next = current.Next;
            current.Next = newNode;

            return sorted;
        }

        public void DisplaySortedByYear()
        {

            CarLinkedList sortedList = Clone(); 
            sortedList.SortByYear();

            Console.WriteLine("----Sorted Vehicle List (By Year - Ascending)----");
            Node temp = sortedList.head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.CarData.Id}. {temp.CarData.Brand} {temp.CarData.Model} ({temp.CarData.Year}) - ${temp.CarData.Reserved_Price} - {temp.CarData.Mileage}km");
                temp = temp.Next;
            }
        }




        public void Find()
        {
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine() ?? "";

            Console.Write("Enter Model: ");
            string model = Console.ReadLine() ?? "";

            List<Vehicle_Data> matchingVehicles = Findlist(brand, model);

            if (matchingVehicles.Count == 0)
            {
                Console.WriteLine("No vehicles found");
                return;
            }

            Console.WriteLine("\nRelated Vehicles:");
            foreach (var vehicle in matchingVehicles)
            {
                Console.WriteLine($"ID: {vehicle.Id} | {vehicle.Brand} {vehicle.Model} ({vehicle.Year}) - {vehicle.Reserved_Price}");
            }

            Console.Write("\nEnter the ID of the vehicle for more details: ");
            int select_id = Convert.ToInt32(Console.ReadLine());
            if (0 < select_id && select_id <= currentId)
            {
                foreach (var vehicle in matchingVehicles)
                {
                    if (select_id == vehicle.Id)
                    {
                        Console.WriteLine($"\n{vehicle.Brand} {vehicle.Model} ({vehicle.Year})\n" +
                                          $"Vehicle ID  : {vehicle.Id}\n" +
                                          $"Min Price   : ${vehicle.Reserved_Price}\n" +
                                          $"Mileage(km) : {vehicle.Mileage} km\n" 
                                          );
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid ID!!!");
            }

        }

        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("No cars in the list.");
                return;
            }

            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.CarData.Id} {temp.CarData.Brand} {temp.CarData.Model} ({temp.CarData.Year}) - ${temp.CarData.Reserved_Price}");
                temp = temp.Next;
            }
        }
        public void PlaceBid(int id, string bidderName, int bidamount)
        {
            Vehicle_Data Car = Find(id);
            if (Car != null)
            {
                Car.AddBid(bidderName, bidamount);

            }
            else
            {
                Console.WriteLine("Vehicle not found");
            }
        }
        public void Auction(int id)
        {
            Vehicle_Data Vehicle = Find(id);
            if (Vehicle != null)
            {
                if (Vehicle.Bids.Count == 0)
                {
                    Console.WriteLine("No bids placed for this Vehicle!!!");
                }
                else
                {
                    BidNode? Highest_Bid = Vehicle.HighestBid();
                    Console.WriteLine($"Vehicle is sold to highest bidder : {Highest_Bid.BidName}");
                    Delete(id);
                }
            }
            else
            {
                Console.WriteLine("Vehicle is sold or Invalid Id!!!");
            }

        }
    }
}





