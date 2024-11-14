using ChatServer.Net.IO; // Підключення простору імен для вводу-виводу пакетів
using System;
using System.Net;
using System.Net.Sockets;

namespace ChatServer
{
    class Program
    {
        static List<Client> _users; // Список клієнтів, підключених до сервера
        static TcpListener _listener; // Об'єкт для прослуховування з'єднань

        static void Main(string[] args)
        {
            _users = new List<Client>(); // Ініціалізація списку клієнтів
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7891); // Ініціалізація прослуховувача
            _listener.Start(); // Запуск прослуховувача

            while (true)
            {
                var client = new Client(_listener.AcceptTcpClient()); // Прийняття нового клієнта
                _users.Add(client); // Додавання клієнта до списку користувачів

                /* Транслювати з’єднання всім на сервері */
                BroadcastConnection(); 
            }

        }

        // Метод для трансляції інформації про підключення всім клієнтам
        static void BroadcastConnection()
        {
            foreach (var user in _users)
            {
                foreach (var usr in _users)
                {
                    var broadcastPacket = new PacketBuilder(); // Створення пакета для трансляції
                    broadcastPacket.WriteOpCode(1); // Додавання опкоду
                    broadcastPacket.WriteMessage(usr.Username); // Додавання імені користувача
                    broadcastPacket.WriteMessage(usr.UID.ToString()); // Додавання унікального ідентифікатора
                    user.ClientSocket.Client.Send(broadcastPacket.GetPacketByte()); // Відправлення пакета клієнту
                }
            }
        }

        // Метод для трансляції повідомлення всім клієнтам
        public static void BroadcastMessage(string message)
        {
            foreach (var user in _users)
            {
                var msgPacket = new PacketBuilder(); // Створення пакета для трансляції повідомлення
                msgPacket.WriteOpCode(5); // Додавання опкоду
                msgPacket.WriteMessage(message); // Додавання повідомлення
                user.ClientSocket.Client.Send(msgPacket.GetPacketByte()); // Відправлення пакета клієнту
            }
        }

        // Метод для трансляції інформації про відключення клієнта
        public static void BroadcastDisconnect(string uid)
        {
            var disconnectedUser = _users.Where(x => x.UID.ToString() == uid).FirstOrDefault(); // Пошук відключеного клієнта
            _users.Remove(disconnectedUser); // Видалення відключеного клієнта зі списку

            foreach (var user in _users)
            {
                var broadcastPacket = new PacketBuilder(); // Створення пакета для трансляції інформації про відключення
                broadcastPacket.WriteOpCode(10); // Додавання опкоду
                broadcastPacket.WriteMessage(uid); // Додавання ідентифікатора відключеного користувача
                user.ClientSocket.Client.Send(broadcastPacket.GetPacketByte()); // Відправлення пакета клієнта
            }

            BroadcastMessage($"[{disconnectedUser.Username}]: Disconnected!");

        }

    }
}
