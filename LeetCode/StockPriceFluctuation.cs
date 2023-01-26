using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class StockPrice
    {
        private Dictionary<int,int> _price;
        int _maxPrice;
        int _minPrice;
        int _lastTimestamp;
        bool _maxPriceInvalid;
        bool _minPriceInvalid;
        public StockPrice()
        {
            _price = new Dictionary<int, int>();
            _maxPrice = -1;
            _minPrice = int.MaxValue;
            _lastTimestamp = -1;
            _maxPriceInvalid = false;
            _minPriceInvalid = false;
        }

        public void Update(int timestamp, int price)
        {
            if (_maxPrice> -1 && _price[timestamp] == _maxPrice)
            {
                // need to find and update max price
                // _maxPriceIndex = _price.Where(kv => kv.Value == _price.Values.Max()).FirstOrDefault().Key;
                // _maxPrice = _price[_maxPriceIndex];
                _maxPriceInvalid = true;
            }

            if (_minPrice < int.MaxValue && _price[timestamp] == _minPrice)
            {
                // need to find and update min price
                //_minPriceIndex = _price.Where(kv => kv.Value == _price.Values.Min()).FirstOrDefault().Key;
                //_minPrice = _price[_minPriceIndex];
                _minPriceInvalid = true;
            }

            _price[timestamp] = price;
            

            if (!_maxPriceInvalid && price >= _maxPrice)
            {
                _maxPrice = price;
            }
            if (!_minPriceInvalid && price <= _minPrice)
            {
                _minPrice = price;
            }
            if (timestamp > _lastTimestamp)
            {
                _lastTimestamp = timestamp;
            }
        }

        public int Current()
        {
            return _price[_lastTimestamp];
        }

        public int Maximum()
        {
            if (_maxPriceInvalid)
            {
                _maxPrice = _price.Values.Max();
                _maxPriceInvalid = false;
            }
            return _maxPrice;
        }

        public int Minimum()
        {
            if (_minPriceInvalid)
            {
                _minPrice = _price.Values.Min();
                _minPriceInvalid = false;
            }
            return _minPrice;
        }
    }
}
