using ChatClient.Net.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChatClient.Net
{
    class Server
    {
        // Поле для зберігання TCP клієнта
        TcpClient _client;

        // Поле для зчитування пакетів
        public PacketReader PacketReader;

        // Події для повідомлення про різні події
        public event Action connectedEvent;
        public event Action msgRecaivedEvent;
        public event Action userDisconnectEvent;

        // Конструктор, який ініціалізує TCP клієнта
        public Server()
        {
            _client = new TcpClient();
        }

        // Метод для підключення до сервера з вказаним ім'ям користувача
        public void ConnectToServer(string username)
        {
            if (!_client.Connected)
            {
                _client.Connect("127.0.0.1", 7891); // Підключення до сервера
                PacketReader = new PacketReader(_client.GetStream()); // Ініціалізація PacketReader

                if (!string.IsNullOrEmpty(username))
                {
                    // Створення пакету для підключення
                    var connectPacket = new PacketBuilder();
                    connectPacket.WriteOpCode(0);
                    connectPacket.WriteMessage(username);
                    _client.Client.Send(connectPacket.GetPacketByte()); // Відправлення пакету на сервер
                }
                ReadPackets(); // Читання пакетів з сервера
            }
        }

        // Метод для читання пакетів з сервера
        private void ReadPackets()
        {
            // Виконання в окремому завданні
            Task.Run(() =>
            {
                while (true)
                {
                    var opcode = PacketReader.ReadByte(); // Зчитування операційного коду
                    switch (opcode)
                    {
                        case 1:
                            connectedEvent?.Invoke(); // Виклик події підключення
                            break;
                        case 5:
                            msgRecaivedEvent?.Invoke(); // Виклик події отримання повідомлення
                            break;
                        case 10:
                            userDisconnectEvent?.Invoke(); // Виклик події відключення користувача
                            break;
                        default:
                            Console.WriteLine("..."); 
                            break;
                    }
                }
            });
        }

        // Метод для відправки повідомлення на сервер
        public void SendMessageToServer(string message)
        {
            var messagePacket = new PacketBuilder();
            messagePacket.WriteOpCode(5); // Встановлення операційного коду для повідомлення
            messagePacket.WriteMessage(message); // Додавання повідомлення в пакет
            _client.Client.Send(messagePacket.GetPacketByte()); // Відправлення пакету на сервер
        }
    }
}
