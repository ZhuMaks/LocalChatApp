using System;
using System.IO;
using System.Text;

namespace ChatClient.Net.IO
{
    // Клас для побудови пакетів, що відправляються по мережі
    class PacketBuilder
    {
        // Поле MemoryStream для зберігання байтів пакета
        MemoryStream _ms;

        // Конструктор, що ініціалізує новий MemoryStream
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        // Метод для запису операційного коду (opcode) в пакет
        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        // Метод для запису повідомлення в пакет
        public void WriteMessage(string msg)
        {
            // Отримання довжини повідомлення
            var msgLength = msg.Length;
            // Запис довжини повідомлення як масиву байтів
            _ms.Write(BitConverter.GetBytes(msgLength));
            // Запис самого повідомлення як масиву байтів у кодуванні ASCII
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        // Метод для отримання масиву байтів, що представляє пакет
        public byte[] GetPacketByte()
        {
            return _ms.ToArray();
        }
    }
}
