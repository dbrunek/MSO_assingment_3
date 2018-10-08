
namespace Lab3
{
    public class NormalTicket : Ticket
    {
        public bool Day;
        public bool Single = false;
        public bool International = false;
        public NormalTicket(string from, string to, int classes, bool today, bool single, bool international) : base(from, to, classes)
        {
            Day = today;
            Single = single;
            International = international;
        }
    }
}
