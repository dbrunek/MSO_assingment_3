using System;
using System.Windows.Forms;

namespace Lab3
{
    abstract class Printer
    {
        int numberofTickets;
        float Prijs;
        NormalTicket Ticket;
        public Printer(int nrTickets, NormalTicket ticket, float price)
        {
            numberofTickets = nrTickets;
            Ticket = ticket;
            Prijs = price;
        }
        public abstract void Print();
    }
    class Printer1 : Printer
    {
        int numberofTickets;
        NormalTicket Ticket;
        float Prijs;
        public Printer1(int nrTickets, NormalTicket ticket, float price) : base(nrTickets, ticket, price)
        {
            numberofTickets = nrTickets;
            Ticket = ticket;
            Prijs = price;
        }

        public override void Print()
        {
            for (int i = 0; i < numberofTickets; i++)
            {
                MessageBox.Show("Printing: ticket " + (i + 1) + " of " + numberofTickets + " ticket(s)\nClass: "
                    + Ticket.Class + "\nVan: " + Ticket.From + "\nNaar: " + Ticket.To + "\nSingle: " + Ticket.Single
                    + "\nToday: " + Ticket.Day + "\nInternational: " + Ticket.International + "\nPrice: € " + string.Format("{0:0.00}", Prijs));
            }
        }
    }
}
