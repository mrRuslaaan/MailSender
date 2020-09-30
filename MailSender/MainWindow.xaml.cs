using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();
        private void ExitButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }       

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabContol.SelectedItem = tabPlanner;            
        }
    }
}
