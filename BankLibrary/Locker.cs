using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    class Locker
    {

        private object _data;
        private string _keyword;
        private int _id;
        public void RemoveData()
        {
            _data = null;
        }
        public Locker(int id, string keyword, object data)
        {
            _id = id;
            _keyword = keyword;
            _data = data;
        }
        public Locker(int id, string keyword)
        {
            _id = id;
            _keyword = keyword;
            
        }
        public int Id => _id;
        public object Data => _data;
        public bool Matches(int id, string keyword)
        {
            return id == _id && keyword.Equals(_keyword, StringComparison.Ordinal);
        }
    }
}
