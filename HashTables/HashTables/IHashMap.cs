﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashTables
{
    internal interface IHashMap<TKey, TValue>
    {
        public double GetKoef();
        public void Get(TKey key);
        public void Add(TKey key, TValue value);
        public void Remove(TKey key);
    }
}
