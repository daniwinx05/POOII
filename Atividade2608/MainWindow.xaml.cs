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

namespace Atividade2608
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }



 

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float temp = float.Parse(tempC.Text);
            
           
            float tempF = (temp * 1.8F) + 32;


            texto.Text = ($" O valor convertido é {tempF:F2}F");

        }

        private void tempC_TextChanged(object sender, TextChangedEventArgs e)
        {

            float temp = float.Parse(tempC.Text);


            float tempF = (temp * 1.8F) + 32;


            texto.Text = ($" O valor convertido é {tempF:F2}F");


        }
    }
}
