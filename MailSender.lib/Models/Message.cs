using MailSender.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.Models
{
    public class Message : Entity
    {
        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
