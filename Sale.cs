using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    class Sale : Form
    {
        ComboBox payment;
        Button pay;
        float Price;
        public float DiscountPersentage;
        bool discount = false;
        public bool PaymentSuccesful = false;
        DCScanner ds;

        public Sale(float price)
        {
            Price = price;
        }

        void Buttons()
        {
            // Payment option
            var grid = new TableLayoutPanel();
            Label paymentLabel = new Label();
            paymentLabel.Text = "Payment by:";
            paymentLabel.Dock = DockStyle.Fill;
            paymentLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(paymentLabel, 0, 2);
            payment = new ComboBox();
            payment.DropDownStyle = ComboBoxStyle.DropDownList;
            payment.Items.AddRange(new string[] { "Credit card", "Debit card", "Cash" });
            payment.SelectedIndex = 0;
            payment.Dock = DockStyle.Fill;
            grid.Controls.Add(payment, 1, 2);
            grid.SetColumnSpan(payment, 5);

            // Pay button
            pay = new Button();
            pay.Text = "Pay";
            pay.Dock = DockStyle.Fill;
            grid.Controls.Add(pay, 0, 3);
            grid.SetColumnSpan(pay, 6);
        }

        void Payment()
        {
            if (!discount)// button.disountselected = true) 
            { 
                DiscountPersentage = ds.RetrieveCardData(ds.Scancard());
                Price = Price * (1 - DiscountPersentage);
            } 
        }
    }
}
