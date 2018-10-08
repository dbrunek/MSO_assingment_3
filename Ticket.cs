
namespace Lab3
{
    public abstract class Ticket
    {
        public string From;
        public string To;
        public int Class;
        public Ticket(string from, string to, int classes)
        {
            From = from;
            To = to;
            Class = classes;
        }
    }
}
