using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    // Статический класс, содержащий различные хеш-функции
    public static class HashFunctionsBase
    {
        // Хеш-функция с использованием побитовых операций
        public static int HashWithBitMovement(object data, int size)
        {
            byte[] hash = ObjectToByteArray(data);
            List<byte> list = new List<byte>();

            // Если длина массива меньше 128, дополняем его нулями
            if (hash.Length < 128)
            {
                for (int i = 0; i < 128 - hash.Length; i++)
                {
                    list.Add(0);
                }

                // Добавляем байты из исходного массива
                hash.ToList().ForEach(x => list.Add(x));
            }

            // Инициализируем начальное значение хеша
            long res = 1315423911;

            // Применяем побитовую операцию XOR для каждого байта
            for (int i = 0; i < list.Count; i++)
            {
                res ^= ((res << 5) + list[i] + (res >> 2));
            }

            // Берем абсолютное значение результата
            res = Math.Abs(res);

            // Возвращаем хеш по модулю размера таблицы
            return (int)(res % size);
        }

        // Хеш-функция с использованием метода умножения
        public static int HashWithMultiplication(object data, int size)
        {
            byte[] hash = ObjectToByteArray(data);
            List<byte> list = new List<byte>();

            if (hash.Length < 128)
            {
                for (int i = 0; i < 128 - hash.Length; i++)
                {
                    list.Add(0);
                }

                hash.ToList().ForEach(x => list.Add(x));
            }

            int sum = list.Sum(x => x);

            // Применяем метод умножения для вычисления хеша
            return (int)Math.Round((double)sum * 0.6180339887 * size) % size;
        }

        // Хеш-функция с использованием метода деления
        public static int HashWithDevision(object data, int size)
        {
            byte[] hash = ObjectToByteArray(data);
            List<byte> list = new List<byte>();

            if (hash.Length < 128)
            {
                for (int i = 0; i < 128 - hash.Length; i++)
                {
                    list.Add(0);
                }

                hash.ToList().ForEach(x => list.Add(x));
            }

            int sum = list.Sum(x => x);

            // Применяем метод деления для вычисления хеша
            if (size < 128)
            {
                sum = sum << list[127 % size];
                sum *= 127 % size;
            }
            else
            {
                sum = sum << list[size % 127];
                sum *= size % 127;
            }

            if (sum > size)
            {
                return (sum / size) % size;
            }
            return (size / sum) % sum;
        }

        // Хеш-функция для линейного исследования
        public static int LineralyResearchHash(object data, int size, int attemptNumber)
        {
            byte[] hash = ObjectToByteArray(data);
            List<byte> list = new List<byte>();

            if (hash.Length < 128)
            {
                for (int i = 0; i < 128 - hash.Length; i++)
                {
                    list.Add(0);
                }

                hash.ToList().ForEach(x => list.Add(x));
            }

            int sum = list.Sum(x => x);

            // Возвращаем хеш для линейного исследования
            return (sum % 68 + attemptNumber) % size;
        }

        // Хеш-функция для квадратичного исследования
        public static int QuadraticResearchHash(object data, int size, int attemptNumber)
        {
            byte[] hash = ObjectToByteArray(data);
            List<byte> list = new List<byte>();

            if (hash.Length < 128)
            {
                for (int i = 0; i < 128 - hash.Length; i++)
                {
                    list.Add(0);
                }

                hash.ToList().ForEach(x => list.Add(x));
            }

            int sum = list.Sum(x => x);

            // Возвращаем хеш для квадратичного исследования
            return (sum % 10 + attemptNumber + 2 * attemptNumber * attemptNumber) % size;
        }

        // Хеш-функция для двойного хеширования
        public static int DualHash(object data, int size, int attemptNumber)
        {
            byte[] hash = ObjectToByteArray(data);
            List<byte> list = new List<byte>();

            if (hash.Length < 128)
            {
                for (int i = 0; i < 128 - hash.Length; i++)
                {
                    list.Add(0);
                }

                hash.ToList().ForEach(x => list.Add(x));
            }

            int sum = list.Sum(x => x);

            // Возвращаем хеш для двойного хеширования
            return (sum % size + attemptNumber * (1 + sum % (size - 1))) % size;
        }

        // Метод для преобразования объекта в массив байтов
        private static byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;

            // Сериализация объекта в JSON-строку
            string jsonString = JsonSerializer.Serialize(obj);

            // Преобразование JSON-строки в массив байтов
            return System.Text.Encoding.UTF8.GetBytes(jsonString);
        }
    }
}