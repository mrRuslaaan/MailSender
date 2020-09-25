using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender
{
    public static class Data
    {
        public static string from = "sender@yandex.ru";
        public static string to = "receiver@gmail.com";
        public static string head = "Hello";
        public static string body = "How are you?";
        public static string smptClientName = "smtp.yandex.ru";
        public static int port = 587;
    }
}
