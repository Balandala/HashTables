using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    // Класс для генерации наборов данных
    internal class DataSetsGenerator
    {
        public static Dictionary<int, int> GenerateSet(int size)
        {
            // Создаем словарь для хранения пар ключ-значение
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            Random random = new Random();

            HashSet<int> visited = new HashSet<int>();

            // Генерируем уникальные ключи, пока их количество не достигнет заданного размера
            while (visited.Count < size)
            {
                visited.Add(random.Next(0, 100000));
            }

            // Добавляем каждый уникальный ключ в словарь вместе со случайным значением
            foreach (int id in visited)
            {
                dictionary.Add(id, random.Next());
            }

            return dictionary;
        }
    }
}

