using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables.OpenAddressingHashTable
{
    // Класс, представляющий пару ключ-значение
    internal class KeyAndValue<TKey, TValue>
    {
        // Приватные поля для хранения ключа и значения
        private readonly TKey _key;
        private readonly TValue _value;

        // Конструктор класса
        public KeyAndValue(TKey key, TValue value)
        {
            _key = key;
            _value = value;
        }

        // Метод для получения ключа
        public TKey GetKey() { return _key; }

        // Метод для получения значения
        public TValue GetValue() { return _value; }

        // Переопределение метода ToString для удобного вывода
        public override string ToString()
        {
            // Проверяем, что ключ и значение не равны null
            if (_key != null && _value != null)
            {
                // Возвращаем строковое представление ключа и значения
                return _key.ToString() + "; " + _value.ToString();
            }
            else
            {
                // Если ключ или значение равны null, возвращаем "null; null"
                return "null; null";
            }
        }
    }
}