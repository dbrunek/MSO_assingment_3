using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    class Sale : Form
    {
        ComboBox payment;
        Button pay;
        Button DCCard;
        float Price;
        public float DiscountPersentage;
        bool discount = false;
        public bool PaymentSuccesful = false;
        DCScanner ds;

        public Sale(float price)
        {
            Price = price;
            Buttons();
        }

        void Buttons()
        {
            Text = "Select Payment Method";
            // this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Width = 500;
            Height = 210;
            // Set layout
            var grid = new TableLayoutPanel();
            grid.Dock = DockStyle.Fill;
            grid.Padding = new Padding(4);
            Controls.Add(grid);
            grid.RowCount = 2;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            grid.ColumnCount = 2;
            for (int i = 0; i < 2; i++)
            {
                ColumnStyle c = new ColumnStyle(SizeType.Percent, 36.0f);
                grid.ColumnStyles.Add(c);
            }

            // Pay button
            DCCard = new Button();
            DCCard.Text = "Scan Discount Card";
            DCCard.Dock = DockStyle.Fill;
            grid.Controls.Add(DCCard, 0, 2);
            grid.SetColumnSpan(DCCard, 1);
            DCCard.Click += (object sender, EventArgs e) => SCanCard();

            // Payment option
            Label paymentLabel = new Label();
            paymentLabel.Text = "Payment by:";
            paymentLabel.Dock = DockStyle.Fill;
            paymentLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(paymentLabel, 0, 1);
            payment = new ComboBox();
            payment.DropDownStyle = ComboBoxStyle.DropDownList;
            payment.Items.AddRange(new string[] { "Credit card", "Debit card", "Cash" });
            payment.SelectedIndex = 0;
            payment.Dock = DockStyle.Fill;
            grid.Controls.Add(payment, 1, 1);
            grid.SetColumnSpan(payment, 1);

            // Pay button
            pay = new Button();
            pay.Text = "Pay";
            pay.Dock = DockStyle.Fill;
            grid.Controls.Add(pay, 1, 2);
            grid.SetColumnSpan(pay, 1);

            pay.Click += (object sender, EventArgs e) => Pay();
        }

        void SCanCard()
        {
            if (!discount)
            {
                ds = new DCScanner1();
                DiscountPersentage = ds.RetrieveCardData(ds.Scancard());
                Price = Price * (1 - DiscountPersentage);

                discount = true;
            }
        }

        void Pay()
        {
            Price = (float)Math.Round(Price, 2);
            switch (payment.SelectedIndex)
            {
                case 0:
                    CreditCard c = new CreditCard();
                    c.Connect();
                    Price += 0.5f;
                    int ccid = c.BeginTransaction(Price);
                    PaymentSuccesful = c.EndTransaction(ccid);
                    break;
                case 1:
                    DebitCard d = new DebitCard();
                    d.Connect();
                    int dcid = d.BeginTransaction(Price);
                    PaymentSuccesful = d.EndTransaction(dcid);
                    break;
                case 2:
                    IKEAMyntAtare2000 coin = new IKEAMyntAtare2000();
                    coin.starta();
                    coin.betala(Price);
                    PaymentSuccesful = coin.stoppa(true); //false
                    break;
            }
            PaymentSucces(PaymentSuccesful, Price);
        }

        void PaymentSucces(bool succes, float price)
        {
            if (succes)
            {
                UI.paid = true;
                UI.price = price;
                Close();
            }
        }
    }
}
