using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Atividade2908
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Clique_Aqui_Click(object sender, RoutedEventArgs e)
        {
            var objetoNovo = new Window
            {
                Title = "oi",
                Width = 200,
                Height = 200,
            };

            var layout = new StackPanel();

            var t = new TextBlock { 
                
                
              Text = "Bom dia !",

            };
            layout.Children.Add(t);
            objetoNovo.Content = layout;
            objetoNovo.Show();
        }
        
           



       
    }
}