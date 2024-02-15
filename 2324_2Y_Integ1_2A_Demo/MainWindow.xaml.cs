using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _2324_2Y_Integ1_2A_Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Button[] btnNums = new Button[10];
        float num1 = 0;
        float num2 = 0;
        int ope = -1;
        bool isclear = false;

        public MainWindow()
        {
            InitializeComponent();

            btnNums[0] = btn0;
            btnNums[1] = btn1;
            btnNums[2] = btn2;
            btnNums[3] = btn3;
            btnNums[4] = btn4;
            btnNums[5] = btn5;
            btnNums[6] = btn6;
            btnNums[7] = btn7;
            btnNums[8] = btn8;
            btnNums[9] = btn9;

            for (int x = 0; x < btnNums.Length; x++)
                btnNums[x].Content = x;

            btnAdd.Content = "+";
            btnMin.Content = "-";
            btnMult.Content = "x";
            btnDiv.Content = "/";
            btnEnter.Content = "=";
            btnSqrt.Content = "√";
            btnPow.Content = "^";
            btnClear.Content = "C";
            btnFactorial.Content = "!";
            btnFloat.Content = ".";
        }

        private void numberEnter(int x)
        {
            if (isclear)
                Clear();

            string input = tbCalc.Text;
            input += x;

            if (input.Length > 12)
                input = input.Substring(1);

            if (ope == -1)
            {
                num1 = float.Parse(input);
                isclear = false;
            }
            else
                num2 = float.Parse(input);


            tbCalc.Text = input;
        }

        #region KeypadEvents
        private void btn9_Click(object sender, RoutedEventArgs e)
        {
            numberEnter(9);
        }

        private void btn8_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(8);
        }

        private void btn7_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(7);
        }

        private void btn6_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(6);
        }

        private void btn5_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(5);
        }

        private void btn4_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(4);
        }

        private void btn3_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(3);
        }

        private void btn2_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(2);
        }

        private void btn1_Click(object sender, RoutedEventArgs e)
        {

            numberEnter(1);
        }

        private void btn0_Click(object sender, RoutedEventArgs e)
        {
            numberEnter(0);

        }
        #endregion

        #region OperationEvents
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ope = 0;
            tbCalc.Text = "";
            tbEqua.Text = $"{num1} +";
            isclear = false;
            btnOpeColor();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
        {
            ope = 1;
            num2 = 0;
            tbCalc.Text = "";
            tbEqua.Text = $"{num1} -";
            isclear = false;
            btnOpeColor();
        }

        private void btnMult_Click(object sender, RoutedEventArgs e)
        {
            ope = 2;
            num2 = 0;
            tbCalc.Text = "";
            tbEqua.Text = $"{num1} x";
            isclear = false;
            btnOpeColor();
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            ope = 3;
            num2 = 0;
            tbCalc.Text = "";
            tbEqua.Text = $"{num1} /";
            isclear = false;
            btnOpeColor();
        }
        private void btnPow_Click(object sender, RoutedEventArgs e)
        {
            ope = 4;
            num2 = 0;
            tbCalc.Text = "";
            tbEqua.Text = $"{num1} ^";
            isclear = false;
            btnOpeColor();
        }
        private void btnSqrt_Click(object sender, RoutedEventArgs e)
        {
            isclear = true;
            tbEqua.Text = $"√{num1}";
            num1 = (float)Math.Sqrt(num1);
            tbCalc.Text = num1.ToString();
        }

        private void btnFactorial_Click(object sender, RoutedEventArgs e)
        {
            isclear = true;
            tbEqua.Text = $"{num1}!";
            int temp = 1;
            for (int i = (int)num1; i > 0; i--)
                temp *= i;
            num1 = temp;
            tbCalc.Text = num1.ToString();
        }

        private void btnFloat_Click(object sender, RoutedEventArgs e)
        {
            if(!tbCalc.Text.Contains('.') && !isclear)
                tbCalc.Text += '.';
            else
            {
                Clear();
                isclear = false;
                tbCalc.Text += '.';
            }
        }

        #endregion

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            tbEqua.Text = "";
            switch (ope)
            {
                case 0:
                    tbEqua.Text = $"{num1} + {num2} =";
                    num1 += num2;
                    break;
                case 1:
                    tbEqua.Text = $"{num1} - {num2} =";
                    num1 -= num2;
                    break;
                case 2:
                    tbEqua.Text = $"{num1} x {num2} =";
                    num1 *= num2;
                    break;
                case 3:
                    tbEqua.Text = $"{num1} / {num2} =";
                    num1 /= num2;
                    break;
                case 4:
                    tbEqua.Text = $"{num1} ^ {num2} =";
                    num1 = (float)Math.Pow(num1, num2);
                    break;
            }
            
            if(ope > -1)
            {
                tbCalc.Text = num1.ToString();
                isclear = true;
                //ope = -1;
                //num2 = 0;
                btnOpeColor();
            }
        }

        private void btnOpeColor()
        {
            btnAdd.Background = Brushes.LightGray;
            btnMin.Background = Brushes.LightGray;
            btnMult.Background = Brushes.LightGray;
            btnDiv.Background = Brushes.LightGray;
            btnPow.Background = Brushes.LightGray;

            switch (ope) 
            {
                case 0:
                    btnAdd.Background = Brushes.LightGreen;
                    break;
                case 1:
                    btnMin.Background = Brushes.LightGreen;
                    break;
                case 2:
                    btnMult.Background = Brushes.LightGreen;
                    break;
                case 3:
                    btnDiv.Background = Brushes.LightGreen;
                    break;
                case 4:
                    btnPow.Background = Brushes.LightGreen;
                    break;
            }

        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            tbCalc.Text = "";
            tbEqua.Text = "";
            num1 = 0;
            num2 = 0;
            ope = -1;
            btnOpeColor();
        }
       
    }
}
