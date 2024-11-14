using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Додано для BinaryReader та інших IO операцій

namespace ChatServer.Net.IO
{
    // Клас для читання пакетів даних з мережевого потоку
    class PacketReader : BinaryReader
    {
        // Поле для зберігання мережевого потоку
        private NetworkStream _ns;

        // Конструктор, який ініціалізує мережевий потік
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }

        // Метод для читання повідомлення з мережевого потоку
        public string ReadMessage()
        {
            byte[] msgBuffer; // Буфер для зберігання байтів повідомлення
            var length = ReadInt32(); // Читання довжини повідомлення (перші 4 байти)
            msgBuffer = new byte[length]; // Ініціалізація буфера потрібного розміру
            _ns.Read(msgBuffer, 0, length); // Читання повідомлення з мережевого потоку

            // Перетворення байтового масиву в строку в кодуванні ASCII
            var msg = Encoding.ASCII.GetString(msgBuffer);

            return msg; // Повернення прочитаного повідомлення
        }
    }
}
