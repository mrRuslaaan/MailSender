using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender
{
    public static class Data
    {        
        public static string From { get; set; }  = "annaev.rusik@yandex.ru";
        public static string To { get; set; } = "annaev.ruslan@gmail.com";
        public static string Head { get; set; } = "Hello";
        public static string Body { get; set; } = "How are you?";
        public static string SmptClientName { get; set; } = "smtp.yandex.ru";
        public static int Port { get; set; } = 587;
    }
}
