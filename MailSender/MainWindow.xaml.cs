using System.Windows;
using System.Windows.Controls;

namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void OnSendBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            if (UserEdit.Text != "")
            {
                Data.From = UserEdit.Text;
            }

            var emailSend = new EmailSendServiceClass(Data.From,
                                                      PasswordEdit.SecurePassword, 
                                                      Data.To, 
                                                      Data.Head, 
                                                      Data.Body, 
                                                      Data.SmptClientName, 
                                                      Data.Port);
            emailSend.EmailSend();
        }
        private void ExitButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void HeadEnter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Data.Head = Head.Text;
        }

        private void BodyEnter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Data.Body = Body.Text;
        }
    }
}
