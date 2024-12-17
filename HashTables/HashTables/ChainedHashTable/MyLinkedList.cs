using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables.ChainedHashTable
{
    // Класс, реализующий связный список для хранения элементов в хеш-таблице
    public class MyLinkedList<TKey, TValue> : IEnumerable<Node<TKey, TValue>>
    {
        // Головной узел списка
        public Node<TKey, TValue> Head { get; protected set; }

        // Хвостовой узел списка
        public Node<TKey, TValue> Tail { get; protected set; }

        // Количество элементов в списке
        public int Count { get; protected set; } = 0;

        // Проверка, пуст ли список
        public bool IsEmpty() => Head == null;

        // Очистка списка
        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        // Получение узла по ключу
        public Node<TKey, TValue> Get(TKey key)
        {
            // Перебираем все элементы списка
            foreach (var item in this)
            {
                // Если ключи совпадают, возвращаем узел
                if (Equals(key, item.Key))
                {
                    return item;
                }
            }

            // Если элемент не найден, возвращаем null
            return null;
        }

        // Проверка, существует ли элемент с заданным ключом и значением
        private bool Check(TKey key, TValue value)
        {
            foreach (var item in this)
            {
                if (Equals(key, item.Key) && Equals(value, item.Value))
                {
                    return true;
                }
            }

            return false;
        }

        // Добавление элемента в список
        public void Add(TKey key, TValue value)
        {
            // Проверяем, существует ли уже такой элемент
            if (Check(key, value))
            {
                throw new ArgumentException($"Hash-Map already contains same Element");
            }

            // Если список пуст, создаем новый узел и делаем его головным и хвостовым
            if (IsEmpty())
            {
                Tail = Head = new Node<TKey, TValue>(key, value, null);
            }
            else
            {
                // Иначе добавляем новый узел в конец списка
                var item = new Node<TKey, TValue>(key, value, null);
                Tail.Next = item;
                Tail = item;
            }

            // Увеличиваем счётчик элементов
            Count++;
        }

        // Реализация интерфейса IEnumerable для перебора элементов списка
        public IEnumerator<Node<TKey, TValue>> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }

        // Реализация интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Удаление элемента по ключу
        public void RemoveSameElement(TKey key)
        {
            int count = 0;

            // Перебираем все элементы списка
            foreach (var el in this)
            {
                // Если ключи совпадают, удаляем элемент по индексу
                if (Equals(el.Key, key))
                {
                    RemoveAt(count);
                    return;
                }
                else
                {
                    count++;
                }
            }

            // Если элемент не найден, выбрасываем исключение
            throw new ArgumentException($"Element with key {key} does not exist in Hash-Map");
        }

        // Удаление элемента по индексу
        public void RemoveAt(int index)
        {
            int count = 0;
            Node<TKey, TValue> current = Head;

            // Проверяем, что индекс находится в допустимых пределах
            if (index >= Count || index < 0) throw new ArgumentOutOfRangeException("index is outside of list");

            // Если удаляем первый элемент
            if (index == 0)
            {
                Head = Head.Next;
            }
            else
            {
                // Иначе находим предыдущий элемент
                while (count != index - 1)
                {
                    current = current.Next;
                    count++;
                }

                // Если удаляем последний элемент, обновляем хвостовой узел
                if (index == Count - 1)
                {
                    Tail = current;
                }

                // Удаляем ссылку на текущий элемент
                current.Next = current.Next.Next;
            }

            // Уменьшаем счётчик элементов
            Count--;
        }
    }

    // Класс, представляющий узел связного списка
    public class Node<K, V>
    {
        // Значение узла
        public V Value { get; set; }

        // Реальный ключ (не используется в данном коде)
        public V RealKey { get; set; }

        // Ссылка на следующий узел
        public Node<K, V> Next { get; set; }

        // Ключ узла
        public K Key { get; private set; }

        // Конструктор узла
        public Node(K key, V value, Node<K, V> next)
        {
            Key = key;
            Value = value;
            Next = next;
        }
    }
}