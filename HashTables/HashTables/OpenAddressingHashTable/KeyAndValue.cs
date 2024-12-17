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
           
            if (_key != null && _value != null)
            {
                return _key.ToString() + "; " + _value.ToString();
            }
            else
            {
                return "null; null";
            }
        }
    }
}