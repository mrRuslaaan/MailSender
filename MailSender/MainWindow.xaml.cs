using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
<<<<<<< HEAD
using MailSender.lib;
=======
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
>>>>>>> parent of f2ee804... Merge remote-tracking branch 'origin/lesson-1'

namespace MailSender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
<<<<<<< HEAD
        public MainWindow() => InitializeComponent();
        private void ExitButtonClick(object sender, System.Windows.RoutedEventArgs e)
        {
            this.Close();
        }       

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabContol.SelectedItem = tabPlanner;            
=======
        public MainWindow()
        {
            InitializeComponent();
>>>>>>> parent of f2ee804... Merge remote-tracking branch 'origin/lesson-1'
        }
    }
}
