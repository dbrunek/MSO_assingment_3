using System;
using System.Windows.Forms;

namespace Lab3
{
    abstract class DCScanner
    {
        public int pasnr;
        public float Discount;
        public DCScanner()
        {

        }
        public abstract int Scancard();
        public abstract float RetrieveCardData(int pasnr);

    }

    class DCScanner1 : DCScanner
    {
        Random r = new Random();
        public DCScanner1()
        {

        }

        public override int Scancard()
        {
            // random discount generator
            pasnr = r.Next(0, 10);
            return pasnr;           
        }

        public override float RetrieveCardData(int pasnr)
        {
            if (pasnr > 8)
            {
                Discount = 0.75f;
            }
            else if (pasnr > 5)
            {
                Discount = 0.5f;
            }
            else if (pasnr > 2)
            {
                Discount = 0.25f;
            }
            else Discount = 0f;
            MessageBox.Show("Card Number " + pasnr + "\nDiscount " + Discount * 100 + "%"); // kan dit?
            return Discount;
        }
    }
}
