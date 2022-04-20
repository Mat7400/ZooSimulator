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
        /// <summary>
        /// конструктор - специальная функция которая при создании класса позволяет
        /// заполнить его поля и сделать проверки входных данных
        /// </summary>
        /// <param name="incName">имя</param>
        /// <param name="iTail">хвост</param>
        /// <param name="Fly">полет</param>
        /// <param name="paws">лапы количество</param>
        public testAnimal(string incName, bool iTail, bool Fly, int paws)
        {
            if (paws >= 8) System.Windows.Forms.MessageBox.Show("BEWARE OF SPIDER");
            if (Fly) System.Windows.Forms.MessageBox.Show("IT CAN FLY");

            if (paws <= 1)
            {
                Exception ex = new Exception("no work with such animals");
                throw ex;
            }

            hasTail = iTail;
            canFLY = Fly;
            numberPaws = paws;
            name = incName;
        }
        public testAnimal()
        { 
            //пустой констуктор по умолчанию
            //такое же название но нет параметров в () - другой кусок кода
        }
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
    //ДЗ от 17.04 *: сделать класс хомячка с признаком насколько пушистый от 1 до 100
    //и фукнцией пищать
}
