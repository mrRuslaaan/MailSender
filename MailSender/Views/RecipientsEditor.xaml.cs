using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Views
{
    public partial class RecipientsEditor 
    {
        public RecipientsEditor() => InitializeComponent();


        private void DataValidationErrors(object? sender, ValidationErrorEventArgs e)
        {
            var control = (Control)e.OriginalSource;

            if (e.Action == ValidationErrorEventAction.Added)
            {
                control.ToolTip = e.Error.ErrorContent.ToString();
            }
            else
                control.ClearValue(ToolTipProperty);
        }
    }
}
