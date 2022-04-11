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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double value1;
        double value;
        string op;
        private void ResetValues(double x, double y, string op)
        {
            x *= 0; y *= 0;op = "";
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            int value = Convert.ToInt32(b.Content);
            TheTextBox.Text += value.ToString();
        }
        private void Op_Button_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            op = b.Content.ToString();
            value1 = Convert.ToDouble(TheTextBox.Text);
            MiniTextBox.Text = $"{value1.ToString()}{op}";
            TheTextBox.Clear();
        }

        private void Button_equal_Click(object sender, RoutedEventArgs e)
        {
            value = Convert.ToDouble(TheTextBox.Text);
            if(op == "+")
            {
                value1 += value;
                TheTextBox.Text = value1.ToString();
            }
            else if(op == "-")
            {
                value1 -= value;
                TheTextBox.Text = value1.ToString();
            }
            else if(op == "x")
            {
                value1 *= value;
                TheTextBox.Text = value1.ToString();
            }
            else if(op == "/")
            {
                value1 /= value;
                TheTextBox.Text = value1.ToString();
            }
            ResetValues(value, value1, op);
            MiniTextBox.Clear();
        }

        private void Button_clear_Click(object sender, RoutedEventArgs e)
        {
            ResetValues(value, value1, op);
            TheTextBox.Text = "0";
        }

        private void Button_prd_Click(object sender, RoutedEventArgs e)
        {
            TheTextBox.Text += ".";
        }

        private void Button_sqr_Click(object sender, RoutedEventArgs e)
        {
            value = Convert.ToDouble(TheTextBox.Text);
            TheTextBox.Text =  Convert.ToString(Convert.ToDouble(Math.Pow(value, 2)));
        }

        private void Button_sqrt_Click(object sender, RoutedEventArgs e)
        {
            value = Convert.ToDouble(TheTextBox.Text);
            TheTextBox.Text = Convert.ToString(Convert.ToDouble(Math.Sqrt(value)));
        }

        private void Button_frac_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                value = Convert.ToDouble(TheTextBox.Text);
                TheTextBox.Text = Convert.ToString(1 / value);
            }
            catch
            {
                TheTextBox.FontSize = 15;
                TheTextBox.Text = "Please enter a value and then press the button :/";
            }
        }
    }
}
