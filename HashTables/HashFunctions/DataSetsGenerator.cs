using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{

    internal class DataSetsGenerator
    {

        public static Dictionary<int, int> GenerateSet(int size)
        {
            // Создаем словарь для хранения пар ключ-значение
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            Random random = new Random();

            // Создаем HashSet для отслеживания уникальных ключей
            HashSet<int> visited = new HashSet<int>();

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

