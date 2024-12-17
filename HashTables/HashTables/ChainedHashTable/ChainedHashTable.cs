using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables.ChainedHashTable
{
    // Класс, реализующий хеш-таблицу с разрешением коллизий методом цепочек
    public class ChainedHashMap<TKey, TValue> : IHashMap<TKey, TValue>
    {
        // Размер хеш-таблицы
        public int Size { get; private set; }

        // Массив связных списков для хранения элементов
        private MyLinkedList<TKey, TValue>[] _values;

        // Хеш-функция, используемая для вычисления индекса
        private Func<object, int, int> _hashFunc;

        // Конструктор класса
        public ChainedHashMap(int size, Func<object, int, int> hash)
        {
            Size = size;
            _values = new MyLinkedList<TKey, TValue>[size];
            _hashFunc = hash;

            // Инициализация каждой ячейки массива пустым связным списком
            for (int i = 0; i < size; i++)
            {
                _values[i] = new MyLinkedList<TKey, TValue>();
            }
        }

        // Метод для получения значения по ключу
        public TValue Get(TKey key)
        {
            // Вычисляем хеш ключа
            int hash = _hashFunc(key, Size);

            // Если список по данному хешу не пуст, ищем элемент
            if (_values[hash].Count != 0)
            {
                MyLinkedList<TKey, TValue> nodes = _values[hash];
                return nodes.Get(key).Value;
            }

            // Если элемент не найден, выбрасываем исключение
            throw new ArgumentException($"Hash-Map does not contains element with given key {key.ToString()}");
        }

        // Метод для добавления элемента в хеш-таблицу
        public void Add(TKey key, TValue value)
        {
            // Вычисляем хеш ключа
            int hash = _hashFunc(key, Size);

            // Если список по данному хешу пуст, создаем новый список
            if (_values[hash].Count == 0)
            {
                MyLinkedList<TKey, TValue> nodes = new MyLinkedList<TKey, TValue>();
                nodes.Add(key, value);
                _values[hash] = nodes;
            }
            else
            {
                // Иначе добавляем элемент в существующий список
                _values[hash].Add(key, value);
            }
        }

        // Метод для удаления элемента по ключу
        public void Remove(TKey key)
        {
            // Вычисляем хеш ключа
            int hash = _hashFunc(key, Size);

            // Если список по данному хешу не пуст, удаляем элемент
            if (_values[hash].Count != 0)
            {
                MyLinkedList<TKey, TValue> nodes = _values[hash];
                nodes.RemoveSameElement(key);
            }
            else
            {
                // Если элемент не найден, выбрасываем исключение
                throw new ArgumentException($"Hash-Map does not contains element with given key {key.ToString()}");
            }
        }

        // Метод для тестирования хеш-таблицы с заданным набором данных
        public void Test(Dictionary<TKey, TValue> set)
        {
            // Проверяем, что размер набора данных не превышает размер хеш-таблицы
            if (set.Count > Size)
            {
                throw new ArgumentException($"Size of set more than Hash-Map.");
            }

            // Инициализируем массив связных списков
            _values = new MyLinkedList<TKey, TValue>[Size];

            // Добавляем все элементы из набора данных в хеш-таблицу
            foreach (var el in set)
            {
                Add(el.Key, el.Value);
            }
        }

        // Метод для вычисления коэффициента заполнения хеш-таблицы
        public double GetKoef() => _values.ToList().Sum(x => x.Count) / (double)Size;

        // Метод для получения длины самой короткой цепочки
        public int GetShortestChain() => _values.ToList().Min(x => x.Count);

        // Метод для получения длины самой длинной цепочки
        public int GetLongestChain() => _values.ToList().Max(x => x.Count);

        // Метод для вывода содержимого хеш-таблицы
        public void Print()
        {
            foreach (var el in _values)
            {
                if (el is not null)
                {
                    bool count = true;
                    foreach (var e in el)
                    {
                        Console.Write($"({e.Key};{e.Value})->");
                    }
                }
                else
                {
                    Console.Write("null; null");
                }
                Console.WriteLine();
            }

            // Выводим длину самой длинной цепочки
            Console.WriteLine($"Длина макисмальной цепочки:{GetLongestChain()}");
        }

        // Реализация метода интерфейса IHashMap (не реализован)
        void IHashMap<TKey, TValue>.Get(TKey key)
        {
            throw new NotImplementedException();
        }
    }
}