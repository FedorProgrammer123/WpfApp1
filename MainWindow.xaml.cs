using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            foreach (UIElement element in MyGrid.Children)
            {
                if (element is Button)
                {
                    ((Button)element).Click += CalcEvent;
                }
            }
        }
        public void CalcEvent(object Sender, RoutedEventArgs e)
        {
            string value = ((Button)e.OriginalSource).Content.ToString();
            if (value == "CE")
            {
                ResultBox.Text = "";
            }
            else if (value == "=")
            {
                string equil = new DataTable().Compute(ResultBox.Text,null).ToString();
                ResultBox.Text = equil;
            }
            else if (value == "x2")
            {
                double sqr = Math.Pow(Convert.ToDouble(ResultBox.Text),2);
                ResultBox.Text = sqr.ToString();
            }
            else if (value == "sqrt(x)")
            {
                double sqrt = Math.Sqrt(Convert.ToDouble(ResultBox.Text));
                ResultBox.Text = sqrt.ToString();
            }
            else
            {
                ResultBox.Text += value;
            }      
        }
    }
}
