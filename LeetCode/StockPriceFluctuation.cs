using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class StockPrice
    {
        private SortedList<int, int> _priceList;
        Dictionary<int, int> _log;
        int _lastTimestamp = 0;
        int _lastPrice;
        
        public StockPrice()
        {
           _priceList = new SortedList<int, int>();
            _log = new Dictionary<int, int>();
        }

        public void Update(int timestamp, int price)
        {
            if (!_log.ContainsKey(timestamp))
            {
                _log.Add(timestamp, price);
                if (!_priceList.ContainsKey(price))
                {
                    _priceList.Add(price, 1);
                }
                else
                {
                    _priceList[price]++;
                }
            }
            else
            {
                var oldPrice = _log[timestamp];
                _priceList[oldPrice]--;
                if (_priceList[oldPrice] == 0)
                {
                    _priceList.Remove(oldPrice);
                }

                if (!_priceList.ContainsKey(price))
                {
                    _priceList.Add(price, 1);
                }
                else
                {
                    _priceList[price]++;
                }
                _log[timestamp] = price;
            }
            
            if (timestamp >= _lastTimestamp)
            {
                _lastTimestamp = timestamp;
                _lastPrice = price;
            }
        }

        public int Current()
        {
            return _lastPrice;
        }

        public int Maximum()
        {
            return _priceList.Keys[_priceList.Count - 1];
        }

        public int Minimum()
        {
            return _priceList.Keys[0];
        }
    }
}
