using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LFUCache
    {
        private Dictionary<int, LinkedListNode<int>> _dict = new Dictionary<int, LinkedListNode<int>>();
        private SortedDictionary<int, List<int>> _counter = new SortedDictionary<int, List<int>>();
        private Dictionary<int, int> _keyCounter = new Dictionary<int, int>();
        private LinkedList<int> _cacheList = new LinkedList<int>();
        private int _capacity = 0;
        public LFUCache(int capacity)
        {
            _capacity = capacity;
        }

        public int Get(int key)
        {
            if (_dict.ContainsKey(key))
            {
                var oldNode = _dict[key];
                var newNode = _cacheList.AddLast(_dict[key].Value);
                _cacheList.Remove(oldNode);
                _dict[key] = newNode;
                IncreaseCounter(key, oldNode, newNode);
                return _dict[key].Value;
            }
            return -1;
        }

        private void IncreaseCounter(int key, LinkedListNode<int> oldNode, LinkedListNode<int> newNode)
        {
            var currentCount = _keyCounter[key];
            _counter[_keyCounter[key]].Remove(key);
            if (!_counter.ContainsKey(currentCount + 1))
            {
                _counter.Add(currentCount + 1, new List<int>());
            }
            _counter[currentCount + 1].Add(key);
            _keyCounter[key] = currentCount + 1;
        }

        public void Put(int key, int value)
        {
            if (_capacity == 0)
            {
                return;
            }
            
            if (!_dict.ContainsKey(key))
            {
                if (_dict.Count == _capacity)
                {
                    CleanUp();
                }
                var node = _cacheList.AddLast(value);
                _dict.Add(key, node);
                _keyCounter[key] = 1;
                if (!_counter.ContainsKey(1))
                {
                    _counter[1] = new List<int>();
                }
                _counter[1].Add(key);
            }
            else
            {
                var oldNode = _dict[key];
                var newNode = _cacheList.AddLast(value);
                _cacheList.Remove(_dict[key]);
                _dict[key] = newNode;
                IncreaseCounter(key, oldNode, newNode);
            }
        }

        private void CleanUp()
        {
            foreach (var item in _counter)
            {
                if (item.Value.Count > 0)
                {
                    int keyToRemove = item.Value[0];

                    item.Value.Remove(keyToRemove);
                    _cacheList.Remove(_dict[keyToRemove]);
                    _dict.Remove(keyToRemove);
                    return;
                }
            }
        }
    }
}
