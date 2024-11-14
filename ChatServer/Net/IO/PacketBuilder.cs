using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // Додано для MemoryStream та інших IO операцій

namespace ChatServer.Net.IO
{
    // Клас для побудови пакетів даних, які будуть відправлені на клієнт
    class PacketBuilder
    {
        // Поле для зберігання потоку пам'яті
        MemoryStream _ms;

        // Конструктор, який ініціалізує потік пам'яті
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        // Метод для запису операційного коду в потік пам'яті
        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        // Метод для запису повідомлення в потік пам'яті
        public void WriteMessage(string msg)
        {
            // Запис довжини повідомлення як 4 байти
            var msgLength = msg.Length;
            _ms.Write(BitConverter.GetBytes(msgLength));
            // Запис самого повідомлення як масив байтів в кодуванні ASCII
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        // Метод для отримання байтового масиву з потоку пам'яті
        public byte[] GetPacketByte()
        {
            return _ms.ToArray();
        }
    }
}
