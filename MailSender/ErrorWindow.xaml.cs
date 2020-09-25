using System.Windows;

namespace MailSender
{
    public partial class ErrorWindow : Window
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }

        private void btnErrorOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
