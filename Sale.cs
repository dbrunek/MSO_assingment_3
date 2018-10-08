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
            Width = 700;
            Height = 310;
            // Set layout
            var grid = new TableLayoutPanel();
            grid.Dock = DockStyle.Fill;
            grid.Padding = new Padding(5);
            Controls.Add(grid);
            grid.RowCount = 4;
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            grid.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 40));
            grid.ColumnCount = 4;
            for (int i = 0; i < 4; i++)
            {
                ColumnStyle c = new ColumnStyle(SizeType.Percent, 32.0f);
                //ColumnStyle c = new ColumnStyle(SizeType.AutoSize);
                grid.ColumnStyles.Add(c);
            }

            
            // Pay button
            DCCard = new Button();
            DCCard.Text = "Scan Discount Card";
            DCCard.Dock = DockStyle.Fill;
            grid.Controls.Add(DCCard, 0, 1);
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
            grid.Controls.Add(payment, 2, 1);
            grid.SetColumnSpan(payment, 1);

            // Pay button
            pay = new Button();
            pay.Text = "Pay";
            pay.Dock = DockStyle.Fill;
            grid.Controls.Add(pay, 2, 1);
            grid.SetColumnSpan(pay, 3);

            pay.Click += (object sender, EventArgs e) => Pay();
        }

        void SCanCard()
        {
            if (!discount) 
            {
                ds = new DCScanner();
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
                    int ccid = c.BeginTransaction(Price);
                    c.EndTransaction(ccid);
                    break;
                case 1:
                    DebitCard d = new DebitCard();
                    d.Connect();
                    int dcid = d.BeginTransaction(Price);
                    d.EndTransaction(dcid);
                    break;
                case 2:
                    IKEAMyntAtare2000 coin = new IKEAMyntAtare2000();
                    coin.starta();
                    coin.betala(Price);
                    coin.stoppa();
                    break;
            }
            Close();
        }
    }
}
