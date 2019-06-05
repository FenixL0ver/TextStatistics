using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Доп_задания
{
    class CountString
    {
        public string String { get; }
        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                Debug.Assert(value >= 0);
                _count = value;
            }
        }
        public CountString() { }
        public CountString(string str)
        {
            String = str;
            Count = 1;
        }

        public void IncCount()
        {
            Count+=1;
        }

        public int CompareTo(CountString countString)
        {
            return String.CompareTo(countString);
        }

        public void Print()
        {
            Console.WriteLine($"Строка:{String} Количество вхождений:{Count}");
        }
    }
}
