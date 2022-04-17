using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooSimulator
{
    public class testAnimal
    {
        public string name = "";
        public bool hasTail = false;
        public bool canFLY = true;
        public int numberPaws = 2;

        public string BaseStr()
        {
            return name + " " + numberPaws.ToString();
        }
        public string saySmth()
        {
            return "not definded";
        }
    }
    /// <summary>
    /// класс кошки наследуется от Животного. кроме базовых 4 признаков и функции 
    /// добавляется свой признак poroda и функция meow
    /// </summary>
    public class Cat : testAnimal
    {
        public string poroda = "";
        public string meow()
        {
            return "MEOW";
        }
    }
    /// <summary>
    /// класс собаки наследуется от Животного. кроме базовых 4 признаков и функции 
    /// добавляется 2 своих признак VetPasport и naskolkoKrasivaya и функция гаф
    /// </summary>
    public class Dog: testAnimal
    {
        public string VetPasport = "";
        public int naskolkoKrasivaya = 100;
        public string gaf()
        {
            return name + " says gaf-gaf";
        }
    }
}
