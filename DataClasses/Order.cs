using System.Collections.Generic;

namespace ServiceCenter.DataClasses
{
    public class Order
    {
        public int id;
        public float cost;
        public string address;
        public List<Service> services;

        public Order(int id, float cost, string address, List<Service> services)
        {
            this.id = id;
            this.cost = cost;
            this.address = address;
            this.services = services;
        }

        public Order()
        {

        }
    }
}
