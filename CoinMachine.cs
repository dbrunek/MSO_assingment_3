using System;
using System.Windows.Forms;

namespace Lab3
{
	public class IKEAMyntAtare2000
	{
		public void starta()
		{
			MessageBox.Show ("Welcome at the payment machine");
		}

		public bool stoppa(bool X)
		{			
            if (!X)
            {
                MessageBox.Show("Something went wrong \nYOU lost your money!! :-)");
                return false;
            }
            MessageBox.Show("Payment Succesful");
            return true;
        }

        public void betala(float pris)
        {
            MessageBox.Show("€ " + string.Format("{0:0.00}", pris));
        }
    }
}

