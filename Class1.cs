using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator
{
    public class Class1
    {
        public string myString = "";
        int myInt = 0;
        public double myDouble = 1.5;
        float myFloat = 2.7f;

        public void main()
        {
            //когда в коде в скобках пишем тип - это явное преобразование
            int res = add( (int)myDouble, (int)myFloat);

        }
        int add(int a, int b)
        {
            return a + b;
        }
        public double x2()
        {
            return myDouble * 2;
        }
    }
}
