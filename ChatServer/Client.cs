using ChatServer.Net.IO; // Підключення простору імен для вводу-виводу пакетів
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    // Клас для представлення клієнта, підключеного до сервера
    class Client
    {
        public string Username { get; set; }

        public Guid UID { get; set; }

        // Сокет для підключення клієнта
        public TcpClient ClientSocket { get; set; }

        // Зчитувач пакетів
        PacketReader _packetReader;

        // Конструктор, який ініціалізує клієнта
        public Client(TcpClient client)
        {
            ClientSocket = client; // Призначення клієнтського сокета
            UID = Guid.NewGuid(); // Генерація унікального ідентифікатора
            _packetReader = new PacketReader(ClientSocket.GetStream()); // Ініціалізація зчитувача пакетів

            // Читання початкових даних клієнта
            var opcode = _packetReader.ReadByte(); // опкоду
            Username = _packetReader.ReadMessage(); // імені користувача

            Console.WriteLine($"[{DateTime.Now}]: Client has connected with the username: {Username}");

            // Запуск асинхронного процесу для обробки клієнтських повідомлень
            Task.Run(() => Process());
        }

        // Метод для обробки повідомлень клієнта
        void Process()
        {
            while (true)
            {
                try
                {
                    var opcode = _packetReader.ReadByte(); // Читання опкоду

                    // Обробка отриманого опкоду
                    switch (opcode)
                    {
                        case 5:
                            var msg = _packetReader.ReadMessage(); // Читання повідомлення
                            Console.WriteLine($"[{DateTime.Now}]: Message received! {msg}");
                            Program.BroadcastMessage($"[{DateTime.Now}]: [{Username}]: {msg}"); // Розсилка повідомлення
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"[{UID.ToString()}]: Disconnected!"); // Виведення інформації про відключення клієнта
                    Program.BroadcastDisconnect(UID.ToString()); // Повідомлення про відключення клієнта
                    ClientSocket.Close(); 
                    break;
                }
            }
        }
    }
}
