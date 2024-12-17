﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    // Класс для генерации наборов данных
    internal class DataSetsGenerator
    {
        // Метод для генерации набора данных заданного размера
        public static Dictionary<int, int> GenerateSet(int size)
        {
            // Создаем словарь для хранения пар ключ-значение
            Dictionary<int, int> dictionary = new Dictionary<int, int>();

            // Создаем объект Random для генерации случайных чисел
            Random random = new Random();

            // Создаем HashSet для отслеживания уникальных ключей
            HashSet<int> visited = new HashSet<int>();

            // Генерируем уникальные ключи, пока их количество не достигнет заданного размера
            while (visited.Count < size)
            {
                // Генерируем случайное число в диапазоне от 0 до 99999
                visited.Add(random.Next(0, 100000));
            }

            // Добавляем каждый уникальный ключ в словарь вместе со случайным значением
            foreach (int id in visited)
            {
                // Генерируем случайное значение для ключа
                dictionary.Add(id, random.Next());
            }

            // Возвращаем сгенерированный словарь
            return dictionary;
        }
    }
}

