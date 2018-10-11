using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab3
{
    public class UI : Form
    {
        ComboBox fromBox;
        ComboBox toBox;
        RadioButton firstClass;
        RadioButton secondClass;
        RadioButton oneWay;
        RadioButton returnWay;
        RadioButton Ticket1;
        RadioButton Ticket2;
        RadioButton Ticket3;
        RadioButton International;
        RadioButton Local;
        RadioButton Today;
        RadioButton Otherday;
        Button pay;
        public static float price;
        public static bool paid = false;
        int amount = 1;
        Sale sale;
        Printer printer;

        public UI()
        {
            initializeControls();
        }

        private void handlePayment(NormalTicket ticket)
        {
            CalculatePrice(ticket);
            
            sale = new Sale(price);
            sale.ShowDialog();
            if (paid)
            {
                printer = new Printer1(amount, ticket, price);
                printer.Print();
            }
            paid = false;
        }

        void CalculatePrice(NormalTicket ticket)
        {
            int tariefeenheden = Tariefeenheden.getTariefeenheden(ticket.From, ticket.To);
            float p;
            p = 0.16f * tariefeenheden + 0.82f; // is uit appendix B van Lab 2

            if(ticket.Class == 1)
            {
                p = p * 1.7f;
            }

            if(ticket.International)
            {
                p = p + 2f;
            }

            if (!ticket.Single)
            {
                p = p * 2f;
            }
            p *= amount;

            if (tariefeenheden == 0)
                p = 0f;
            price = p;
        }

        #region Set-up -- don't look at it
        private void initializeControls()
        {
            // Set label
            Text = "MSO Lab Exercise III";
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
            grid.ColumnCount = 6;
            for (int i = 0; i < 6; i++)
            {
                ColumnStyle c = new ColumnStyle(SizeType.Percent, 22.0f);
                //ColumnStyle c = new ColumnStyle(SizeType.AutoSize);
                grid.ColumnStyles.Add(c);
            }

            // Create From and To
            var fromLabel = new Label();
            fromLabel.Text = "From:";
            fromLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(fromLabel, 0, 0);
            fromLabel.Dock = DockStyle.Fill;
            fromBox = new ComboBox();
            fromBox.DropDownStyle = ComboBoxStyle.DropDownList;
            fromBox.Items.AddRange(Tariefeenheden.getStations());
            fromBox.SelectedIndex = 0;
            grid.Controls.Add(fromBox, 1, 0);
            grid.SetColumnSpan(fromBox, 2);
            fromBox.Dock = DockStyle.Fill;
            var toLabel = new Label();
            toLabel.Text = "To:";
            toLabel.TextAlign = ContentAlignment.MiddleRight;
            grid.Controls.Add(toLabel, 3, 0);
            toLabel.Dock = DockStyle.Fill;
            toBox = new ComboBox();
            toBox.DropDownStyle = ComboBoxStyle.DropDownList;
            toBox.Items.AddRange(Tariefeenheden.getStations());
            toBox.SelectedIndex = 0;
            grid.Controls.Add(toBox, 4, 0);
            grid.SetColumnSpan(toBox, 2);
            toBox.Dock = DockStyle.Fill;

            // Create groups
            GroupBox classGroup = new GroupBox();
            classGroup.Text = "Class";
            classGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(classGroup, 0, 1);
            grid.SetColumnSpan(classGroup, 1);
            var classGrid = new TableLayoutPanel();
            classGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            classGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            classGrid.Dock = DockStyle.Fill;
            classGroup.Controls.Add(classGrid);
            GroupBox wayGroup = new GroupBox();
            wayGroup.Text = "Amount";
            wayGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(wayGroup, 1, 1);
            grid.SetColumnSpan(wayGroup, 1);
            var wayGrid = new TableLayoutPanel();
            wayGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            wayGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            wayGrid.Dock = DockStyle.Fill;
            wayGroup.Controls.Add(wayGrid);

            //new
            GroupBox IntGroup = new GroupBox();
            IntGroup.Text = "International";
            IntGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(IntGroup, 2, 1);
            grid.SetColumnSpan(IntGroup, 1);
            var IntGrid = new TableLayoutPanel();
            IntGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            IntGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            IntGrid.Dock = DockStyle.Fill;
            IntGroup.Controls.Add(IntGrid);

            GroupBox DayGroup = new GroupBox();
            DayGroup.Text = "Choose Day";
            DayGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(DayGroup, 4, 1);
            grid.SetColumnSpan(DayGroup, 1);
            var DayGrid = new TableLayoutPanel();
            DayGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            DayGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 50.0f));
            DayGrid.Dock = DockStyle.Fill;
            DayGroup.Controls.Add(DayGrid);
            
            //verplaatst
            GroupBox discountGroup = new GroupBox();
            discountGroup.Text = "# of tickets";
            discountGroup.Dock = DockStyle.Fill;
            grid.Controls.Add(discountGroup, 5, 1);
            grid.SetColumnSpan(discountGroup, 1);
            var discountGrid = new TableLayoutPanel();
            discountGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            discountGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            discountGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33333f));
            discountGrid.Dock = DockStyle.Fill;
            discountGroup.Controls.Add(discountGrid);

            // Create radio buttons
            firstClass = new RadioButton();
            firstClass.Text = "1st class";          
            classGrid.Controls.Add(firstClass);
            secondClass = new RadioButton();
            secondClass.Text = "2nd class";
            secondClass.Checked = true;
            classGrid.Controls.Add(secondClass);
            oneWay = new RadioButton();
            oneWay.Text = "One-way";
            oneWay.Checked = true;
            wayGrid.Controls.Add(oneWay);
            returnWay = new RadioButton();
            returnWay.Text = "Return";
            wayGrid.Controls.Add(returnWay);


            //discount
            Ticket1 = new RadioButton();
            Ticket1.Text = "1";
            Ticket1.Checked = true;
            discountGrid.Controls.Add(Ticket1);
            Ticket2 = new RadioButton();
            Ticket2.Text = "2";
            discountGrid.Controls.Add(Ticket2);
            Ticket3 = new RadioButton();
            Ticket3.Text = "3";
            discountGrid.Controls.Add(Ticket3);


            //new
            International = new RadioButton();
            International.Text = "International";
            IntGrid.Controls.Add(International);
            Local = new RadioButton();
            Local.Text = "Local";
            Local.Checked = true;
            IntGrid.Controls.Add(Local);

            //new
            Today = new RadioButton();
            Today.Text = "Today";
            Today.Checked = true;
            DayGrid.Controls.Add(Today);
            Otherday = new RadioButton();
            Otherday.Text = "Other Day";
            DayGrid.Controls.Add(Otherday);

            // Pay button
            pay = new Button();
            pay.Text = "Pay";
            pay.Dock = DockStyle.Fill;
            grid.Controls.Add(pay, 0, 3);
            grid.SetColumnSpan(pay, 6);
            

            // Set up event
            pay.Click += (object sender, EventArgs e) => handlePayment(MakeTicket());
        }

        NormalTicket MakeTicket()
        {
            int klasse = 2;
            bool day = false;
            bool international = false;
            bool single = false;
            amount = 1;
            
            //eerste / 2e klas
            if (firstClass.Checked)
                klasse = 1;

            if (Today.Checked)
                day = true;

            if (International.Checked)
                international = true;
            
            if (oneWay.Checked)
                single = true;

            if (Ticket2.Checked)
                amount = 2;

            if (Ticket3.Checked)
                amount = 3;

            return new NormalTicket((string)fromBox.SelectedItem, (string)toBox.SelectedItem, klasse, day, single, international);
        }
        #endregion
    }
}

