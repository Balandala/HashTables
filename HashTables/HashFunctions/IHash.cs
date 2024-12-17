using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.HashFunctions
{
    internal interface IHash
    {
        int Hash(int key);
    }
}
