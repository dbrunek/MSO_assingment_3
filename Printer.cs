using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    abstract class Printer
    {
        int numberofTickets;
        Ticket Ticket;
        public Printer(int nrTickets, Ticket ticket)
        {
            numberofTickets = nrTickets;
            Ticket = ticket;
        }

        public virtual void Print(int nticket, Ticket tickets)
        {
            for (int i = 0; i < nticket; i++)
            {
                MessageBox.Show("Printing ticket " + i + " of " + nticket + " ticket(s)");
            }
        }
    }
}
