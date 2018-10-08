using System.Windows.Forms;

namespace Lab3
{
    class Printer
    {
        int numberofTickets;
        Ticket Ticket;
        public Printer(int nrTickets, Ticket ticket)
        {
            numberofTickets = nrTickets;
            Ticket = ticket;
        }

        public virtual void Print()
        {
            for (int i = 0; i < numberofTickets; i++)
            {
                MessageBox.Show("Printing ticket " + (i + 1) + " of " + numberofTickets + " ticket(s)");
            }
        }
    }
}
