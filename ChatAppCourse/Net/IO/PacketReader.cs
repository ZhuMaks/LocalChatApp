using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace ChatClient.Net.IO
{
    // Клас для читання пакетів з мережевого потоку, наслідується від BinaryReader
    class PacketReader : BinaryReader
    {
        // Поле NetworkStream для зберігання мережевого потоку
        private NetworkStream _ns;

        // Конструктор, що приймає NetworkStream і ініціалізує базовий клас BinaryReader
        public PacketReader(NetworkStream ns) : base(ns)
        {
            _ns = ns;
        }

        // Метод для читання повідомлення з потоку
        public string ReadMessage()
        {
            byte[] msgBuffer; // Буфер для зберігання байтів повідомлення
            var length = ReadInt32(); // Читання довжини повідомлення з потоку
            msgBuffer = new byte[length]; // Ініціалізація буфера потрібного розміру
            _ns.Read(msgBuffer, 0, length); // Читання повідомлення в буфер

            // Перетворення байтів повідомлення в рядок з використанням кодування ASCII
            var msg = Encoding.ASCII.GetString(msgBuffer);

            return msg; 
        }
    }
}
