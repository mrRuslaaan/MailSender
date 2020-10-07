using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using MailSender.Models;
using MailSender.ViewModels.Base;
using MailSender.Infrastructure.Commands;
using MailSender.lib.Interfaces;
using MailSender.Views;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock.Layout;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        #region Fields
        private string _Title = "Главное окно";

        private ObservableCollection<Server> _Servers;
        private ObservableCollection<Sender> _Senders;
        private ObservableCollection<Recipient> _Recipients;
        private ObservableCollection<Message> _Messages;

        private Sender _SelectedSender;
        private Server _SelectedServer;
        private Recipient _SelectedRecipient;
        private Message _SelectedMessage;

        private readonly IMailService _MailService;
        #endregion

        #region Properties
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }


        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            set => Set(ref _Servers, value);
        }

        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            set => Set(ref _Senders, value);
        }

        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            set => Set(ref _Recipients, value);
        }

        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => Set(ref _Messages, value);
        }

        public Sender SelectedSender
        {
            get => _SelectedSender;
            set => Set(ref _SelectedSender, value);
        }

        public Server SelectedServer
        {
            get => _SelectedServer;
            set => Set(ref _SelectedServer, value);
        }
        public Recipient SelectedRecipient
        {
            get => _SelectedRecipient;
            set => Set(ref _SelectedRecipient, value);
        }
        public Message SelectedMessage
        {
            get => _SelectedMessage;
            set => Set(ref _SelectedMessage, value);
        }
        #endregion

        #region Commands

        #region GoToPlanner
        private ICommand _GoToPlanner;

        public ICommand GoToPlanner => _GoToPlanner
            ??= new LambdaCommand(OnGoToPlannerCommand, CanGoToPlannerCommandExecute);
        private bool CanGoToPlannerCommandExecute(object p) => true;
        private void OnGoToPlannerCommand(object p)
        {
        }
        #endregion

        #region CloseWindowCommand
        private ICommand _CloseWindowCommand;

        public ICommand CloseWindowCommand => _CloseWindowCommand
            ??= new LambdaCommand(OnCloseWindowCommand, CanCloseWindowCommandExecute);
        private bool CanCloseWindowCommandExecute(object p) => true;

        private void OnCloseWindowCommand(object p) 
        {
            var window = p as Window;

            if (window is null)
                window = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(w => w.IsFocused);

            if (window is null)
                window = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(w => w.IsActive);


            window?.Close();
        }
        #endregion

        #region ServersCmds

        #region CreateNewServerCmd
        private ICommand _CreateNewServerCommand;

        public ICommand CreateNewServerCommand => _CreateNewServerCommand
            ??= new LambdaCommand(OnCreateNewServerCommandExecuted, CanCreateNewServerCommandExecute);

        private bool CanCreateNewServerCommandExecute(object p) => true;

        private void OnCreateNewServerCommandExecuted(object p)
        {
            
        }
        #endregion
        
        #region EditServerCmd
        private ICommand _EditServerCommand;
        public ICommand EditServerCommand => _EditServerCommand
            ??= new LambdaCommand(OnEditServerCommandExecuted, CanEditServerCommandExecute);

        private bool CanEditServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnEditServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера {server.Address}!", "Управление серверами");
        }
        #endregion
        
        #region DeleteServerCmd

        private ICommand _DeleteServerCommand;

        public ICommand DeleteServerCommand => _DeleteServerCommand
            ??= new LambdaCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecute);

        private bool CanDeleteServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnDeleteServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();
        }
        #endregion

        #endregion
        /*
        #region RecipientsCmds
        #region CreateNewRecipientCmd
        private ICommand _CreateNewRecipientCommand;

        public ICommand CreateNewRecipientCommand => _CreateNewRecipientCommand
            ??= new LambdaCommand(OnCreateNewRecipientCommandExecuted, CanCreateNewRecipientCommandExecute);

        private bool CanCreateNewRecipientCommandExecute(object p) => true;

        private void OnCreateNewRecipientCommandExecuted(object p)
        {
            // Основное действие, выполняемое командой, описывается здесь!!!

            MessageBox.Show("Создание нового сервера!", "Управление серверами");
        }
        #endregion

        #region EditRecipientCmd
        private ICommand _EditRecipientCommand;
        public ICommand EditRecipientCommand => _EditRecipientCommand
            ??= new LambdaCommand(OnEditRecipientCommandExecuted, CanEditRecipientCommandExecute);

        private bool CanEditRecipientCommandExecute(object p) => p is Recipient || SelectedRecipient != null;

        private void OnEditRecipientCommandExecuted(object p)
        {
            var server = p as Recipient ?? SelectedRecipient;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера {server.Address}!", "Управление серверами");
        }
        #endregion

        #region DeleteRecipientCmd

        private ICommand _DeleteRecipientCommand;

        public ICommand DeleteRecipientCommand => _DeleteRecipientCommand
            ??= new LambdaCommand(OnDeleteRecipientCommandExecuted, CanDeleteRecipientCommandExecute);

        private bool CanDeleteRecipientCommandExecute(object p) => p is Recipient || SelectedRecipient != null;

        private void OnDeleteRecipientCommandExecuted(object p)
        {
            var server = p as Recipient ?? SelectedRecipient;
            if (server is null) return;

            Recipients.Remove(server);
            SelectedRecipient = Recipients.FirstOrDefault();

            //MessageBox.Show($"Удаление сервера {server.Address}!", "Управление серверами");
        }
        #endregion
        #endregion

        #region SendersCmds
        #region CreateNewSenderCmd
        private ICommand _CreateNewSenderCommand;

        public ICommand CreateNewSenderCommand => _CreateNewSenderCommand
            ??= new LambdaCommand(OnCreateNewSenderCommandExecuted, CanCreateNewSenderCommandExecute);

        private bool CanCreateNewSenderCommandExecute(object p) => true;

        private void OnCreateNewSenderCommandExecuted(object p)
        {
            // Основное действие, выполняемое командой, описывается здесь!!!

            MessageBox.Show("Создание нового сервера!", "Управление серверами");
        }
        #endregion

        #region EditSenderCmd
        private ICommand _EditSenderCommand;
        public ICommand EditSenderCommand => _EditSenderCommand
            ??= new LambdaCommand(OnEditSenderCommandExecuted, CanEditSenderCommandExecute);

        private bool CanEditSenderCommandExecute(object p) => p is Sender || SelectedSender != null;

        private void OnEditSenderCommandExecuted(object p)
        {
            var server = p as Sender ?? SelectedSender;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера {server.Address}!", "Управление серверами");
        }
        #endregion

        #region DeleteSenderCmd

        private ICommand _DeleteSenderCommand;

        public ICommand DeleteSenderCommand => _DeleteSenderCommand
            ??= new LambdaCommand(OnDeleteSenderCommandExecuted, CanDeleteSenderCommandExecute);

        private bool CanDeleteSenderCommandExecute(object p) => p is Sender || SelectedSender != null;

        private void OnDeleteSenderCommandExecuted(object p)
        {
            var server = p as Sender ?? SelectedSender;
            if (server is null) return;

            Senders.Remove(server);
            SelectedSender = Senders.FirstOrDefault();

            //MessageBox.Show($"Удаление сервера {server.Address}!", "Управление серверами");
        }
        #endregion
        #endregion

        #region MessagesCmds
        #region CreateNewMessageCmd
        private ICommand _CreateNewMessageCommand;

        public ICommand CreateNewMessageCommand => _CreateNewMessageCommand
            ??= new LambdaCommand(OnCreateNewMessageCommandExecuted, CanCreateNewMessageCommandExecute);

        private bool CanCreateNewMessageCommandExecute(object p) => true;

        private void OnCreateNewMessageCommandExecuted(object p)
        {
            // Основное действие, выполняемое командой, описывается здесь!!!

            MessageBox.Show("Создание нового сервера!", "Управление серверами");
        }
        #endregion

        #region EditMessagesCmd
        private ICommand _EditMessageCommand;
        public ICommand EditMessageCommand => _EditMessageCommand
            ??= new LambdaCommand(OnEditMessageCommandExecuted, CanEditMessageCommandExecute);

        private bool CanEditMessageCommandExecute(object p) => p is Message || SelectedMessage != null;

        private void OnEditMessageCommandExecuted(object p)
        {
            var server = p as Message ?? SelectedMessage;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера {server.Address}!", "Управление серверами");
        }
        #endregion

        #region DeleteMessageCmd

        private ICommand _DeleteMessageCommand;

        public ICommand DeleteMessageCommand => _DeleteMessageCommand
            ??= new LambdaCommand(OnDeleteMessageCommandExecuted, CanDeleteMessageCommandExecute);

        private bool CanDeleteMessageCommandExecute(object p) => p is Message || SelectedMessage != null;

        private void OnDeleteMessageCommandExecuted(object p)
        {
            var server = p as Message ?? SelectedMessage;
            if (server is null) return;

            Messages.Remove(server);
            SelectedMessage = Messages.FirstOrDefault();

        }
        #endregion
        #endregion
        */

        #region Command SendMailCommand

        private ICommand _SendMailCommand;
        public ICommand SendMailCommand => _SendMailCommand
            ??= new LambdaCommand(OnSendMailCommandExecuted, CanSendMailCommandExecute);

        private bool CanSendMailCommandExecute(object p)
        {
            if (SelectedServer is null) return false;
            if (SelectedSender is null) return false;
            if (SelectedRecipient is null) return false;
            if (SelectedMessage is null) return false;
            return true;
        }

        private void OnSendMailCommandExecuted(object p)
        {
            var server = SelectedServer;
            var sender = SelectedSender;
            var recipient = SelectedRecipient;
            var message = SelectedMessage;

            var mail_sender = _MailService.GetSender(server.Address, server.Port, server.UseSSL, server.Login, server.Password);
            mail_sender.Send(sender.Address, recipient.Address, message.Subject, message.Body);
        }

        #endregion
        #endregion

        #region MainWindowViewModel constructor 
        public MainWindowViewModel(IMailService MailService)
        {
            _MailService = MailService;
            Servers = new ObservableCollection<Server>(Data.Servers);
            Senders = new ObservableCollection<Sender>(Data.Senders);
            Recipients = new ObservableCollection<Recipient>(Data.Recipients);
            Messages = new ObservableCollection<Message>(Data.Messages);
        }
        #endregion 
    }
}