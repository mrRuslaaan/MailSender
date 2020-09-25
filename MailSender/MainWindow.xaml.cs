namespace MailSender
{
    public partial class MainWindow
    {
        public MainWindow() => InitializeComponent();

        private void OnSendBtnClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var emailSend = new EmailSendServiceClass(UserEdit.Text, 
                                                      PasswordEdit.SecurePassword, 
                                                      Data.from, 
                                                      Data.to, 
                                                      Data.head, 
                                                      Data.body, 
                                                      Data.smptClientName, 
                                                      Data.port);
            emailSend.EmailSend();
        }
        private void ExitButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            Close();
        }

        private void HeadEnter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Data.head = Head.Text;
        }

        private void BodyEnter(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Data.body = Body.Text;
        }
    }
}
