
using System.Windows;


namespace MailSender
{
    public partial class SendEndWindow : Window
    {
        public SendEndWindow()
        {
            InitializeComponent();
        }

        private void btnOkClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
