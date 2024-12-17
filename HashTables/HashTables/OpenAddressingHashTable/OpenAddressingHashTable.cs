using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables.OpenAddressingHashTable
{
    // Класс, реализующий хеш-таблицу с открытой адресацией
    internal class OpenAdressHashMap<TKey, TValue> : IHashMap<TKey, TValue>
    {
        // Размер хеш-таблицы
        public int Size { get; private set; }

        // Флаг, указывающий, нужно ли выбрасывать исключение при переполнении таблицы
        private bool IsExceptionNeed;

        // Хеш-функция, используемая для вычисления индекса
        private Func<object, int, int, int> hashFunc;

        // Массив для хранения пар ключ-значение
        private KeyAndValue<TKey, TValue>[] hashMapValues;

        // Конструктор класса
        public OpenAdressHashMap(int size, Func<object, int, int, int> hashFunc, bool isExceptionNeed)
        {
            Size = size;
            this.hashFunc = hashFunc;
            hashMapValues = new KeyAndValue<TKey, TValue>[size];
            IsExceptionNeed = isExceptionNeed;
        }

        // Метод для добавления элемента в хеш-таблицу
        public void Add(TKey key, TValue value)
        {
            int attemptNumber = 0;

            // Повторяем попытки вставки, пока не найдём свободный индекс или не достигнем размера таблицы
            for (; attemptNumber < Size; attemptNumber++)
            {
                int index = hashFunc(key, Size, attemptNumber);

                // Если индекс свободен, добавляем элемент
                if (hashMapValues[index] is null)
                {
                    hashMapValues[index] = new KeyAndValue<TKey, TValue>(key, value);
                    return;
                }
                // Если найден элемент с таким же ключом, выбрасываем исключение
                else if (Equals(hashMapValues[index].GetKey(), key))
                {
                    throw new InvalidOperationException("В таблице уже существует пара с таким ключём");
                }
            }

            // Если таблица переполнена и нужно выбросить исключение, делаем это
            if (IsExceptionNeed)
            {
                throw new InvalidOperationException("Cлучилось переполнение хэш таблицы.");
            }

            // Если исключение не нужно, увеличиваем размер таблицы и повторяем вставку
            IncreaseTableSize();
            Add(key, value);
        }

        // Метод для увеличения размера таблицы
        private void IncreaseTableSize()
        {
            // Увеличиваем размер таблицы в два раза
            Size = Size * 2;

            // Сохраняем старые значения
            KeyAndValue<TKey, TValue>[] oldHashMapValues = hashMapValues.ToArray();

            // Создаём новую таблицу с увеличенным размером
            hashMapValues = new KeyAndValue<TKey, TValue>[Size];

            // Перехешируем все элементы из старой таблицы в новую
            foreach (KeyAndValue<TKey, TValue> pair in oldHashMapValues)
            {
                if (pair is not null)
                {
                    Add(pair.GetKey(), pair.GetValue());
                }
            }
        }

        // Метод для удаления элемента по ключу
        public void Remove(TKey key)
        {
            for (int attemptNumber = 0; attemptNumber < Size; attemptNumber++)
            {
                int index = hashFunc(key, Size, attemptNumber);

                // Если найден элемент с заданным ключом, удаляем его
                if (hashMapValues[index] is not null && Equals(hashMapValues[index].GetKey(), key))
                {
                    Console.WriteLine($"Пара с ключем {key}, а именно " +
                        $"{hashMapValues[index].GetKey()};{hashMapValues[index].GetValue()} была успешно удалена из Хэш-таблицы");
                    hashMapValues[index] = null;
                    return;
                }
            }

            // Если элемент не найден, выводим сообщение
            Console.WriteLine($"Элемента с данным ключём {key} нет в Хэш-таблице");
        }

        // Метод для получения элемента по ключу
        public void Get(TKey key)
        {
            for (int attemptNumber = 0; attemptNumber < Size; attemptNumber++)
            {
                int index = hashFunc(key, Size, attemptNumber);

                // Если найден элемент с заданным ключом, выводим его
                if (hashMapValues[index] is not null && Equals(hashMapValues[index].GetKey(), key))
                {
                    Console.WriteLine($"Вот искомая пара с ключем {key} из Хэш-таблицы:" +
                        $" {hashMapValues[index].GetKey()};{hashMapValues[index].GetValue()}");
                    return;
                }
            }

            // Если элемент не найден, выводим сообщение
            Console.WriteLine($"Элемента с данным ключём {key} нет в Хэш-таблице");
        }

        // Метод для вычисления коэффициента заполнения таблицы
        public double GetKoef() => hashMapValues.ToList().Sum(x => x is not null ? 1 : 0) / (double)Size;

        // Метод для получения длины самого длинного кластера
        public int GetLongestClusterLength()
        {
            int maxClusterLength = 0;
            int currentClusterLength = 0;

            // Перебираем все элементы таблицы
            for (int i = 0; i < Size; i++)
            {
                if (hashMapValues[i] is null)
                {
                    // Если текущий элемент равен null, обновляем максимальную длину кластера
                    maxClusterLength = Math.Max(currentClusterLength, maxClusterLength);
                    currentClusterLength = 0;
                }
                else
                {
                    // Иначе увеличиваем текущую длину кластера
                    currentClusterLength++;
                }
            }

            // Обновляем максимальную длину кластера после завершения цикла
            maxClusterLength = Math.Max(currentClusterLength, maxClusterLength);
            return maxClusterLength;
        }

        // Метод для вывода содержимого таблицы
        public void Print()
        {
            foreach (KeyAndValue<TKey, TValue> keyAndValue in hashMapValues)
            {
                if (keyAndValue is not null)
                {
                    Console.WriteLine(keyAndValue.ToString());
                }
                else
                {
                    Console.WriteLine("null; null");
                }
            }
        }
    }
}