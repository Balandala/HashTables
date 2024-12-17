using HashTables.HashTables;
using HashTables.HashTables.ChainedHashTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTables.Interface
{
    public class View<T, U>
    {

        private int size;
        private TableType choosenHashTable;
        private void ChooseTable(TableType table)
        {
            choosenHashTable = table;
        }
        private IHashMap<T, U> hashTable;
        public void MakeView()
        {
            MainMenu.DisplayMenu(new[] { "" +
            "Хеш-таблица с резрешением коллизий методом цепочек",
                "Хеш-таблица с разрешением коллизий методом открытой адресации" },
                new[]
                {
                    () => ChooseTable(TableType.Chained),
                    () => ChooseTable(TableType.OpenAddresing)
                },
                "Выберите хеш-таблицу"
                );
        }
        enum TableType
        {
            Chained,
            OpenAddresing
        }
    }
}
