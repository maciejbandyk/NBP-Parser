using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using KursyWalut;

namespace KursyWalutWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //listOfElements.Items.Add(new Item { Type = "Selling", Currency = "USD", Max = 2.542, Min = 2.551, StandardDeviation = 0.00042 });
            var list = new ListView();

            buttonStart.Click += (o, e) => ButtonClick(currency.Text, dateFrom.SelectedDate, dateTo.SelectedDate);
        }

        public void ButtonClick(string currency, DateTime? from, DateTime? to)
        {
            string curr = currency;
            string[] array = new string[] { curr, from.ToString(), to.ToString() };
            if (from > to)
            {
                MessageBox.Show("Date from can't be greater than date to!");

            }
            else
            {
                Controller controller = new Controller(array);
                controller.RunWPF();
                Values buyingValues = controller.buyingValues;
                Values sellingValues = controller.sellingValues;

                //string b = controller.buyingList;


                this.listOfElements.Items.Add(buyingValues);
                this.listOfElements.Items.Add(sellingValues);

                //listOfElements.Items.Add(a);
                //listOfElements.Items.Add(b);
            }

        }
    }

    public class Item 
    {
        public string Type { get; set; }
        public string Currency { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double StandardDeviation { get; set; }
    }

}
