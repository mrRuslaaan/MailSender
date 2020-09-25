using System.Net;
using System.Net.Mail;
using System.Security;
using System;
using System.Windows;


namespace MailSender
{
    public class EmailSendServiceClass
    {
        private string UserName;
        private SecureString SecurePassword;
        private string from;
        private string to;
        private string head;
        private string body;
        private string smptName;
        private int port;
        public EmailSendServiceClass(string _UserName,SecureString _SecurePassword, string _from, string _to, string _head, string _body, string _smptName, int _port)
        {
            UserName = _UserName;
            SecurePassword = _SecurePassword;
            from = _from;
            to = _to;
            head = _head;
            body = _body;
            smptName = _smptName;
            port = _port;
        }
        
        public void EmailSend() 
        {
            MailAddress sender = new MailAddress(from);
            MailAddress receiver = new MailAddress(to);

            MailMessage mes = new MailMessage(from, to);

            mes.Subject = head;
            mes.Body = body;

            SmtpClient smtp = new SmtpClient(smptName, port);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(UserName, SecurePassword);
            
            try
            {
                smtp.Send(mes);
            }
            catch (Exception ex)
            {
                ErrorWindow errorMes = new ErrorWindow();
                errorMes.TextError.Text = ex.ToString();
                errorMes.Show();
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }


    }
}
