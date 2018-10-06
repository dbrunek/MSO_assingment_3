using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public abstract class Ticket
    {
        public string From;
        public string To;
        public int Class;
        public float Price;
        public Ticket(string from, string to, int classes, float price)
        {
            From = from;
            To = to;
            Class = classes;
            Price = price;
        }
    }
}
