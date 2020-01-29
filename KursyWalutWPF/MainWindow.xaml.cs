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
                this.listOfElements.Items.Add(buyingValues);
                this.listOfElements.Items.Add(sellingValues);
            }
        }
    }
}
