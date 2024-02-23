using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ACTIVIDAD_02
{
                                                //INTEGRANTES://
                                            //_____________________//
                                               //PABLO ASCARRAGA//
                                               //CLAUDIA ESCOBAR//

    public partial class MainWindow : Window
    {
        private string operador = "";
        private double numero1 = 0;
        private bool nuevaOperacion = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            if (nuevaOperacion)
            {
                txtResultado.Text = "";
                nuevaOperacion = false;
            }

            Button btn = (Button)sender;
            txtResultado.Text += btn.Content.ToString();
        }

        private void Operador_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            operador = btn.Content.ToString();
            nuevaOperacion = true;

            if (!string.IsNullOrEmpty(txtResultado.Text))
            {
                numero1 = Convert.ToDouble(txtResultado.Text);
            }
        }

        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            txtResultado.Text = "";
            numero1 = 0;
            nuevaOperacion = true;
        }

        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtResultado.Text))
            {
                double numero2 = Convert.ToDouble(txtResultado.Text);
                double resultado = RealizarOperacion(numero1, numero2, operador);
                txtResultado.Text = resultado.ToString();
                nuevaOperacion = true;
            }
        }

        private double RealizarOperacion(double num1, double num2, string operacion)
        {
            switch (operacion)
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                case "/":
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    else
                    {
                        MessageBox.Show("Error: División por cero no permitida.");
                        return 0;
                    }
                default:
                    return 0;
            }
        }
    }
}
