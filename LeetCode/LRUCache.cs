using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RottingOranges
{
    public class LRUCache
    {
        private Dictionary<int, int> _cache = new Dictionary<int, int>();
        private Dictionary<int, LinkedListNode<int>> _nodes = new Dictionary<int, LinkedListNode<int>>();
        private LinkedList<int> _cacheList = new LinkedList<int>();
        private int _capacity = 0;
        private int _counter = 0;

        public LRUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (!_cache.ContainsKey(key))
            {
                return -1;
            }

            _cacheList.Remove(_nodes[key]);
            var node = _cacheList.AddLast(key);
            _nodes[key] = node;
            return _cache[key];
        }

        public void Put(int key, int value)
        {
            if (!_cache.ContainsKey(key))
            {
                _cache.Add(key, value);
                var node = _cacheList.AddLast(key);
                _nodes.Add(key, node);

                _counter++;

                if (_counter > _capacity)
                {
                    _cache.Remove(_cacheList.First.Value);
                    _nodes.Remove(_cacheList.First.Value);
                    _cacheList.RemoveFirst();
                    _counter--;
                }
            }
            else
            {
                _cache[key] = value;
                _cacheList.Remove(_nodes[key]);
                var node = _cacheList.AddLast(key);
                _nodes[key] = node;
            }
        }
    }
}
