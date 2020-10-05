using System.Net;
using System.Net.Mail;
using System.Security;
using System;
using System.Windows;


namespace MailSender
{
    public class EmailSendServiceClass
    {
        private string from;
        private SecureString securePassword;
        private string to;
        private string head;
        private string body;
        private string smptName;
        private int port;
        public EmailSendServiceClass(string _UserName,SecureString _SecurePassword, string _to, string _head, string _body, string _smptName, int _port)
        {
            from = _UserName;
            securePassword = _SecurePassword;
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

            using MailMessage mes = new MailMessage(sender, receiver);

            mes.Subject = head;
            mes.Body = body;

            using SmtpClient smtp = new SmtpClient(smptName, port);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(from, securePassword);
            
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
