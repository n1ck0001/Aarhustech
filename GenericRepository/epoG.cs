using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository
{
    public class epoG<T>
    {
        public Dictionary<string,T>_items;

        public epoG() 
        {
            _items = new Dictionary<string,T>();
        }
        
        public void Insert(string name, T Type)
        {
            if (!_items.ContainsKey(name))
            {
                _items.Add(name, Type);
            }
        }

        public void Delete(string name)
        {
            if (!_items.ContainsKey(name))
            {
                _items.Remove(name);
            }
        }


        public void PrintAll()
        {
            _items.Values.ToList().ForEach(item =>
            {
                Debug.WriteLine(item);
            });
            Debug.WriteLine("----");
        }
    }
}
