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
            var list = new ListView();
            
            buttonStart.Click += (o, e) => ButtonClick(currency.Text, dateFrom.SelectedDate, dateTo.SelectedDate);
        }

        public void ButtonClick(string currency, DateTime? from, DateTime? to)
        {
            string curr = currency;
            string[] array = new string[] {curr, from.ToString(), to.ToString() };
            Controller controller = new Controller(array);
            controller.RunWPF();
            string a = controller.f;
            string b = controller.g;

            var gridView = new GridView();
            
            listOfElements.Items.Add(a);
            listOfElements.Items.Add(b);
        }
    }
}
