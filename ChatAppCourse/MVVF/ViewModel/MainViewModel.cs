using ChatClient.MVM.Core;
using ChatClient.MVVF.Model;
using ChatClient.Net;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;

namespace ChatClient.MVVF.ViewModel
{
    // Головний ViewModel, який реалізує INotifyPropertyChanged для повідомлення про зміни властивостей.
    class MainViewModel : INotifyPropertyChanged
    {
        // Колекція користувачів, які підключені до чату.
        public ObservableCollection<UserModel> Users { get; set; }
        // Колекція повідомлень чату.
        public ObservableCollection<string> Messages { get; set; }

        // Команда для підключення до сервера.
        public RelayCommand ConnectToServerCommand { get; set; }
        // Команда для відправки повідомлення.
        public RelayCommand SendMessageCommand { get; set; }

        // Приватні поля для зберігання стану та даних.
        private string _username;
        private string _message;
        private bool _isConnected;
        private Server _server;

        // Властивість для отримання та встановлення імені користувача.
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
                ConnectToServerCommand.RaiseCanExecuteChanged();
            }
        }

        // Властивість для отримання та встановлення повідомлення.
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }

        // Властивість для отримання та встановлення стану підключення.
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
                ConnectToServerCommand.RaiseCanExecuteChanged();
                SendMessageCommand.RaiseCanExecuteChanged();
            }
        }

        // Конструктор MainViewModel.
        public MainViewModel()
        {
            Users = new ObservableCollection<UserModel>();
            Messages = new ObservableCollection<string>();

            // Ініціалізація сервера та підписка на події.
            _server = new Server();
            _server.connectedEvent += OnUserConnected;
            _server.msgRecaivedEvent += OnMessageReceived;
            _server.userDisconnectEvent += OnUserDisconnected;

            // Ініціалізація команд
            ConnectToServerCommand = new RelayCommand(o => ConnectToServer(), o => !string.IsNullOrEmpty(Username) && !IsConnected);
            SendMessageCommand = new RelayCommand(SendMessage, o => !string.IsNullOrEmpty(Message) && IsConnected);
        }

        // Метод для підключення до сервера.
        private void ConnectToServer()
        {
            _server.ConnectToServer(Username);
            IsConnected = true;
        }

        // Метод для відправки повідомлення.
        private void SendMessage(object obj)
        {
            _server.SendMessageToServer(Message);
            Message = string.Empty; // Очищення повідомлення після відправки.
        }

        // Метод, що викликається при відключенні користувача.
        private void OnUserDisconnected()
        {
            var uid = _server.PacketReader.ReadMessage();
            var user = Users.FirstOrDefault(x => x.UID == uid);
            Application.Current.Dispatcher.Invoke(() => Users.Remove(user));
        }

        // Метод, що викликається при отриманні нового повідомлення.
        private void OnMessageReceived()
        {
            var msg = _server.PacketReader.ReadMessage();
            Application.Current.Dispatcher.Invoke(() => Messages.Add(msg));
        }

        // Метод, що викликається при підключенні нового користувача.
        private void OnUserConnected()
        {
            var user = new UserModel
            {
                Username = _server.PacketReader.ReadMessage(),
                UID = _server.PacketReader.ReadMessage(),
            };

            if (!Users.Any(x => x.UID == user.UID))
            {
                Application.Current.Dispatcher.Invoke(() => Users.Add(user));
            }
        }

        // Подія для повідомлення про зміни властивостей.
        public event PropertyChangedEventHandler PropertyChanged;
        // Метод для виклику події зміни властивостей.
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
 