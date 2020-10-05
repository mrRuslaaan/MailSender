using System.Windows;
using System.Windows.Controls;
using MailSender.lib;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();   

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabContol.SelectedItem = tabPlanner;            
        }
    }
}
